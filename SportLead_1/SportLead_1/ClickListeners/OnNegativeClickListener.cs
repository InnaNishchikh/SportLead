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
    public class OnNegativeClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
    {
        public void OnClick(IDialogInterface dialog, int which)
        {
            // ответ отрицательный. ничего не делаем
        }
    }
}