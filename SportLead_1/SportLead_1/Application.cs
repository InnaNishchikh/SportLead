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
using SportLead;

namespace SportLead_1
{
    public class Application
    {
        public User User { get; protected set; }

        public List<Event> Events { get; protected set; }



        public Application()
        {
            User = new User("", "");
            Events = new List<Event>();
            IsUserLogin = false;
        }

        /// <summary>
        /// Авторизован ли пользователь
        /// </summary>
        public bool IsUserLogin { get; protected set; }

        public void SetUser(User user)
        {
            User = user;
            IsUserLogin = true;
        }

        /// <summary>
        /// Авторизовать пользователя
        /// TODO подумать о реализации
        /// </summary>
        public void LoginUser()
        {
            IsUserLogin = true;
        }

        public void AddFavorite(int position)
        {
            try
            {
                User.AddFavoriteEvent(Events[position]);
            }
            catch { }
        }

        public void RemoveFavorite(int position)
        {
            try
            {
                User.FavoriteEvents.RemoveAt(position);
            }
            catch { }
        }

        /// <summary>
        /// Загрузить информацию с сервера
        /// </summary>
        /// <returns></returns>
        public bool LoadData()
        {
            //string login = SharedPreferences.GetUserName();
            //string password = SharedPreferences.GetPassword();

            //if (!string.IsNullOrEmpty(login) && password != null)
            //{
            //    SetUser(new User(login, password));
            //    LoginUser();
            //}

            Events = new List<Event>() {
                new Event("Футбол", "Москва, 16 января 2017"),
                new Event("Баскетбол", "Новосибирск, 17 января 2017"),
                new Event("Гандбол", "Екатеринбург, 18 января 2017"),
                new Event("Хоккей", "Тула, 19 января 2017"),
                new Event("Волейбол", "Новгород, 20 января 2017"),
                new Event("Лыжные гонки", "Сочи, 21 января 2017"),
                new Event("Керлинг", "Калининград, 22 января 2017"),
                new Event("Коньки", "Лондон, 23 января 2017"),
                new Event("Биатлон", "Санкт-Петербург, 24 января 2017"),
                new Event("Плавание", "Воронеж, 25 января 2017"),
                new Event("Гребля", "Бостон, 26 января 2017"),
                new Event("Синхронное плавание", "Ванкувер, 27 января 2017"),
                new Event("Гимнастика", "Москва, 1 февраля 2017"),
                new Event("Бокс", "Новосибирск, 17 февраля 2017"),
                new Event("Стрельба", "Екатеринбург, 18 февраля 2017"),
                new Event("Борьба", "Тула, 19 февраля 2017"),
                new Event("Легкая атлетика", "Новгород, 20 февраля 2017"),
                new Event("Скалолазание", "Сочи, 21 февраля 2017"),
                new Event("Гонки", "Калининград, 22 февраля 2017"),
                new Event("Сноуборд", "Лондон, 23 февраля 2017"),
                new Event("Фехтование", "Санкт-Петербург, 24 февраля 2017"),
                new Event("Бадминтон", "Воронеж, 25 февраля 2017"),
                new Event("Бег", "Бостон, 26 февраля 2017"),
                new Event("Фигурное катание", "Ванкувер, 27 февраля 2017")
            };


            return true;
        }
    }
}