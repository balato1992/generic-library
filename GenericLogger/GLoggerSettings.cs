using System;
using System.IO;

namespace GenericLogger
{
    public class GLoggerSettings
    {
        public bool FileEncryption { get; set; }
        public string FileEncryptionKey { get; set; }
        public string FileEncryptionIV { get; set; }
        public string FolderPath { get; set; }

        public GLoggerSettings()
        {
            FileEncryption = false;
            FileEncryptionKey = "12345678901234567890123456789012";
            FileEncryptionIV = "1234567890abcdef";
            FolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Log\");
        }
    }
}