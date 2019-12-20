using GenericModel.Other;
using GenericWinForm.Views.GenericDataGridViews;
using System.Collections.Generic;

namespace MyModelSample.View._styles
{
    public class SampleTestClass : ICheckedItemInfo
    {
        public string Key { get; set; }
        public bool IsChecked { get; set; }
        public string String1 { get; set; }
        public string String2 { get; set; }
        public string String3 { get; set; }

        public SampleTestClass()
        {
            Key = string.Empty;
            IsChecked = false;
            String1 = string.Empty;
            String2 = string.Empty;
            String3 = string.Empty;
        }

        public SampleTestClass(string strKey, bool bIsChecked, string strString1, string strString2, string strString3)
        {
            Key = strKey;
            IsChecked = bIsChecked;
            String1 = strString1;
            String2 = strString2;
            String3 = strString3;
        }

        override public string ToString()
        {
            return string.Format("{0}: {1}, {2}, {3}, {4}", Key, IsChecked, String1, String2, String3);
        }

        public static List<SampleTestClass> MakeSerialList(int count)
        {
            List<SampleTestClass> listData = new List<SampleTestClass>();

            for (int i = 0; i < count; i++)
            {
                listData.Add(new SampleTestClass("key" + i, false, i + "_str1", i + "_str2", i + "_str3"));
            }

            return listData;
        }

        public static List<SampleTestClass> MakeRandonList()
        {
            List<SampleTestClass> listData = new List<SampleTestClass>();

            int dataCount = RandomHelper.StaticRandom.Next(5, 10);
            for (int i = 0; i < dataCount; i++)
            {
                listData.Add(SampleTestClass.MakeRandonData());
            }

            return listData;
        }

        public static SampleTestClass MakeRandonData()
        {
            SampleTestClass randonObj = new SampleTestClass(
                "Key: " + RandomHelper.StaticRandom.Next(),
                RandomHelper.StaticRandom.Next(2) == 1,
                "String1: " + RandomHelper.StaticRandom.Next(),
                "String2: " + RandomHelper.StaticRandom.Next(),
                "String3: " + RandomHelper.StaticRandom.Next());

            return randonObj;
        }
    }
}