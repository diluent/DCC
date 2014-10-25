using System;
using System.IO;

namespace Common.Writer
{
    public class LogWriter : IWriter
    {

        private readonly string _logPath;
        private readonly string _logPrefix;

        public LogWriter(string logPrefix, string logPath)
        {
            _logPrefix = logPrefix;
            _logPath = logPath;
        }

        public void Write(string msg)
        {
            try
            {
                using (var sw = File.AppendText(
                Path.Combine(_logPath
                    , string.Format("{0:yyMMdd}", DateTime.UtcNow) +
                        "_" + _logPrefix + ".log")))
                {
                    sw.WriteLine(msg);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception) {}
        }
    }
}
