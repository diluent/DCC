using System;

namespace Common.Writer
{
    public class LogAndConsoleWriter : IWriter
    {
        private readonly LogWriter _logWriter;
        private readonly ConsoleWriter _consoleWriter;
        public LogAndConsoleWriter(string logPrefix, string logPath)
        {
            _logWriter = new LogWriter(logPrefix, logPath);
            _consoleWriter = new ConsoleWriter();
        }

        public void Write(string str)
        {
            _logWriter.Write(str);
            _consoleWriter.Write(str);
        }
    }
}
