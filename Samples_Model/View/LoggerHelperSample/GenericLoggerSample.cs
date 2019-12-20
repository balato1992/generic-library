using GenericLogger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyModelSample.View.LoggerHelperSample
{
    public partial class GenericLoggerSample : Form
    {
        internal static GLoggerModel GLogger { get; set; }

        public GenericLoggerSample()
        {
            InitializeComponent();

            GLogger = new GLoggerModel(delegate (object value)
            {
                return JsonConvert.SerializeObject(value, Formatting.None);
            }, JsonConvert.DeserializeObject);
            GLogger.Setting.FileEncryption = true;

        }
    }
}
