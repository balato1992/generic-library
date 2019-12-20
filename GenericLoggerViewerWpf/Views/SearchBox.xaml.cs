using GenericLogger.DataStructures;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GenericLoggerViewerWpf.Views
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl
    {
        public event Action SearchClick;

        public SearchBox()
        {
            InitializeComponent();
        }

        public void Initialize(List<string> logTypes)
        {
            timeStart.Value = DateTime.Now.AddSeconds(-10);

            foreach (string logType in logTypes)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.IsChecked = true;
                checkBox.Content = logType;

                wrapPanelTags.Children.Add(checkBox);
            }
        }
        public void SetSubNames(List<string> subNames)
        {
            object selectedObj = cbSubName.SelectedItem;

            cbSubName.Items.Clear();
            if (subNames != null)
            {
                cbSubName.Items.Add("");
                foreach (string subName in subNames)
                {
                    cbSubName.Items.Add(subName);
                }
                cbSubName.SelectedItem = selectedObj;
            }
        }

        public DateTime? GetStartTime()
        {
            return timeStart.Value;
        }
        public DateTime? GetEndTime()
        {
            return timeEnd.Value;
        }
        public string GetSubName()
        {
            return cbSubName.Text;
        }
        public string GetTag()
        {
            return tbTag.Text;
        }
        public string GetMessage()
        {
            return tbMessage.Text;
        }
        public List<LogTypes> GetCheckedTags()
        {
            List<LogTypes> list = new List<LogTypes>();

            foreach (UIElement child in wrapPanelTags.Children)
            {
                CheckBox checkBox = child as CheckBox;

                if (checkBox != null && checkBox.IsChecked == true)
                {
                    string content = checkBox.Content as string;

                    LogTypes logType = LogTypes.Info;

                    if (Enum.TryParse(content, out logType))
                    {
                        list.Add(logType);
                    }
                }
            }

            return list;
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            SearchClick?.Invoke();
        }

    }
}
