using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SportLead;

namespace SportLead_1.Helpers
{
    public class EventRecyclerViewAdapter : SimpleEventRecyclerViewAdapter
    {
        int fake_position = -1;

        public EventRecyclerViewAdapter(Context context, List<Event> items, Resources res, Application app) 
            : base(context, items, res, app)
        {
            
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.List_Item, parent, false);
            view.SetBackgroundResource(mBackground);
            fake_position++;

            return new EventViewHolder(view, app, fake_position);
        }
    }
}