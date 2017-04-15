using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using TelegramBridge.Data;

namespace TelegramBridge
{
    public delegate void Response(object sender, ParameterResponse e);
    public class ParameterResponse : EventArgs
    {
        public string name;
        public string message;
        public int chatId;
    }

    public class TelegramRequest
    {
        //JsonService jsonService = new JsonService();

        public string Token = "376883152:AAF8p2MM4lgqCiNk7dPnxcr0MQaCsnsZr00";
        int LastUpdateID = 0;
        public event Response ResponseReceived;
        ParameterResponse e = new ParameterResponse();

        public void GetUpdates()
        {
            while (true)
            {
                using (WebClient webClient = new WebClient())
                {
                    string response = webClient.DownloadString("https://api.telegram.org/bot" + Token + "/getupdates?offset="+(LastUpdateID+1));
                    if (response.Length <= 23)
                        continue;
                    var N = (JObject)JsonConvert.DeserializeObject(response);
                    foreach (var n in N["result"])
                    {
                        LastUpdateID = (int)n.SelectToken("update_id");
                        e.name = (string)n.SelectToken("message.from.username");
                        e.message = (string)n.SelectToken("message.text");
                        e.chatId = (int)n.SelectToken("message.chat.id");
                    }
                }
                ResponseReceived(this, e);
            }
        }
    }        
}
