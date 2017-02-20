using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net;

namespace Cleverbot.Net
{
    public class CleverbotResponse
    {
        #region internals

        [JsonProperty("cs")]
        internal string cs;

        [JsonProperty("interaction_count")]
        internal string interactionCount;

        [JsonProperty("input")]
        internal string inputMessage;

        [JsonProperty("predicted_input")]
        internal string predictedInputMessage;

        [JsonProperty("accuracy")]
        internal string accuracy;

        [JsonProperty("output_label")]
        internal string outputLabel;

        [JsonProperty("output")]
        internal string output;

        [JsonProperty("conversation_id")]
        internal string conversationId;

        [JsonProperty("errorline")]
        internal string errorLine;

        [JsonProperty("database_version")]
        internal string databaseVersion;

        [JsonProperty("software_version")]
        internal string softwareVersion;

        [JsonProperty("time_taken")]
        internal string timeTaken;

        [JsonProperty("random_number")]
        internal string randomNumber;

        [JsonProperty("time_second")]
        internal string timeSeconds;

        [JsonProperty("time_minute")]
        internal string timeMinutes;

        [JsonProperty("time_hour")]
        internal string timeHours;

        [JsonProperty("time_day_of_week")]
        internal string timeDayOfWeek;

        [JsonProperty("time_day")]
        internal string timeDays;

        [JsonProperty("time_month")]
        internal string timeMonths;

        [JsonProperty("time_year")]
        internal string timeYears;

        [JsonProperty("reaction")]
        internal string reaction;

        [JsonProperty("reaction_tone")]
        internal string reactionTone;

        [JsonProperty("emotion")]
        internal string emotion;

        [JsonProperty("emotion_tone")]
        internal string emotionTone;

        [JsonProperty("clever_accuracy")]
        internal string cleverAccuracy;

        [JsonProperty("clever_output")]
        internal string cleverOutput;

        [JsonProperty("clever_match")]
        internal string cleverMatch;

        [JsonProperty("time_elapsed")]
        internal string timeElapsed;

        [JsonProperty("filtered_input")]
        internal string filteredInput;

        [JsonProperty("reaction_degree")]
        internal string reactionDegree;

        [JsonProperty("emotion_degree")]
        internal string emotionDegree;

        [JsonProperty("reaction_values")]
        internal string reactionValues;

        [JsonProperty("emotion_values")]
        internal string emotionValues;

        [JsonProperty("callback")]
        internal string callback;

        // TODO: convince Rollo to make these a array/list in json
        [JsonProperty("interaction_1")]
        internal string interaction1;

        [JsonProperty("interaction_2")]
        internal string interaction2;

        [JsonProperty("interaction_3")]
        internal string interaction3;

        [JsonProperty("interaction_4")]
        internal string interaction4;

        [JsonProperty("interaction_5")]
        internal string interaction5;

        [JsonProperty("interaction_6")]
        internal string interaction6;

        [JsonProperty("interaction_7")]
        internal string interaction7;

        [JsonProperty("interaction_8")]
        internal string interaction8;

        [JsonProperty("interaction_9")]
        internal string interaction9;

        [JsonProperty("interaction_10")]
        internal string interaction10;

        [JsonProperty("interaction_11")]
        internal string interaction11;

        [JsonProperty("interaction_12")]
        internal string interaction12;

        [JsonProperty("interaction_13")]
        internal string interaction13;

        [JsonProperty("interaction_14")]
        internal string interaction14;

        [JsonProperty("interaction_15")]
        internal string interaction15;

        [JsonProperty("interaction_16")]
        internal string interaction16;

        [JsonProperty("interaction_17")]
        internal string interaction17;

        [JsonProperty("interaction_18")]
        internal string interaction18;

        [JsonProperty("interaction_19")]
        internal string interaction19;

        [JsonProperty("interaction_20")]
        internal string interaction20;

        [JsonProperty("interaction_21")]
        internal string interaction21;

        [JsonProperty("interaction_22")]
        internal string interaction22;

        [JsonProperty("interaction_23")]
        internal string interaction23;

        [JsonProperty("interaction_24")]
        internal string interaction24;

        [JsonProperty("interaction_25")]
        internal string interaction25;

        [JsonProperty("interaction_26")]
        internal string interaction26;

        [JsonProperty("interaction_27")]
        internal string interaction27;

        [JsonProperty("interaction_28")]
        internal string interaction28;

        [JsonProperty("interaction_29")]
        internal string interaction29;

        [JsonProperty("interaction_30")]
        internal string interaction30;

        [JsonProperty("interaction_31")]
        internal string interaction31;

        [JsonProperty("interaction_32")]
        internal string interaction32;

        [JsonProperty("interaction_33")]
        internal string interaction33;

        [JsonProperty("interaction_34")]
        internal string interaction34;

        [JsonProperty("interaction_35")]
        internal string interaction35;

        [JsonProperty("interaction_36")]
        internal string interaction36;

        [JsonProperty("interaction_37")]
        internal string interaction37;

        [JsonProperty("interaction_38")]
        internal string interaction38;

        [JsonProperty("interaction_39")]
        internal string interaction39;

        [JsonProperty("interaction_40")]
        internal string interaction40;

        [JsonProperty("interaction_41")]
        internal string interaction41;

        [JsonProperty("interaction_42")]
        internal string interaction42;

        [JsonProperty("interaction_43")]
        internal string interaction43;

        [JsonProperty("interaction_44")]
        internal string interaction44;

        [JsonProperty("interaction_45")]
        internal string interaction45;

