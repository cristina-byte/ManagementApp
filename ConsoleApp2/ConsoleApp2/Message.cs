using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Message
    {
        private string _text;
        private DateTime _sent;

        public Message(string text,DateTime sent)
        {
            _text = text;
            _sent=sent;
        }

        public string Text { get; set; }

        public DateTime Sent { get; set; }
    }
}
