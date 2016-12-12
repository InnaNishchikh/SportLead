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
using SportLead;
using Android.Support.Design.Widget;

namespace SportLead_1.Fragments
{
    public class MyEventsFragment : Android.Support.V4.App.Fragment, IFragment
    {
        public Application App { get; set; }
        public MainActivity MainActivity { get; set; }
        public string Title { get { return "Мои мероприятия"; } }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            //RecyclerView recyclerView = inflater.Inflate(
            //    Resource.Layout.MyEventsFragment, container, false) as RecyclerView;

            CoordinatorLayout coord_layout = inflater.Inflate(
                Resource.Layout.MyEventsFragment, container, false) as CoordinatorLayout;

            RecyclerView recyclerView = coord_layout.FindViewById<RecyclerView>(
                Resource.Id.recyclerview_myevents);

            SetUpRecyclerView(recyclerView);

            FloatingActionButton fab = coord_layout.FindViewById<FloatingActionButton>(Resource.Id.fab);

            fab.Click += (o, e) =>
            {
                //if (App.IsUserLogin)
                //{

                //}
                //else
                //{
                // сообщение о том, что только авторизованные пользователи могут создавать мероприятия
                var context = recyclerView.Context;
                string title = "Вы не авторизованы";
                string message = "Войдите в систему, чтобы иметь возможность создавать мероприятия";
                string button1String = "войти";
                string button2String = "не сейчас";

                var ad = new AlertDialog.Builder(context);
                ad.SetTitle(title);  // заголовок
                ad.SetMessage(message); // сообщение

                ad.SetPositiveButton(button1String, new ClickListeners.OnPositiveClickListener());

                ad.SetNegativeButton(button2String, new ClickListeners.OnNegativeClickListener());
                ad.SetCancelable(true);
                ad.Show();
                //        ad.SetOnCancelListener(new OnCancelListener()
                //{
                //            public void onCancel(DialogInterface dialog)
                //{
                //    Toast.makeText(context, "Вы ничего не выбрали",
                //            Toast.LENGTH_LONG).show();
                //}
                //        });


                //}
            };
            return coord_layout;
        }

        private void SetUpRecyclerView(RecyclerView recyclerView)
        {
            List<Event> values = new List<Event>();
            // если пользователь авторизован
            if (App.IsUserLogin)
            {
                values = App.User.OwnEvents;
            }

            recyclerView.SetLayoutManager(new LinearLayoutManager(recyclerView.Context));
            recyclerView.SetAdapter(new EventRecyclerViewAdapter(recyclerView.Context, values, Activity.Resources));

            recyclerView.SetItemClickListener((rv, position, view) =>
            {
                //An item has been clicked
                Context context = view.Context;
                Intent intent = new Intent(context, typeof(EventActivity));
                intent.PutExtra(EventActivity.eventStr, values[position].Name);

                context.StartActivity(intent);
            });


        }
    }


}