        [JsonProperty("interaction_46")]
        internal string interaction46;

        [JsonProperty("interaction_47")]
        internal string interaction47;

        [JsonProperty("interaction_48")]
        internal string interaction48;

        [JsonProperty("interaction_49")]
        internal string interaction49;

        [JsonProperty("interaction_50")]
        internal string interaction50;

        [JsonProperty("interaction_1_other")]
        internal string interaction1other;

        internal List<string> interactions = new List<string>();

        #endregion

        public string ConversationId
        {
            get
            {
                return cs;
            }
        }
        public string Response
        {
            get
            {
                return output;
            }
        }

        private string apikey;

        internal static CleverbotResponse Create(string message, string conversationId, string apiKey)
        {
            WebClient c = new WebClient();

            string conversationLine = (string.IsNullOrWhiteSpace(conversationId) ? "" : $"&cs={conversationId}");

            byte[] bytesRecieved = c.DownloadData($"https://www.cleverbot.com/getreply?key={ apiKey }&wrapper=cleverbot.net&input={ message }{ conversationLine }");

            if (bytesRecieved != null)
            {
                string result = Encoding.UTF8.GetString(bytesRecieved);
                CleverbotResponse response = JsonConvert.DeserializeObject<CleverbotResponse>(result);
                if (response != null)
                {
                    response.apikey = apiKey;
                    response.CreateInteractionsList();

                    return response;
                }
            }
            return null;
        }
        internal static async Task CreateAsync(string message, string conversationId, string apiKey, Action<CleverbotResponse> resultAction = null)
        {
            WebClient c = new WebClient();

            string conversationLine = (string.IsNullOrWhiteSpace(conversationId) ? "" : $"&cs={conversationId}");

            Uri cleverbotUri = new Uri($"https://www.cleverbot.com/getreply?key={ apiKey }&wrapper=cleverbot.net&input={ message }{ conversationLine }");

            c.DownloadDataCompleted += async (sender, e) =>
            {
                if(e.Error != null)
                {
                    Console.WriteLine(e.Error.Message);
                }

                if (e.Result != null)
                {
                    string result = Encoding.UTF8.GetString(e.Result);
                    CleverbotResponse response = await Task.Factory.StartNew(() => { return JsonConvert.DeserializeObject<CleverbotResponse>(result); });

                    if (response != null)
                    {
                        response.apikey = apiKey;
                        response.CreateInteractionsList();

                        resultAction?.Invoke(response);
                    }
                }
            };
            c.DownloadDataAsync(cleverbotUri);
        }

        internal void CreateInteractionsList()
        {
            if (string.IsNullOrWhiteSpace(interaction1))
            {
                interactions.Add(interaction1);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction2))
            {
                interactions.Add(interaction2);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction3))
            {
                interactions.Add(interaction3);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction4))
            {
                interactions.Add(interaction4);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction5))
            {
                interactions.Add(interaction5);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction6))
            {
                interactions.Add(interaction6);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction7))
            {
                interactions.Add(interaction7);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction8))
            {
                interactions.Add(interaction8);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction9))
            {
                interactions.Add(interaction9);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction10))
            {
                interactions.Add(interaction10);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction11))
            {
                interactions.Add(interaction11);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction12))
            {
                interactions.Add(interaction12);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction13))
            { interactions.Add(interaction13);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction14))
            { interactions.Add(interaction14);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction15))
            { interactions.Add(interaction15);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction16))
            { interactions.Add(interaction16);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction17))
            { interactions.Add(interaction17);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction18))
            { interactions.Add(interaction18);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction19))
            { interactions.Add(interaction19);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction20))
            { interactions.Add(interaction20);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction21))
            { interactions.Add(interaction21);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction22))
            { interactions.Add(interaction22);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction23))
            { interactions.Add(interaction23);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction24))
            { interactions.Add(interaction24);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction25))
            { interactions.Add(interaction25);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction26))
            { interactions.Add(interaction26);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction27))
            { interactions.Add(interaction27);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction28))
            { interactions.Add(interaction28);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction29))
            { interactions.Add(interaction29);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction30))
            { interactions.Add(interaction30);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction31))
            { interactions.Add(interaction31);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction32))
            { interactions.Add(interaction32);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction33))
            { interactions.Add(interaction33);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction34))
            { interactions.Add(interaction34);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction1))
            { interactions.Add(interaction35);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction36))
            { interactions.Add(interaction36);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction37))
            { interactions.Add(interaction37);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction38))
            { interactions.Add(interaction38);

            }
            else
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(interaction39))
            { interactions.Add(interaction39);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction40))
            { interactions.Add(interaction40);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction41))
            { interactions.Add(interaction41);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction42))
            { interactions.Add(interaction42);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction43))
            { interactions.Add(interaction43);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction44))
            { interactions.Add(interaction44);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction45))
            { interactions.Add(interaction45);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction46))
            { interactions.Add(interaction46);

            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction47))
            {
                interactions.Add(interaction47);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction48))
            {
                interactions.Add(interaction48);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction49))
            {
                interactions.Add(interaction49);
            }
            else
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(interaction50))
            {
                interactions.Add(interaction50);
            }
            else
            {
                return;
            }
        }

        public CleverbotResponse Respond(string text)
        {
            return Create(text, ConversationId, apikey);
        }
        public async Task RespondAsync(string text, Action<CleverbotResponse> resultAction)
        {
            await CreateAsync(text, conversationId, apikey, resultAction);
        }
    }
}
