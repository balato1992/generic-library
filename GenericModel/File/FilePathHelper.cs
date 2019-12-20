using System;
using System.IO;

namespace GenericModel.File
{
    public static class FilePathHelper
    {
        public static void CreateFileAndFolder(string fullpath)
        {

            try
            {
                string directoryPath = Path.GetDirectoryName(fullpath);

                if (directoryPath != null && directoryPath != string.Empty && !Directory.Exists(directoryPath))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(directoryPath);
                }

                string fileName = Path.GetFileName(fullpath);

                // This text is added only once to the file.
                if (fileName != null && fileName != string.Empty && !System.IO.File.Exists(fullpath))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = System.IO.File.CreateText(fullpath))
                    {
                        // Do nothing
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Create File or Folder Error", e);
            }
        }

        public static string ReplaceInvaildChars(string str, string newValue)
        {
            string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());

            foreach (char c in invalid)
            {
                str = str.Replace(c.ToString(), newValue);
            }

            return str;
        }

        public static bool CheckVaild(string path)
        {
            return path != null && path.IndexOfAny(Path.GetInvalidPathChars()) == -1;
        }
    }
}
