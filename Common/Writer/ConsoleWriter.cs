using System;

namespace Common.Writer
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
