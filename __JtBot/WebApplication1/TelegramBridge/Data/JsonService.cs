﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TelegramBridge.Data
{
    public class MessageFromUser
    {
        public result[] result;
    }
    public class result
    {
        public int update_id { get; set; }
        public message message { get; set; }
    }
    public class message
    {
        public int message_id { get; set; }
        public message_from from { get; set; }
        public message_chat chat { get; set; }
        public int date { get; set; }
        public string text { get; set; }
    }
    public class message_from
    {
        public int ind { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
    }
    public class message_chat
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string username { get; set; }
    }
        {
            "ok":true,
            "result":[
            {
                "update_id":496727976,
                "message":{
                                "message_id":10,
                                "from":{
                                            "id":267714417,
                                            "first_name":"Anton",
                                            "last_name":"Vakhrameev"
                                        },
                                "chat":{
                                            "id":267714417,
                                            "first_name":"Anton",
                                            "last_name":"Vakhrameev",
                                            "type":"private"
                                        },
                                "date":1492259492,
                                "text":"re"
                            }
            }
            ]
        }
    }
}