using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIApp.Services
{
    public class TimeService
    {
        public string GetTime() => System.DateTime.Now.ToString();
    }
}
