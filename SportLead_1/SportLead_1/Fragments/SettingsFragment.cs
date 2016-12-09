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
using Android.Views.InputMethods;

namespace SportLead_1.Fragments
{
    public class SettingsFragment : Android.Support.V4.App.Fragment, IFragment
    {
        public Application App { get; set; }

        public string Title { get { return "Настройки"; } }
        
        FrameLayout layout;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            layout = inflater.Inflate(Resource.Layout.SettingsFragment, container, false) as FrameLayout;
            
            EditText new_login = layout.FindViewById<EditText>(Resource.Id.new_login);
            new_login.Text = App.User.Login;

            EditText new_password = layout.FindViewById<EditText>(Resource.Id.new_password);
            new_password.Text = App.User.Password;

            CheckBox showPassword = layout.FindViewById<CheckBox>(Resource.Id.showPasswordCheckBox);
            showPassword.Click += ShowPassword_Click;

            Button saveChanges = layout.FindViewById<Button>(Resource.Id.saveSettings);
            saveChanges.Click += SaveChanges_Click;
             


            return layout;

            //return base.OnCreateView(inflater, container, savedInstanceState);
        }

        private void ShowPassword_Click(object sender, System.EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            EditText new_password = layout.FindViewById<EditText>(Resource.Id.new_password);
            if (checkBox.Checked)
            {
                new_password.InputType = Android.Text.InputTypes.ClassText;
            }
            else
            {
                new_password.InputType = Android.Text.InputTypes.ClassText
                    | Android.Text.InputTypes.TextFlagMultiLine
                    | Android.Text.InputTypes.TextVariationPassword;
            }
        }

        private void SaveChanges_Click(object sender, System.EventArgs e)
        {
            string login = layout.FindViewById<EditText>(Resource.Id.new_login).Text;
            string password = layout.FindViewById<EditText>(Resource.Id.new_password).Text;

            if (!string.IsNullOrEmpty(login))
            {
                if (App.IsUserLogin)
                {
                    App.User.ChangeLogin(login);
                    App.User.ChangePassword(password);
                    Toast toast = Toast.MakeText(layout.Context, "Изменения сохранены", ToastLength.Short);
                    toast.Show();
                }
                else
                {
                    Toast toast = Toast.MakeText(layout.Context, "Вы не авторизованы", ToastLength.Short);
                    toast.Show();
                }
                // прячем клавиатуру
                //InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
                //imm.HideSoftInputFromWindow(saveChanges.WindowToken, HideSoftInputFlags.NotAlways);
            }
            else
            {
                Toast toast = Toast.MakeText(layout.Context, "Введите логин", ToastLength.Short);
                toast.Show();
            }
        }
    }
}