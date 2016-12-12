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

namespace SportLead_1
{
    public static class SharedPreferences
    {
        public const string APP_PREFERENCES = "mysettings";
        public const string userStr = "User";
        public const string passwordStr = "Password";

        public static ISharedPreferences sharedPreferences;

        public static void SaveUser(string userName, string password)
        {
            ISharedPreferencesEditor editor = sharedPreferences.Edit();
            editor.PutString(userStr, userName);
            editor.PutString(passwordStr, password);
            editor.Commit();
        }

        public static string GetUserName()
        {
            return sharedPreferences.GetString(userStr, string.Empty);
        }

        public static string GetPassword()
        {
            return sharedPreferences.GetString(passwordStr, null);
        }
    }
}