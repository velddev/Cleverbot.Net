using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbot.Net
{
    public class Cleverbot
    {
        private string ApiKey = "";

        public Cleverbot(string apikey)
        {
            ApiKey = apikey;
        }

        /// <summary>
        /// Send a message to cleverbot and get a response to it.
        /// </summary>
        /// <param name="message">your message sent to cleverbot</param>
        /// <returns>response from the cleverbot.com api</returns>
        public CleverbotResponse GetResponse(string message)
        {
            return CleverbotResponse.Create(message, "", ApiKey);
        }

        /// <summary>
        /// Send a message to cleverbot asynchronously and get a response.
        /// </summary>
        /// <param name="message">your message sent to cleverbot</param>
        /// <returns></returns>
        public async Task<CleverbotResponse> GetResponseAsync(string message)
        {
            return await CleverbotResponse.CreateAsync(message, "", ApiKey);
        }

        /// <summary>
        /// Send a message to cleverbot asynchronously and get a response.
        /// </summary>
        /// <param name="message">your message sent to cleverbot</param>
        /// <param name="result">result delegate </param>
        /// <returns></returns>
        public void GetResponseAsync(string message, Action<CleverbotResponse> result)
        {
            CleverbotResponse.CreateAsync(message, "", ApiKey, result);
        }
    }
}
