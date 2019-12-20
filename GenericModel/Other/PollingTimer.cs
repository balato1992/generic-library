using System;
using System.Timers;

namespace GenericModel.Other
{
    public class PollingTimer
    {
        public string Tag => _Tag;
        public double Interval => _Timer.Interval;
        public bool TimerEnabled => _Timer.Enabled;
        public int CountOfElapsed { get; private set; }

        protected Timer _Timer { get; set; }
        protected string _Tag { get; set; }
        protected event Action _PoolingAction;

        // avoid timer event excute at same time
        protected object _ElapsedLocker = new object();
        private bool _IsRunning { get; set; }



        /// <summary>
        /// Return Tag and Exception
        /// </summary>
        public event Action<string, Exception> ElapsedException;

        public PollingTimer(string tag, int interval, params Action[] actions)
        {
            _Tag = tag;
            CountOfElapsed = 0;

            _Timer = new Timer();
            _Timer.Enabled = false;
            _Timer.Elapsed += timeElapsedEvent;
            _Timer.Interval = interval;

            if (actions != null)
            {
                foreach (Action action in actions)
                {
                    _PoolingAction += action;
                }
            }
        }

        public void StartTimer()
        {
            _Timer.Enabled = true;
        }
        public void StopTimer()
        {
            _Timer.Enabled = false;
        }

        private void timeElapsedEvent(object source, ElapsedEventArgs e)
        {
            lock (_ElapsedLocker)
            {
                if (_IsRunning)
                {
                    return;
                }
                _IsRunning = true;
            }

            try
            {
                _PoolingAction?.Invoke();
            }
            catch (Exception ex)
            {
                ElapsedException?.Invoke(Tag, ex);
            }
            finally
            {
                lock (_ElapsedLocker)
                {
                    _IsRunning = false;
                }

                CountOfElapsed += 1;
                if (CountOfElapsed == int.MaxValue)
                {
                    CountOfElapsed = 0;
                }
            }
        }
    }
}
