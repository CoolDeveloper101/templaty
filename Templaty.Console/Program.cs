using System;
using System.Collections.Generic;
using System.IO;

namespace Templaty.console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Argument> parsedArgs = new List<Argument>();
            foreach (var arg in args)
            {
                parsedArgs.Add(new Argument(arg));
            }

            var command = parsedArgs[0];
            if (parsedArgs.Count == 1 && command.Type == ArgumentType.Option)
            {
                if (command.Command == "help" || command.Command == "h")
                    Console.WriteLine(File.ReadAllText("./HelpFiles/help.txt"));
            }
            // Console.WriteLine($"[{string.Join(", ", parsedArgs)}]");
        }
    }
}
