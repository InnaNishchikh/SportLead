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
using Android.Support.V7.Widget;

namespace SportLead_1.Helpers
{
    public class EventViewHolder : RecyclerView.ViewHolder
    {
        public Event mBoundString; // ��� ��� � �����???
        public readonly View mView;
        public readonly TextView mTxtView_EventName;
        public readonly TextView mTxtView_Info;
        public readonly CheckBox mCheckBox;

        public EventViewHolder(View view) : base(view)
        {
            mView = view;
            mTxtView_EventName = view.FindViewById<TextView>(Resource.Id.event_name);
            mTxtView_Info = view.FindViewById<TextView>(Resource.Id.event_info);
            mCheckBox = view.FindViewById<CheckBox>(Resource.Id.click);
            mCheckBox.Visibility = ViewStates.Invisible;
        }

        public override string ToString()
        {
            return base.ToString() + " '" + mTxtView_EventName.Text + mTxtView_Info.Text;
        }
    }
}