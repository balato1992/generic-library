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
        private GLoggerModel _Logger { get; set; }
        private System.Timers.Timer _Timer { get; set; }
        private ConcurrentQueue<Dictionary<string, List<string>>> _Pools { get; set; }
        private System.Timers.Timer _Timer2 { get; set; }

        public Form1()
        {
            InitializeComponent();

            _Pools = new ConcurrentQueue<Dictionary<string, List<string>>>();

            _Timer = new System.Timers.Timer();
            _Timer.Interval = 100;
            _Timer.Elapsed += delegate (object source, ElapsedEventArgs e)
            {
                Dictionary<string, List<string>> item = null;
                while (_Pools.TryDequeue(out item))
                {
                    _Logger.SaveFromPoolItems(item);
                }

                Invoke((MethodInvoker)delegate {
                    textBox1.Text = DateTime.Now.ToString("HH:mm:ss.fff");
                });
            };
            _Timer.Enabled = true;

            _Timer2 = new System.Timers.Timer();
            _Timer2.Interval = 100;
            _Timer2.Elapsed += delegate (object source, ElapsedEventArgs e)
            {
                _EnqueueItems();
                Invoke((MethodInvoker)delegate {
                    textBox2.Text = _Pools.Count.ToString();
                });
            };
            _Timer2.Enabled = false;

            _Logger = new GLoggerModel((object value) =>
            {
                return JsonConvert.SerializeObject(value, Formatting.None, new JsonImageConverter(), new StringEnumConverter());
            }, (string value, Type type) =>
            {
                return JsonConvert.DeserializeObject(value, type, new JsonImageConverter(), new StringEnumConverter());
            });
            _Logger.Setting.FileEncryption = true;
        }

        private void _EnqueueItems()
        {
            int count = (int)numericUpDown1.Value;

            List<LogInfo> lis = new List<LogInfo>();
            for (int i = 0; i < count; i++)
            {
                LogInfo li = new LogInfo(DateTime.Now, LogTypes.Error, "Error.", "Error" + i);
                LogInfo li2 = new LogInfo(DateTime.Now, LogTypes.Debug, "Debug.", "Debug" + i);
                LogInfo li3 = new LogInfo(DateTime.Now, LogTypes.Error, "Append.", "Append" + i, li2);
                LogInfo li4 = new LogInfo(DateTime.Now, LogTypes.Error, "Subname,", "Subname" + i, null, "sbn");
                LogInfo li5 = new LogInfo(DateTime.Now, LogTypes.Error, "Subname2", "Subname2" + i, null, "sbn2");
                LogInfo li6 = new LogInfo(DateTime.Now, LogTypes.Error, "Subname3", "Subname3" + i, null, "sbn3");

                lis.Add(li);
                lis.Add(li2);
                lis.Add(li3);
                lis.Add(li4);
                lis.Add(li5);
            }

            Dictionary<string, List<string>> item = _Logger.ConvertToPoolItems(lis);

            _Pools.Enqueue(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _EnqueueItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Timer2.Enabled = !_Timer2.Enabled;
        }
    }
}
