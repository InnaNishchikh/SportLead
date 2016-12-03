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
using SportLead;

namespace SportLead_1
{
    class Application
    {
        public User User { get; protected set; }

        public void SetUser (User user)
        {
            User = user;
        }   
    }
}