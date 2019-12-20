using System;

namespace GenericModel.Other
{
    public class TimeRangeHelper
    {
        private DateTime StartTime = DateTime.Now;
        private DateTime EndTime = DateTime.Now;
        
        public void Start()
        {
            StartTime = DateTime.Now;
        }
        public void End()
        {
            EndTime = DateTime.Now;
        }
        public string GetTimeSpan()
        {
            return ((TimeSpan)(EndTime - StartTime)).TotalSeconds.ToString();
        }
    }
}
