using GenericWinForm4_5.Views;
using System;
using System.Windows.Forms;

namespace MyModelSample.View
{
    public class LoadingBar4_5
    {
        public static void Test(Control targetForm)
        {
            try
            {
                DoSomethingWithLoadingForm dswlf = new DoSomethingWithLoadingForm(
                    "DoSomethingWithLoadingForm", "DoSomethingDelegate",
                    targetForm,
                    delegate
                    {
                        string k = "";
                        for (int i = 0; i < 5000000; i++)
                        {
                            k = i.ToString();
                        }
                        System.Diagnostics.Debug.WriteLine(k);
                        //throw new Exception("SomeException");
                    });
                dswlf.Start();

                if (dswlf.ExceptionDuringLoading != null)
                {
                    throw dswlf.ExceptionDuringLoading;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}