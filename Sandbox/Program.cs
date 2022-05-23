using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;

namespace Sandbox
{
    static class Program
    {
        public static int Main(string[] agrs)
        {
            string local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string common = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

            string user = Environment.UserName;

            Console.WriteLine("Local: {0}", local);
            Console.WriteLine("Roming: {0}", roaming);
            Console.WriteLine("Common: {0}", common);
            Console.WriteLine("User name: {0}", user);
            Console.WriteLine();

            MD5? sha = null;
            string hash;
            try
            {
                sha = MD5.Create();
                string rawData = $"{Assembly.GetExecutingAssembly().GetName().Name}{user}Login";
                byte[] temp = Encoding.UTF8.GetBytes(rawData);
                var has = sha.ComputeHash(temp, 0, temp.Length);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in has)
                    stringBuilder.Append(item.ToString("X2"));
                hash = stringBuilder.ToString();
                Console.WriteLine(hash);
                //Console.WriteLine(BitConverter.ToString(has));
            }
            finally
            {
                sha?.Dispose();
            }
            
            string trmplate = "00000000-0000-0000-0000-000000000000";
            //Console.WriteLine(hash.StrFormat(trmplate));
            hash = hash.StrFormat(trmplate);

            //WriteFile(hash, local + "\\" + hash);
            //Console.WriteLine(ReadFile(local + "\\" + hash));

            string path = local + "\\" + hash;

            TailItem tailItem = new TailItem {
                AppName = "My App",
                AppLogin = "My_login",
                AppPass = "My_pass",
                AppUri = "http://my_url",
            };

            string itemStr = JsonSerializer.Serialize(tailItem);

            List<string> list = new List<string>
            {
                $"{hash}",
                itemStr,
            };

            if (File.Exists(path))
                File.SetAttributes(path, File.GetAttributes(path) & ~(FileAttributes.ReadOnly |
                FileAttributes.Hidden | FileAttributes.System));

            File.WriteAllLines(path, list);

            File.SetAttributes(local + "\\" + hash, File.GetAttributes(path) | 
                (FileAttributes.Hidden | FileAttributes.System));


            Console.WriteLine("\nFrom file:");
            //IEnumerable<string> lines = File.ReadLines(local + "\\" + hash).Skip(0).Take(1);
            IEnumerable<string> lines = File.ReadLines(local + "\\" + hash).Skip(0).Take(2);

            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

            return 0;
        }

        public static void WriteFile(string data, string fullFileName)
        {
            FileInfo fileInfo = new FileInfo(fullFileName);
            //if (!fileInfo.Exists)
            //    return;
            using (FileStream fs = File.Open(fileInfo.FullName, FileMode.Append, FileAccess.Write))
            {
                File.SetAttributes(fileInfo.FullName, FileAttributes.Hidden | FileAttributes.System);

                byte[] buffer = Encoding.UTF8.GetBytes(data + Environment.NewLine);
                fs.Write(buffer, 0, buffer.Length);
            }
        }

        public static string ReadFile(string fullFileName)
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

        public static int Crypto()
        {
            using (Aes crypto = Aes.Create())
            {
                Console.WriteLine("Pleas enter password string:");
                string? psw = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(psw))
                    return -1;

                //byte[] key = new byte[256];
                byte[] vector;


                byte[] solt = Encoding.Unicode.GetBytes(RandKeyGen.Generate(128));

                vector = Encoding.Unicode.GetBytes(RandKeyGen.Generate(128));

                PasswordDeriveBytes pdb = new PasswordDeriveBytes(psw, solt);

                //byte[] key = pdb.CryptDeriveKey("TripleDES", "SHA1", 192, vector);

                byte[] key2 = pdb.GetBytes(32);
                vector = pdb.GetBytes(crypto.BlockSize / 8);

                Console.WriteLine("Key len: {0}\nKey: ->{1}<-", key2.Length, Encoding.ASCII.GetString(key2));

                Console.WriteLine("Block size: {0}", crypto.BlockSize);

                crypto.KeySize = 256;
                crypto.Key = key2;
                crypto.IV = vector;

                Console.WriteLine("Pleas enter data string:");
                string? data = Console.ReadLine();

                byte[] cryptoData = Encrypt(ref data, crypto.Key, crypto.IV);
                Console.WriteLine("Crypto: {0}", Encoding.UTF8.GetString(cryptoData));

                Console.WriteLine("Decrypto: {0}", Decrypt(ref cryptoData, crypto.Key, crypto.IV));
            }
            return 0;
        }

        private static byte[] Encrypt(ref string data, byte[] key, byte[] vector)
        {
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("data");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (vector == null || vector.Length <= 0)
                throw new ArgumentNullException("vector");

            byte[]? result = null;

            using (Aes crypto = Aes.Create())
            {
                crypto.Key = key;
                crypto.IV = vector;

                ICryptoTransform encryptor = crypto.CreateEncryptor(crypto.Key, crypto.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(data);
                       
                    }
                    result = ms.ToArray();
                }
                
            }

            return result;
        }

        private static string Decrypt(ref byte[] cryptoData, byte[] key, byte[] vector)
        {
            if (cryptoData == null || cryptoData.Length <= 0)
                throw new ArgumentNullException("data");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (vector == null || vector.Length <= 0)
                throw new ArgumentNullException("vector");

            string? result = null;

            using (Aes crypto = Aes.Create())
            {
                crypto.Key = key;
                crypto.IV = vector;

                ICryptoTransform encryptor = crypto.CreateDecryptor(crypto.Key, crypto.IV);

                using (MemoryStream ms = new MemoryStream(cryptoData))
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Read))
                using (StreamReader sr = new StreamReader(cs))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }
    }

    [Serializable]
    public class TailItem
    {
        public string AppName { get; set; }
        public string AppLogin { get; set; }
        public string AppPass { get; set; }
        public string? AppUri { get; set; }
    }
}
