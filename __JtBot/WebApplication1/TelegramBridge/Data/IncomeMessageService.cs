using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBridge.Data;

namespace TelegramBridge.Data
{
    public class IncomeMessageService
    {
        public string GetUserFio(Result result)
        {
            return result.message.from.last_name + " " + result.message.from.first_name;
        }
    }
}
