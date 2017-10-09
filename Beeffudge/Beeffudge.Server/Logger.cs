using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeffudge.Server
{
    public class Logger
    {
        const string fileName = "ConsoleLog.txt";
        FileStream fs;
        StreamWriter writer;
        string _log = string.Empty;

        public Logger()
        {
            fs = new FileStream(fileName, FileMode.Create);
            writer = new StreamWriter(fs);
        }

        public void LogToConsole(string subject, string message)
        {
            _log = string.Format("{0}: {1}", subject, message);
            Console.WriteLine(_log);
            WriteToFile(_log);
        }

        private void WriteToFile(string log)
        {
            writer.Write(log);
        }

        public void CloseFile() {
            writer.Close();
            fs.Close();
        }

    }
}
