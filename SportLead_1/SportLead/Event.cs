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
    public class Event : ISerializable
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public Event(string name, string info)
        {
            Name = name;
            Info = info;
        }

        //TODO добавить метод сравнения Equals или что-то подобное. для метода List.Contains        
        public override bool Equals(object obj)
        {
            Event item = obj as Event;
            return (Name == item.Name && Info == item.Info);
        }


        #region ISerializable
        public IntPtr Handle
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}