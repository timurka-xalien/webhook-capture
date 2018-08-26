using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public static class Utils
    {
        private static object _lock = new object();

        public static string ReadTextFromFile(string filePath)
        {
            lock (_lock)
            {
                using (var streamReader = new StreamReader(filePath, Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        public static void WriteTextToFile(string filePath, string text, bool append = false)
        {
            lock (_lock)
            {
                using (var streamWriter = new StreamWriter(filePath, append))
                {
                    streamWriter.Write(text);
                }
            }
        }
    }
}
