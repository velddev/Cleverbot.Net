using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cleverbot.Net;
using System.Diagnostics;

namespace Cleverbot.Net.Example
{
    class Program
    {
        static void Main(string[] args) => new Program().CleverbotLoop().GetAwaiter().GetResult();

        public async Task CleverbotLoop()
        {
            CleverbotSession cleverbot = new CleverbotSession("your-api-key");

            Console.WriteLine("Hello in the Cleverbot.Net test app, please type your message.\n");

            string msg = Console.ReadLine();
            Console.Write("...");
            CleverbotResponse r = cleverbot.GetResponseAsync(msg).Result;
            Console.CursorLeft = 0;
            Console.WriteLine(r.Response);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                msg = Console.ReadLine();
                Console.Write("...");
                r = r.RespondAsync(msg).Result;
                Console.CursorLeft = 0;
                Console.WriteLine(r.Response); 
            }
        }
    }
}
