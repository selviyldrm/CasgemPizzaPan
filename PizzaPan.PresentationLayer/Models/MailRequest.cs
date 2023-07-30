using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPan.PresentationLayer.Models
{
    public class MailRequest
    {
        public string  ReceiverMail { get; set; }
        public string  Subject { get; set; }
        public string  MessageContent { get; set; }
    }
}
