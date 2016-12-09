using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using SportLead_1.Helpers;
using DesignLibrary.Helpers;

namespace SportLead_1.Fragments
{
    public class MyEventsFragment : Android.Support.V4.App.Fragment, IFragment
    {
        public Application App { get; set; }

        public string Title { get { return "��� �����������"; } }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            RecyclerView recyclerView = inflater.Inflate(
                Resource.Layout.MyEventsFragment, container, false) as RecyclerView;

            SetUpRecyclerView(recyclerView);

            return recyclerView;
        }

        private void SetUpRecyclerView(RecyclerView recyclerView)
        {
            // ���� ������������ �����������
            if (App.IsUserLogin)
            {
                var values = App.User.MyEvents;

                recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
                recyclerView.SetAdapter(new SimpleEventRecyclerViewAdapter(recyclerView.Context, values, Activity.Resources, App));

                recyclerView.SetItemClickListener((rv, position, view) =>
                {
                    //An item has been clicked
                    Context context = view.Context;
                    Intent intent = new Intent(context, typeof(EventActivity));
                    intent.PutExtra(EventActivity.eventStr, values[position].Name);

                    context.StartActivity(intent);
                });

            }
            else
            {
                // TODO ��������� � ���, ��� ����� ��������������
                // � ������: ��������� -> ������ ����� � ������ -> ��������� ���������
            }
        }
    }
}