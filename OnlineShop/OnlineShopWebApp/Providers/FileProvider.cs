using System.IO;

namespace OnlineShopWebApp.Providers
{
    public static class FileProvider
    {
        public static bool SaveInfo(string filePath, string data, bool isAppend = false)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, isAppend))
                {
                    sw.WriteLine(data);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static string GetInfo(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
