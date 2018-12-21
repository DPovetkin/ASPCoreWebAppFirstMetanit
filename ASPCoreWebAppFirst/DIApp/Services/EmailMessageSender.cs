using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIApp.Services
{
    public class EmailMessageSender:IMessageSender
    {
        public string Send()
        {
            return "Send by email";
        }
    }
}
