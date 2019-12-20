using GenericLogger;
using GenericLogger.DataStructures;
using GenericModel.Other;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenericLoggerViewerWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer _Timer { get; set; }
        private DateTime _RefreshTime { get; set; }
        private GLoggerModel _Model1 { get; set; }
        private GLoggerModel _Model2 { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            tbPath1.Text = Properties.Settings.Default.Path1;
            cbPath1En.IsChecked = Properties.Settings.Default.Path1Encryption;
            tbPath2.Text = Properties.Settings.Default.Path2;
            cbPath2En.IsChecked = Properties.Settings.Default.Path2Encryption;

            viewer.GetDataFunc += _GetData;

            _Timer = new Timer(1000);
            _Timer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                if (_RefreshTime < DateTime.Now.AddMinutes(-30))
                {
                    Dispatcher.Invoke(() =>
                    {
                        gridValidation.Visibility = Visibility.Visible;
                    });
                }
            };
        }

        private List<LogInfo> _GetData(DateTime? dtStart, DateTime? dtEnd, List<LogTypes> logTypes, string subName)
        {
            int maxCount = 500000;

            List<LogInfo> list = new List<LogInfo>();
            _GetData2(list, _Model1, dtStart, dtEnd, logTypes, subName, maxCount + 5);
            _GetData2(list, _Model2, dtStart, dtEnd, logTypes, subName, maxCount + 5);

            return list;
        }
        private void _GetData2(
            List<LogInfo> list,
            GLoggerModel model,
            DateTime? dtStart, DateTime? dtEnd, List<LogTypes> logTypes, string subName, int maxCount)
        {
            List<LogInfo> dataLoaded = model?.LoadFile(dtStart, dtEnd, logTypes, subName, maxCount + 5);

            if (dataLoaded != null)
            {
                if (dataLoaded.Count > maxCount)
                {
                    MessageBox.Show("Log count over: " + maxCount);
                }

                list.AddRange(dataLoaded);
            }
        }

        private GLoggerModel _GetModel(string path, bool encryption)
        {
            GLoggerModel model = null;
            if (Directory.Exists(path))
            {
                model = new GLoggerModel((object value) =>
                {
                    return JsonConvert.SerializeObject(value, Formatting.None);
                }, (string value, Type type) =>
                {
                    return JsonConvert.DeserializeObject(value, type);
                });
                model.Setting.FileEncryption = encryption;
                model.Setting.FolderPath = path;
            }
            return model;
        }
        private List<string> _GetSubNames(List<string> l1, List<string> l2)
        {
            HashSet<string> names = new HashSet<string>();
            if (l1 != null)
            {
                foreach (var i in l1)
                {
                    names.Add(i);
                }
            }
            if (l2 != null)
            {
                foreach (var i in l2)
                {
                    names.Add(i);
                }
            }

            return names.ToList().OrderBy(o => o).ToList();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string license = tbLicense.Text;
            string path1 = tbPath1.Text;
            bool path1Encryption = cbPath1En.IsChecked == true;
            string path2 = tbPath2.Text;
            bool path2Encryption = cbPath2En.IsChecked == true;

            Properties.Settings.Default.Path1 = path1;
            Properties.Settings.Default.Path1Encryption = path1Encryption;
            Properties.Settings.Default.Path2 = path2;
            Properties.Settings.Default.Path2Encryption = path2Encryption;
            Properties.Settings.Default.Save();

            if (license == CryptographyHelper.CreateMD5(DateTime.Now.ToString("yyyyMMdd")))
            {
                tbLicense.Text = null;

                _Model1 = _GetModel(path1, path1Encryption);
                _Model2 = _GetModel(path2, path2Encryption);

                List<string> subNames = _GetSubNames(_Model1?.GetSubNames(), _Model2?.GetSubNames());
                viewer.SetSubNames(subNames);

                _Timer.Enabled = true;
                _RefreshTime = DateTime.Now;
                gridValidation.Visibility = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("License Failed");
            }
        }
    }
}
