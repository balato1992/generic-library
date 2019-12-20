using GenericLogger.DataStructures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace GenericLoggerViewerWpf.Views
{
    /// <summary>
    /// Interaction logic for Viewer.xaml
    /// </summary>
    public partial class Viewer : UserControl
    {
        public event Func<DateTime?, DateTime?, List<LogTypes>, string, List<LogInfo>> GetDataFunc;

        private List<LogInfoForView> _Data { get; set; }
        public CollectionViewSource DisplayData { get; set; }

        public Viewer()
        {
            InitializeComponent();
            DataContext = this;

            _Data = new List<LogInfoForView>();

            List<string> logTypes = Enum.GetValues(typeof(LogTypes)).Cast<LogTypes>().ToList().ConvertAll(o => o.ToString());
            searchBox.Initialize(logTypes);
            searchBox.SearchClick += _searchBox_SearchClick;

            DisplayData = new CollectionViewSource();
            DisplayData.Filter += DisplayData_Filter;
            DisplayData.SortDescriptions.Add(new SortDescription("Time", ListSortDirection.Descending));
            DisplayData.Source = _Data;
        }

        public void SetSubNames(List<string> subNames)
        {
            searchBox.SetSubNames(subNames);
        }

        private void _ResetDataAndView(List<LogInfo> list)
        {
            _Data.Clear();
            if (list != null)
            {
                _Data.AddRange(LogInfoForView.ConvertTo(list));
            }
            DisplayData.View.Refresh();
            _SetSummary(DisplayData.View);
        }

        private void _SetSummary(ICollectionView collectionView)
        {
            Dictionary<LogTypes, int> dict = new Dictionary<LogTypes, int>();

            foreach (LogInfo logInfo in collectionView)
            {
                if (!dict.ContainsKey(logInfo.LogType))
                {
                    dict.Add(logInfo.LogType, 0);
                }

                dict[logInfo.LogType] += 1;
            }

            panelSummary.Children.Clear();
            foreach (LogTypes logType in Enum.GetValues(typeof(LogTypes)))
            {
                if (dict.ContainsKey(logType))
                {
                    int value = dict[logType];

                    TextBlock tb = new TextBlock();
                    tb.Margin = new Thickness(2);
                    tb.Padding = new Thickness(4);
                    tb.Foreground = logType.GetLogRowForeColor();
                    tb.Background = logType.GetLogRowColor();
                    tb.Text = logType.ToString() + ": " + value;

                    panelSummary.Children.Add(tb);
                }
            }
        }

        private bool _ValidateText(string itemString, string findTextString)
        {
            return string.IsNullOrWhiteSpace(findTextString) || itemString.ToLower().Contains(findTextString.ToLower());
        }

        #region Events

        #region search

        bool searching = false;
        private void _searchBox_SearchClick()
        {
            if (searching)
            {
                MessageBox.Show("Searching Please Wait");
                return;
            }

            try
            {
                searching = true;

                _ResetDataAndView(null);

                DateTime? start = searchBox.GetStartTime();
                DateTime? end = searchBox.GetEndTime();
                List<LogTypes> logTypes = searchBox.GetCheckedTags();
                string subName = searchBox.GetSubName();

                List<LogInfo> data = GetDataFunc?.Invoke(start, end, logTypes, subName);

                _ResetDataAndView(data);
            }
            finally
            {
                searching = false;
            }
        }

        #endregion search


        private void DisplayData_Filter(object sender, FilterEventArgs e)
        {
            LogInfoForView info = e.Item as LogInfoForView;
            if (info != null)
            {
                bool validTag = _ValidateText(info.Tag, searchBox.GetTag());
                bool validMessage = _ValidateText(info.Message, searchBox.GetMessage());

                if (validTag && validMessage)
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }

        private void ShowAppendItem(object sender, RoutedEventArgs e)
        {
            LogInfoForView logObj = (sender as FrameworkElement).DataContext as LogInfoForView;

            string json = JsonConvert.SerializeObject(logObj.AdditionalItem, Formatting.None);

            MessageBox.Show(json);
        }

        #endregion Events
    }
}
