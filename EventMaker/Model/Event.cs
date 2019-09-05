using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
    public class Event
    {
        private int _id;
        private string _name;
        private string _description;
        private string _place;
        private DateTime _dateTime;

        public Event(int id, string name, string description, string place, DateTime dateTime)
        {
            _id = id;
            _name = name;
            _description = description;
            _place = place;
            _dateTime = dateTime;

     
        }

        public override string ToString()
        {
            return _name + " " + _description;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public string Place
        {
            get { return _place; }
        }

        public DateTime DateTime
        {
            get { return _dateTime; }
        }
    }
}
