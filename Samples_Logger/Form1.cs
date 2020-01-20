using GenericLogger;
using GenericLogger.DataStructures;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NewtonsoftJsonHelper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;

namespace Samples_Logger
{
    public partial class Form1 : Form
    {
        private GLoggerManager Manager { get; set; }
        private SubLogger SubLogger1 { get; set; }
        private SubLogger SubLogger2 { get; set; }

        private System.Timers.Timer _Timer1 { get; set; }
        private System.Timers.Timer _Timer2 { get; set; }
        private System.Timers.Timer _Timer3 { get; set; }
        private System.Timers.Timer _Timer4 { get; set; }

        public Form1()
        {
            InitializeComponent();

            var messageSetting = new GLoggerSettings();
            var debugSetting = new GLoggerSettings();
            debugSetting.SetEncryption("12345678901234567890123456789012", "1234567890abcdef");

            Manager = new GLoggerManager(
                (object value) => { return JsonConvert.SerializeObject(value, Formatting.None, new JsonImageConverter(), new StringEnumConverter()); },
                (string value, Type type) => { return JsonConvert.DeserializeObject(value, type, new JsonImageConverter(), new StringEnumConverter()); },
                messageSetting,
                debugSetting);

            SubLogger1 = Manager.CreateSubLogger("TestSubLogger1");
            SubLogger2 = Manager.CreateSubLogger("TestSubLogger2");

            var funcs = Manager.SetManualAndGetFunc();

            _Timer1 = CreateTimer(funcs.Item1);
            _Timer2 = CreateTimer(funcs.Item2);
            _Timer3 = CreateTimer(funcs.Item3);
            _Timer4 = CreateTimer(funcs.Item4);
        }
        private System.Timers.Timer CreateTimer(Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 100;
            timer.Elapsed += delegate (object source, ElapsedEventArgs e)
            {
                action();

                Invoke((MethodInvoker)delegate
                {
                    textBox1.Text = DateTime.Now.ToString("HH:mm:ss.fff");
                });
            };
            timer.Enabled = true;

            return timer;
        }

        private void _EnqueueItems()
        {
            int count = (int)numericUpDown1.Value;

            for (int i = 0; i < count; i++)
            {
                SubLogger1.Log(LogTypes.Info, "Info.");
                SubLogger1.Log(LogTypes.Error, "Error.", "Error" + i);
                SubLogger1.Log(LogTypes.Debug, "Debug.", "Debug" + i);
                SubLogger2.Log(LogTypes.Info, "Info. SubLogger2");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _EnqueueItems();
        }
    }
}
