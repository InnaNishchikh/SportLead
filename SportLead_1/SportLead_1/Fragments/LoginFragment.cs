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
using SportLead;

namespace SportLead_1.Fragments
{
    public class LoginFragment : Android.Support.V4.App.Fragment, IFragment
    {
        public Application App { get; set; }

        public MainActivity MainActivity { get; set; }

        ScrollView view;

        public string Title
        {
            get
            {
                return "Авторизация";
            }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            view = inflater.Inflate(Resource.Layout.login, container, false) as ScrollView;

            #region login 

            Button enterButton = view.FindViewById<Button>(Resource.Id.enterButton);
            enterButton.Click += EnterButton_Click;

            Button createAcButton = view.FindViewById<Button>(Resource.Id.createAcButton);
            createAcButton.Click += CreateAcButton_Click;

            EditText editLogin = view.FindViewById<EditText>(Resource.Id.login);
            editLogin.KeyPress += EditLogin_KeyPress;

            EditText editPassword = view.FindViewById<EditText>(Resource.Id.password);
            editPassword.KeyPress += EditPassword_KeyPress;

            #endregion

            return view;
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string login = view.FindViewById<EditText>(Resource.Id.login).Text;
            string password = view.FindViewById<EditText>(Resource.Id.password).Text;

            if (!string.IsNullOrEmpty(login))
            {
                User user = new User(login, password);
                App.SetUser(user);
                App.LoginUser();
                MainActivity.SetFragmentOnMainWindow(MainActivity.menu["Мероприятия"]);
                Toast toast = Toast.MakeText(view.Context, "Вы успешно авторизовались", ToastLength.Short);
                toast.Show();
            }
        }

        /// <summary>
        /// Кнопка "Создать аккаунт"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAcButton_Click(object sender, System.EventArgs e)
        {
            string login = view.FindViewById<EditText>(Resource.Id.login).Text;
            string password = view.FindViewById<EditText>(Resource.Id.password).Text;

            if (!string.IsNullOrEmpty(login))
            {
                User user = new User(login, password);
                App.SetUser(user);
                App.LoginUser();
                MainActivity.SetFragmentOnMainWindow(MainActivity.menu["Мероприятия"]);
                Toast toast = Toast.MakeText(view.Context, "Аккаунт создан", ToastLength.Short);
                toast.Show();

                
            }
            else
            {
                Toast toast = Toast.MakeText(view.Context, "Введите логин", ToastLength.Short);
                toast.Show();
            }

        }

        private void EditPassword_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                //то, что тут будет написано, будет происходить и при нажатии enter на поле login!

                Button createAcButton = view.FindViewById<Button>(Resource.Id.createAcButton);

                // прячем клавиатуру
                //CloseKeyboard(createAcButton.WindowToken);
            }
        }

        private void EditLogin_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                EditText editPassword = view.FindViewById<EditText>(Resource.Id.password);
                editPassword.RequestFocus();
            }
        }
    }
}