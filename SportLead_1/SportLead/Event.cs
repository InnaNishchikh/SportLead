using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;

namespace SportLead
{
    public class Event
    {
        public string Name { get; set; }

        public string City { get; set; }

        public string Place { get; set; }

        public string Address { get; set; }

        // TODO какой тип?
        public DateTime Date { get; set; }

        // TODO какой тип?
        public TimeSpan Time { get; set; }

        public string Description { get; set; }

        public User Creator { get; set; }

        public string Info { get; set; }

        public Event(string name, string info)
        {
            Name = name;
            Info = info;
        }
  
        public override bool Equals(object obj)
        {
            Event item = obj as Event;
            return (Name == item.Name && Info == item.Info);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}