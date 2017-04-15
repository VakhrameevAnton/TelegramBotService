using System;
using TelegramBridge;

namespace TelegramListener
{
    class Program
    {
        static void Main(string[] args)
        {
            TelegramRequest Tr = new TelegramRequest();
            Tr.ResponseReceived += Tr_ResponseReceived;
            Tr.GetUpdates();
        }

        private static void Tr_ResponseReceived(object sender, ParameterResponse e)
        {
            Console.WriteLine("{0}: {1}  chatId:{2}", e.name, e.message, e.chatId);
        }
    }
}
