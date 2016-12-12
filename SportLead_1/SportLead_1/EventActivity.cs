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
using Android.Support.V7.App;
using SportLead;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;

namespace SportLead_1
{
    [Activity(Label = "Событие", Theme = "@style/Theme.DesignDemo")]
    public class EventActivity : AppCompatActivity
    {
        public const string eventStr = "Событие";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.event_info);

            //Event current_event = Intent.GetSerializableExtra(eventStr) as Event;
            string name = Intent.GetStringExtra(eventStr);
            //TextView text = FindViewById<TextView>(Resource.Id.event_message);

            //text.Text += "  " + name;

            //SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            //SetSupportActionBar(toolBar);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}