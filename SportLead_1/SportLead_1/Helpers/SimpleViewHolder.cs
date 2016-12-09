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
using Android.Support.V7.Widget;
using SportLead;

namespace SportLead_1.Helpers
{
    public class SimpleViewHolder : RecyclerView.ViewHolder
    {
        Application app;

        public Event mBoundString; // что это и зачем???
        public readonly View mView;
        public readonly TextView mTxtView_EventName;
        public readonly TextView mTxtView_Info;
        public readonly CheckBox mCheckBox;

        public SimpleViewHolder(View view, Application app, int position) : base(view)
        {
            this.app = app;
            mView = view;
            mTxtView_EventName = view.FindViewById<TextView>(Resource.Id.event_name);
            mTxtView_Info = view.FindViewById<TextView>(Resource.Id.event_info);
            mCheckBox = view.FindViewById<CheckBox>(Resource.Id.click);
            mCheckBox.Click += MCheckBox_Click;
            if (app.User.FavoriteEvents.Contains(app.Events[position]))
            {
                mCheckBox.Checked = true;
            }
        }

        private void MCheckBox_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int position = Position;
            if (checkBox.Checked)
                app.AddFavorite(position);
            else
                app.RemoveFavorite(position);
        }

        public override string ToString()
        {
            return base.ToString() + " '" + mTxtView_EventName.Text + mTxtView_Info.Text;
        }
    }
}