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
using Android.Graphics;
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


            Button openSchedBut = FindViewById<Button>(Resource.Id.schedule_open_button);
            openSchedBut.Click += OpenSchedule_Click;

            Button closeSchedBut = FindViewById<Button>(Resource.Id.schedule_close_button);
            closeSchedBut.Click += CloseSchedule_Click;

            Button openScorBut = FindViewById<Button>(Resource.Id.scores_open_button);
            openScorBut.Click += OpenScores_Click;

            Button closeScorBut = FindViewById<Button>(Resource.Id.scores_close_button);
            closeScorBut.Click += CloseScores_Click;

            Button openDescrBut = FindViewById<Button>(Resource.Id.description_open_button);
            openDescrBut.Click += OpenDescription_Click;

            Button closeDescrBut = FindViewById<Button>(Resource.Id.description_close_button);
            closeDescrBut.Click += CloseDescription_Click;

            Button openFinalBut = FindViewById<Button>(Resource.Id.finaltable_open_button);
            openFinalBut.Click += OpenFinaltable_Click;

            Button closeFinalBut = FindViewById<Button>(Resource.Id.finaltable_close_button);
            closeFinalBut.Click += CloseFinaltable_Click;

            Button editEventBut = FindViewById<Button>(Resource.Id.edit_event_button);
            editEventBut.Click += EditEvent_Click;

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


        private void OpenSchedule_Click(object sender, EventArgs e)
        {
            TableLayout table = FindViewById<TableLayout>(Resource.Id.schedule_table);
            table.Visibility = ViewStates.Visible;

            Button openBut = FindViewById<Button>(Resource.Id.schedule_open_button);
            openBut.Clickable = false;
            openBut.Visibility = ViewStates.Invisible;

            Button closeBut = FindViewById<Button>(Resource.Id.schedule_close_button);
            closeBut.Clickable = true;
            closeBut.Visibility = ViewStates.Visible;
        }

        private void CloseSchedule_Click(object sender, EventArgs e)
        {
            TableLayout table = FindViewById<TableLayout>(Resource.Id.schedule_table);
            table.Visibility = ViewStates.Gone;

            Button openBut = FindViewById<Button>(Resource.Id.schedule_open_button);
            openBut.Clickable = true;
            openBut.Visibility = ViewStates.Visible;

            Button closeBut = FindViewById<Button>(Resource.Id.schedule_close_button);
            closeBut.Clickable = false;
            closeBut.Visibility = ViewStates.Invisible;
        }

        private void OpenScores_Click(object sender, EventArgs e)
        {
            TableLayout table = FindViewById<TableLayout>(Resource.Id.scores_table);
            table.Visibility = ViewStates.Visible;

            Button openBut = FindViewById<Button>(Resource.Id.scores_open_button);
            openBut.Clickable = false;
            openBut.Visibility = ViewStates.Invisible;

            Button closeBut = FindViewById<Button>(Resource.Id.scores_close_button);
            closeBut.Clickable = true;
            closeBut.Visibility = ViewStates.Visible;
        }

        private void CloseScores_Click(object sender, EventArgs e)
        {
            TableLayout table = FindViewById<TableLayout>(Resource.Id.scores_table);
            table.Visibility = ViewStates.Gone;

            Button openBut = FindViewById<Button>(Resource.Id.scores_open_button);
            openBut.Clickable = true;
            openBut.Visibility = ViewStates.Visible;

            Button closeBut = FindViewById<Button>(Resource.Id.scores_close_button);
            closeBut.Clickable = false;
            closeBut.Visibility = ViewStates.Invisible;
        }

        private void OpenDescription_Click(object sender, EventArgs e)
        {
            TextView description = FindViewById<TextView>(Resource.Id.edit_event_description);
            description.Visibility = ViewStates.Visible;

            Button openBut = FindViewById<Button>(Resource.Id.description_open_button);
            openBut.Clickable = false;
            openBut.Visibility = ViewStates.Invisible;

            Button closeBut = FindViewById<Button>(Resource.Id.description_close_button);
            closeBut.Clickable = true;
            closeBut.Visibility = ViewStates.Visible;
        }

        private void CloseDescription_Click(object sender, EventArgs e)
        {
            TextView description = FindViewById<TextView>(Resource.Id.edit_event_description);
            description.Visibility = ViewStates.Gone;

            Button openBut = FindViewById<Button>(Resource.Id.description_open_button);
            openBut.Clickable = true;
            openBut.Visibility = ViewStates.Visible;

            Button closeBut = FindViewById<Button>(Resource.Id.description_close_button);
            closeBut.Clickable = false;
            closeBut.Visibility = ViewStates.Invisible;
        }

        private void OpenFinaltable_Click(object sender, EventArgs e)
        {
            TableLayout table = FindViewById<TableLayout>(Resource.Id.final_table);
            table.Visibility = ViewStates.Visible;

            Button openBut = FindViewById<Button>(Resource.Id.finaltable_open_button);
            openBut.Clickable = false;
            openBut.Visibility = ViewStates.Invisible;

            Button closeBut = FindViewById<Button>(Resource.Id.finaltable_close_button);
            closeBut.Clickable = true;
            closeBut.Visibility = ViewStates.Visible;
        }

        private void CloseFinaltable_Click(object sender, EventArgs e)
        {
            TableLayout table = FindViewById<TableLayout>(Resource.Id.final_table);
            table.Visibility = ViewStates.Gone;

            Button openBut = FindViewById<Button>(Resource.Id.finaltable_open_button);
            openBut.Clickable = true;
            openBut.Visibility = ViewStates.Visible;

            Button closeBut = FindViewById<Button>(Resource.Id.finaltable_close_button);
            closeBut.Clickable = false;
            closeBut.Visibility = ViewStates.Invisible;
        }
    
        private void EditEvent_Click(object sender, EventArgs e)
        {
            TextView name = FindViewById<TextView>(Resource.Id.edit_event_name);
            name.FocusableInTouchMode = true;
            name.Clickable = true;
            name.Enabled = true;
            name.SetTypeface(null, TypefaceStyle.Italic);
        }

    }
}