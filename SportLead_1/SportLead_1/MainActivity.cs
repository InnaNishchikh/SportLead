using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using SportLead;
using Android.Views.InputMethods;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using SportLead_1.Fragments;
using Android.Content;
using Server;
using SportLead_1.ClickListeners;

namespace SportLead_1
{
    [Activity(Label = "SportLead", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/Theme.DesignDemo")]
    public class MainActivity : AppCompatActivity
    {
        Application app;
        public readonly Dictionary<string, IFragment> menu = new Dictionary<string, IFragment>()
        {
            { "Избранное", new FavoriteFragment() },
            { "Настройки", new SettingsFragment() },
            { "Мероприятия", new EventFragment() },
            { "Мои мероприятия", new MyEventsFragment() },
            {"Войти", new LoginFragment() }
        };
        
        private DrawerLayout mDrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            OnPositiveClickListener.MainActivity = this;

            SharedPreferences.sharedPreferences = GetSharedPreferences(
                SharedPreferences.APP_PREFERENCES, FileCreationMode.Private);

            app = new Application();
            app.LoadData();

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            SupportToolbar toolBar = FindViewById<SupportToolbar>(Resource.Id.toolBar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);
            SupportActionBar.Title = "Мероприятия";
            
            mDrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            if (navigationView != null)
            {
                SetUpDrawerContent(navigationView);
            }

            IFragment fragment = menu["Мероприятия"];
            fragment.App = app;
            SetFragmentOnMainWindow(fragment);


        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    mDrawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        /// <summary>
        /// Вставить фрагмент в главное окно main_window
        /// </summary>
        /// <param name="fragment"></param>
        public void SetFragmentOnMainWindow(IFragment fragment)
        {
            fragment.App = app;
            fragment.MainActivity = this;
            //LinearLayout main_window = FindViewById<LinearLayout>(Resource.Id.main_window);
            var t = SupportFragmentManager;
            t.BeginTransaction().Replace(Resource.Id.main_window,
                fragment as SupportFragment).Commit();

            SupportActionBar.Title = fragment.Title;
        }

        /// <summary>
        /// Подписка на клик по элементу navigation_view
        /// </summary>
        /// <param name="navigationView"></param>
        private void SetUpDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += 
                (object sender, NavigationView.NavigationItemSelectedEventArgs e) =>
            {
                e.MenuItem.SetChecked(true);
                mDrawerLayout.CloseDrawers();

                // переход к выбранной странице
                string itemTitle = e.MenuItem.TitleCondensedFormatted.ToString();
                IFragment fragment = menu[itemTitle];
                fragment.App = app;
                SetFragmentOnMainWindow(fragment);
            };
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

