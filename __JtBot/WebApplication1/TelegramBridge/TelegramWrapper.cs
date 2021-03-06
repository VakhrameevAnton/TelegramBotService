﻿using Newtonsoft.Json;
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
                    var N = JsonConvert.DeserializeObject<MessageFromUser>(response);
                    foreach (var item in N.result)
                    {
                        LastUpdateID = item.update_id;
                        e.message = item.message.text;
                        e.name = item.message.from.username;
                        e.chatId = item.message.chat.id;
                    }
                }
                ResponseReceived(this, e);
            }
        }
    }        
}
