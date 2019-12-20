using GenericModel.Other;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MyModelSample.View
{
    public partial class PollingTimerSample : Form
    {
        PollingTimer pollingTime { get; set; }

        public PollingTimerSample()
        {
            InitializeComponent();


            //new PollingTimer("Status", 100, () =>
            //{
            //    MethodInvoker methodInvokerDelegate = () => { labelStatus.Text = "Status: " + pollingTime?.Status; };

            //    if (InvokeRequired)
            //        Invoke(methodInvokerDelegate);
            //    else
            //        methodInvokerDelegate();
            //}).StartTimer();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            pollingTime.StartTimer();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            pollingTime.StopTimer();
        }

        int count = 1;
        private void btnNew_Click(object sender, EventArgs e)
        {

            pollingTime = new PollingTimer("Taggg", (int)nudInterval.Value, () =>
            {
                int ccount = count++;

                MethodInvoker methodInvokerDelegateStart = () => { richTextBox1.Text += "Start" + ccount + "\r\n"; };
                MethodInvoker methodInvokerDelegateEnd = () => { richTextBox1.Text += "End" + ccount + "\r\n"; };

                if (InvokeRequired)
                    Invoke(methodInvokerDelegateStart);
                else
                    methodInvokerDelegateStart();

                Thread.Sleep((int)nudSleep.Value);

                if (InvokeRequired)
                    Invoke(methodInvokerDelegateEnd);
                else
                    methodInvokerDelegateEnd();
            });
            pollingTime.ElapsedException += PollingTime_ElapsedException;
        }

        private void PollingTime_ElapsedException(string arg1, Exception arg2)
        {

        }
    }
}