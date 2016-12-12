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
using SportLead_1.Fragments;

namespace SportLead_1.Helpers
{
    public class FavEventViewHolder : RecyclerView.ViewHolder
    {
        Application app;

        public Event mBoundString; // ��� ��� � �����???
        public readonly View mView;
        public readonly TextView mTxtView_EventName;
        public readonly TextView mTxtView_Info;
        public readonly CheckBox mCheckBox;

        public FavEventViewHolder(View view, Application app, int position) : base(view)
        {
            this.app = app;
            mView = view;
            mTxtView_EventName = view.FindViewById<TextView>(Resource.Id.event_name);
            mTxtView_Info = view.FindViewById<TextView>(Resource.Id.event_info);
            mCheckBox = view.FindViewById<CheckBox>(Resource.Id.click);
            mCheckBox.Click += MCheckBox_Click;
            mCheckBox.Checked = true;
        }

        private void MCheckBox_Click(object sender, EventArgs e)
        {
            if (app.IsUserLogin)
            {
                CheckBox checkBox = sender as CheckBox;
                int position = Position;
                if (checkBox.Checked)
                    app.AddFavorite(position);
                else
                    app.RemoveFavorite(position);
            }
            else
            {
                // ��������� � ���, ��� ������ �������������� ������������ ����� ��������� �����������

                string title = "�� �� ������������";
                string message = "������� � �������, ����� ����� ����������� ��������� �����������";
                string button1String = "�����";
                string button2String = "�� ������";

                var ad = new AlertDialog.Builder(mCheckBox.Context);
                ad.SetTitle(title);  // ���������
                ad.SetMessage(message); // ���������

                ad.SetPositiveButton(button1String, new ClickListeners.OnPositiveClickListener());

                ad.SetNegativeButton(button2String, new ClickListeners.OnNegativeClickListener());
                ad.SetCancelable(true);
                ad.Show();
                //        ad.SetOnCancelListener(new OnCancelListener()
                //{
                //            public void onCancel(DialogInterface dialog)
                //{
                //    Toast.makeText(context, "�� ������ �� �������",
                //            Toast.LENGTH_LONG).show();
                //}
                //        });


            }



        }

        public override string ToString()
        {
            return base.ToString() + " '" + mTxtView_EventName.Text + mTxtView_Info.Text;
        }
    }
}