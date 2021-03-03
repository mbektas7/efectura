using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Efectura.Helpers
{
    public static class Functions
    {
        public static void WriteLog(string strLog)
        {
            var exePath = new Uri(System.Reflection. Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            string logFilePath = new FileInfo(exePath).DirectoryName + "\\Log - " + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    log.WriteLine(strLog);
                }
            }
        }
    }
}
