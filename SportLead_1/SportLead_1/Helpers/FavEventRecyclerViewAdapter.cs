using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SportLead;
using Android.Support.V7.Widget;
using Android.Util;

namespace SportLead_1.Helpers
{
    public class FavEventRecyclerViewAdapter : RecyclerView.Adapter
    {
        protected Application app;
        private readonly TypedValue mTypedValue = new TypedValue();
        protected int mBackground;
        private List<Event> mValues;
        Resources mResource;
        private Dictionary<int, int> mCalculatedSizes;

        private int fake_position = -1;

        public FavEventRecyclerViewAdapter(Context context, List<Event> items, Resources res, Application app)
        {
            this.app = app;
            context.Theme.ResolveAttribute(Resource.Attribute.selectableItemBackground, mTypedValue, true);
            mBackground = mTypedValue.ResourceId;
            mValues = items;
            mResource = res;

            mCalculatedSizes = new Dictionary<int, int>();
        }

        public override int ItemCount
        {
            get
            {
                return mValues.Count;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var simpleHolder = holder as FavEventViewHolder;

            Event current_event = mValues[position];

            simpleHolder.mBoundString = current_event;
            simpleHolder.mTxtView_EventName.Text = current_event.Name;
            simpleHolder.mTxtView_Info.Text = current_event.Info;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_Item_withFab, parent, false);
            view.SetBackgroundResource(mBackground);
            fake_position++;

            return new FavEventViewHolder(view, app, fake_position);
        }
    }
}