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
        private User _destination;

        public Message(string text,DateTime sent, User destination)
        {
            _text = text;
            _sent = sent;
            _destination = destination;
        }

        public string Text {
            get { return _text; }
            set { _text = value; }
        }

        public override string ToString() => "Message:" + _text + "\nSent at:" + _sent + "\nTo:" + _destination.Name;
    }
}
