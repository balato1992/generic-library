using GenericWinForm.Views;
using System;
using System.Windows.Forms;

namespace MyModelSample.View.GenericWinFormSample
{
    public class LoadingBar
    {
        public static void Test()
        {
            try
            {
                LoadingDialogForm ldf = new LoadingDialogForm(
                    "LoadingDialogForm", "DoSomething",
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
                ldf.ShowDialog();

                if (ldf.ExceptionDuringLoading != null)
                {
                    throw ldf.ExceptionDuringLoading;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}