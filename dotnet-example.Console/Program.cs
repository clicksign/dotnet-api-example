using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using dotnet_example.Core;

namespace dotnet_example.Console
{
    class Program : ClickSignExampleCore
    {
        static void Main(string[] args)
        {
            var self = new Program();
            self.StartAllMethods();
            System.Console.ReadKey();
        }

        public override void Send(string message)
        {
            System.Console.WriteLine(message);
        }

    }
}
