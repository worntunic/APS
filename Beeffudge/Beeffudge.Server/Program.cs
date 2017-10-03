using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeroMQ;

namespace Beeffudge.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connect();
            MyServer myServer = new MyServer();
            myServer.Start();
        }
    }
}