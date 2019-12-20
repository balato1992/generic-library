using System;
using System.IO;
using System.Linq;

namespace GenericModel.File
{
    public static class FileHelper
    {
        private static readonly Object _LogLocker = new Object();

        public static void Write(string data, string filePath)
        {
            lock (_LogLocker)
            {
                FilePathHelper.CreateFileAndFolder(filePath);

                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(data);
                }
            }
        }

        public static void WriteLine(string log, string filePath)
        {
            lock (_LogLocker)
            {
                FilePathHelper.CreateFileAndFolder(filePath);

                // This text is always added, making the file longer over time
                // if it is not deleted.
                using (StreamWriter sw = System.IO.File.AppendText(filePath))
                {
                    sw.WriteLine(log);
                }
            }
        }

        public static void WriteLineCover(string log, string filePath)
        {
            lock (_LogLocker)
            {
                FilePathHelper.CreateFileAndFolder(filePath);

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(log);
                }
            }
        }

        public static string Read(string fileName)
        {
            string dataToEnd = null;

            using (StreamReader sr = new StreamReader(fileName))
            {
                dataToEnd = sr.ReadToEnd();
            }

            return dataToEnd;
        }

        public static void FileSizeControl(string filePath, long sizeLimitInBytes)
        {
            long fileLength = new System.IO.FileInfo(filePath).Length;

            if (fileLength > sizeLimitInBytes)
            {
                var lines = System.IO.File.ReadAllLines(filePath);
                System.IO.File.WriteAllLines(filePath, lines.Skip(lines.Length / 10).ToArray());
            }
        }

        // reference: http://windowsapptutorials.com/code-snippets/formatting-a-valid-file-name-in-c-sharp/
        public static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }
    }
}
