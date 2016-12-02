using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Java.Lang;
using Android.Content;
using Android.Views.InputMethods;
using Logic;

namespace SportLead
{
    [Activity(Label = "SportLead", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // TODO перенести базовый класс
        User user;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.login);

            Button createAcButton = FindViewById<Button>(Resource.Id.createAcButton);
            createAcButton.Click += CreateAcButton_Click;

            EditText editLogin = FindViewById<EditText>(Resource.Id.login);
            editLogin.KeyPress += EditLogin_KeyPress;

            EditText editPassword = FindViewById<EditText>(Resource.Id.password);
            editPassword.KeyPress += EditPassword_KeyPress;
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
                user = new User(login, password);

                SetContentView(Resource.Layout.settings);
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

        private void SaveChanges_Click(object sender, System.EventArgs e)
        {
            string login = FindViewById<EditText>(Resource.Id.new_login).Text;
            string password = FindViewById<EditText>(Resource.Id.new_password).Text;

            if (!string.IsNullOrEmpty(login))
            {
                user.ChangeLogin(login);
                user.ChangePassword(password);

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

        private void Ok_Click(object sender, System.EventArgs e)
        {
            SetContentView(Resource.Layout.login);

            Button createAcButton = FindViewById<Button>(Resource.Id.createAcButton);
            createAcButton.Click += CreateAcButton_Click;

            EditText editLogin = FindViewById<EditText>(Resource.Id.login);
            editLogin.KeyPress += EditLogin_KeyPress;

            EditText editPassword = FindViewById<EditText>(Resource.Id.password);
            editPassword.KeyPress += EditPassword_KeyPress;
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

