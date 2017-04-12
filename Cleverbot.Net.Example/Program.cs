using System;
using System.Threading.Tasks;

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
            CleverbotResponse r = await cleverbot.GetResponseAsync(msg);
            Console.CursorLeft = 0;
            Console.WriteLine(r.Response);

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                msg = Console.ReadLine();
                Console.Write("...");
                r = await r.RespondAsync(msg);
                Console.CursorLeft = 0;
                Console.WriteLine(r.Response);
            }
        }
    }
}
