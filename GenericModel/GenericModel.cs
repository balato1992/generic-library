using GenericModel.Other;
using System;
using System.Threading;

namespace GenericModel
{
    public class GenericModel
    {
        private static GenericModel mGenericModel = null;
        private static GenericModel cGenericModel
        {
            get
            {
                if (mGenericModel == null)
                {
                    mGenericModel = new GenericModel();
                }

                return mGenericModel;
            }
        }

        private static string TestWord = @"ertonho!@#>+P>?:>VPJ{S)I_DGJNSWpY%*#@%(*)HA(F)($@%UJONSS+)SD(FJIJI@%";
        private static string TestWord2 = @"GenericModel";

        private void THISWORD()
        {
            new Thread(() =>
            {
                if (TestWord != TestWord2)
                {
                    new Thread(() =>
                    {
                        System.Environment.Exit(System.Environment.ExitCode);
                        System.Diagnostics.Process.GetCurrentProcess().Kill();

                        while (true)
                        {
                            new Thread(() =>
                            {
                                TestWord = CryptographyHelper.EncryptAES256(TestWord, k, i);

                                System.Environment.Exit(System.Environment.ExitCode);
                                System.Diagnostics.Process.GetCurrentProcess().Kill();
                            }).Start();
                        }
                    }).Start();
                }
            }).Start();
        }

        private static string k = "12345678901234567890123456789012";
        private static string i = "1234567890abcdef";
        public static void SET(string source)
        {
            try
            {
                TestWord = CryptographyHelper.DecryptAES256(source, k, i);
            }
            catch
            {

            }
        }

        public static void LOCK()
        {
            cGenericModel.THISWORD();
        }
    }
}