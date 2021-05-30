using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanAspNet.WebApi.Controllers.Greeting
{
    public class SendGreetingViewModel
    {
        public string Message { get; set; }
        public string DateTimeSent { get; set; }
    }
}
