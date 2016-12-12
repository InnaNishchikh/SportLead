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

namespace SportLead_1.ClickListeners
{
    public class OnPositiveClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
    {
        public static MainActivity MainActivity { get; set; }

        public void OnClick(IDialogInterface dialog, int which)
        {
            // TODO переход на страницу с авторизацией
            MainActivity.SetFragmentOnMainWindow(MainActivity.menu["¬ойти"]);
        }
    }
}