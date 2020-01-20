using System;
using System.IO;

namespace GenericLogger
{
    public class GLoggerSettings
    {
        public string FolderPath { get; set; }
        public string BackupFilePath => Path.Combine(FolderPath, "Reliable.log");

        public bool FileEncryption { get; private set; }
        public string FileEncryptionKey { get; private set; }
        public string FileEncryptionIV { get; private set; }

        public GLoggerSettings()
        {
            FolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data\Log\");
            FileEncryption = false;
            FileEncryptionKey = null;
            FileEncryptionIV = null;
        }

        public GLoggerSettings(string folderPath) : this()
        {
            FolderPath = folderPath;
        }

        public GLoggerSettings(string folderPath, bool fileEncryption, string fileEncryptionKey, string fileEncryptionIV) : this(folderPath)
        {
            FileEncryption = fileEncryption;
            FileEncryptionKey = fileEncryptionKey;
            FileEncryptionIV = fileEncryptionIV;
        }

        /// <summary>
        /// Please enter parameters by format, key length: 32, iv length: 16
        /// </summary>
        /// <param name="key">Sample: "12345678901234567890123456789012"</param>
        /// <param name="iv">Sample: "1234567890abcdef"</param>
        public void SetEncryption(string key, string iv)
        {
            FileEncryption = true;
            FileEncryptionKey = key;
            FileEncryptionIV = iv;
        }
    }
}