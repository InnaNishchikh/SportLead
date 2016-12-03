using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using SportLead;
using Android.Views.InputMethods;
using Android.Support.Design.Widget;
using System.Collections.Generic;

namespace SportLead_1
{
    [Activity(Label = "SportLead", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        Application app;

        Dictionary<string, int> menu = new Dictionary<string, int>()
        {
            { "Избранное", Resource.Layout.favorite }, 
            { "Настройки", Resource.Layout.settings },
            {"Поиск", Resource.Layout.search },
            {"Мои мероприятия", Resource.Layout.myevents }
        };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            app = new Application();
            
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.login);

            Button createAcButton = FindViewById<Button>(Resource.Id.createAcButton);
            createAcButton.Click += CreateAcButton_Click;

            EditText editLogin = FindViewById<EditText>(Resource.Id.login);
            editLogin.KeyPress += EditLogin_KeyPress;

            EditText editPassword = FindViewById<EditText>(Resource.Id.password);
            editPassword.KeyPress += EditPassword_KeyPress;
        }

        
        /// <summary>
        /// Кнопка "Создать аккаунт"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAcButton_Click(object sender, System.EventArgs e)
        {
            string login = FindViewById<EditText>(Resource.Id.login).Text;
            string password = FindViewById<EditText>(Resource.Id.password).Text;

            if (!string.IsNullOrEmpty(login))
            {
                User user = new User(login, password);
                app.SetUser(user);

                SetContentView(Resource.Layout.settings);

                //var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
                //SetSupportActionBar(toolbar);
                //SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                //SupportActionBar.SetDisplayShowTitleEnabled(false);
                //SupportActionBar.SetHomeButtonEnabled(true);
                //SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

                NavigationView navView = FindViewById<NavigationView>(Resource.Id.nav_view);
                navView.NavigationItemSelected += NavView_NavigationItemSelected;

                EditText new_login = FindViewById<EditText>(Resource.Id.new_login);
                new_login.Text = user.Login;

                EditText new_password = FindViewById<EditText>(Resource.Id.new_password);
                new_password.Text = user.Password;

                CheckBox showPassword = FindViewById<CheckBox>(Resource.Id.showPasswordCheckBox);
                showPassword.Click += ShowPassword_Click;

                Button saveChanges = FindViewById<Button>(Resource.Id.saveSettings);
                saveChanges.Click += SaveChanges_Click;
            }
            else
            {
                Notification("Введите логин");
            }

        }

        private void NavView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            string itemTitle = e.MenuItem.TitleCondensedFormatted.ToString();
            SetContentView(menu[itemTitle]);
            if (itemTitle == "Настройки")
            {
                EditText new_login = FindViewById<EditText>(Resource.Id.new_login);
                new_login.Text = app.User.Login;

                EditText new_password = FindViewById<EditText>(Resource.Id.new_password);
                new_password.Text = app.User.Password;

                CheckBox showPassword = FindViewById<CheckBox>(Resource.Id.showPasswordCheckBox);
                showPassword.Click += ShowPassword_Click;

                Button saveChanges = FindViewById<Button>(Resource.Id.saveSettings);
                saveChanges.Click += SaveChanges_Click;
            }
                    
            NavigationView navView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navView.NavigationItemSelected += NavView_NavigationItemSelected;
        }

        private void SaveChanges_Click(object sender, System.EventArgs e)
        {
            string login = FindViewById<EditText>(Resource.Id.new_login).Text;
            string password = FindViewById<EditText>(Resource.Id.new_password).Text;

            if (!string.IsNullOrEmpty(login))
            {
                app.User.ChangeLogin(login);
                app.User.ChangePassword(password);

                Button saveChanges = FindViewById<Button>(Resource.Id.saveSettings);
                // прячем клавиатуру
                CloseKeyboard(saveChanges.WindowToken);

                Notification("Изменения сохранены");
            }
            else
            {
                Notification("Введите логин");
            }
        }

        private void ShowPassword_Click(object sender, System.EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            EditText new_password = FindViewById<EditText>(Resource.Id.new_password);
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

        private void EditPassword_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                //то, что тут будет написано, будет происходить и при нажатии enter на поле login!

                Button createAcButton = FindViewById<Button>(Resource.Id.createAcButton);

                // прячем клавиатуру
                CloseKeyboard(createAcButton.WindowToken);
            }
        }

        private void EditLogin_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                EditText editPassword = FindViewById<EditText>(Resource.Id.password);
                editPassword.RequestFocus();
            }
        }

        /// <summary>
        /// Закрыть клавиатуру
        /// </summary>
        /// <param name="windowToken"></param>
        void CloseKeyboard(IBinder windowToken)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(InputMethodService);
            imm.HideSoftInputFromWindow(windowToken, HideSoftInputFlags.NotAlways);
        }

        /// <summary>
        /// Уведомление
        /// </summary>
        /// <param name="text">Текст уведомления</param>
        void Notification(string text)
        {
            Toast toast = Toast.MakeText(ApplicationContext, text, ToastLength.Short);
            toast.Show();
        }
    }
}

