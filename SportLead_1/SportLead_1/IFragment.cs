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

namespace SportLead_1
{
    public interface IFragment
    {
        string Title { get; }
        Application App { get; set; }
        MainActivity MainActivity { get; set; }
    }
}