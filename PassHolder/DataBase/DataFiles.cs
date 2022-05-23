using PassHolder.Infrastructure;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PassHolder.DataBase
{
    public static class DataFiles
    {
        #region Private properties

        private readonly static string _path = "";
        private readonly static string _fileName;
        private const string template = "########-####-####-####-############";

        #endregion

        #region Public properties
        internal static string Hash { get; private set; }
        internal static bool IsFileExist { get; private set; }
        #endregion

        static DataFiles()
        {
            string data = $"{Assembly.GetExecutingAssembly().GetName().Name}{ Environment.UserName}Login";
            string hash = Utils.GetHash(ref data);

            Hash = hash;
            _fileName = hash.StrFormat(template);
            _path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{_path}\\{_fileName}";
        }

        internal static void WriteLinesToFile(ref IEnumerable<string> data)
        {
            if (IsDataFileExists())
                File.SetAttributes(_path, File.GetAttributes(_path) & ~(FileAttributes.ReadOnly |
                    FileAttributes.Hidden | FileAttributes.System));

            File.WriteAllLines(_path, data);

            File.SetAttributes(_path, File.GetAttributes(_path) |
                (FileAttributes.Hidden | FileAttributes.System));
        }

        internal static IEnumerable<string> ReadAllLinesFromFile()
        {
            if (IsDataFileExists())
                return File.ReadLines(_path);
            return new List<string>();
        }

        internal static IEnumerable<string> ReadLinesFromFile(int from, int count)
        {
            if (IsDataFileExists())
                return File.ReadLines(_path).Skip(from - 1).Take(count);
            return new List<string>();
        }

        internal static bool IsDataFileExists()
        {
            FileInfo fileInfo = new FileInfo(_path);
            IsFileExist = fileInfo.Exists;
            return IsFileExist;
        }

        /// <summary>
        /// Write file from bytes
        /// </summary>
        /// <param name="data">Data for write</param>
        /// <param name="fullFileName">Path for file</param>
        internal static void WriteFile(string data, string fullFileName)
        {
            FileInfo fileInfo = new FileInfo(fullFileName);
            //if (!fileInfo.Exists)
            //    return;
            using (FileStream fs = File.Open(fileInfo.FullName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                File.SetAttributes(fileInfo.FullName, FileAttributes.Hidden | FileAttributes.System);

                byte[] buffer = Encoding.UTF8.GetBytes(data);
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        /// <summary>
        /// Read file to bytes
        /// </summary>
        /// <param name="fullFileName">Path for file</param>
        /// <returns></returns>
        internal static string ReadFile(string fullFileName)
        {
            FileInfo fileInfo = new FileInfo(fullFileName);
            string result;
            using (FileStream fs = File.Open(fileInfo.FullName, FileMode.Open))
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                result = Encoding.UTF8.GetString(buffer);
            }
            return result;
        }

        private static string StrFormat(this string word, string template)
        {
            StringBuilder sb = new StringBuilder();
            int offset = 0;
            for (int i = 0; i < template.Length; i++)
            {
                var item = template[i];
                if (item == template[0])
                    sb.Append(word[i - offset]);
                else
                {
                    sb.Append('-');
                    offset++;
                }
            }
            return sb.ToString();
        }
    }
}
