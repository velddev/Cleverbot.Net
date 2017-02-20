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
            Cleverbot cleverbot = new Cleverbot("your-api-key");

            Console.WriteLine("Hello in the Cleverbot.Net test app, please type your message.\n");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;

                string msg = Console.ReadLine();

                cleverbot.GetResponseAsync(msg, x =>
                {
                    Console.CursorLeft = 0;

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(x.Response);
                });

                Console.Write("...");
            }
        }
    }
}
