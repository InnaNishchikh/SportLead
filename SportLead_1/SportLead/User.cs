using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportLead
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; protected set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; protected set; }

        /// <summary>
        /// Избранные мероприятия
        /// </summary>
        public List<Event> FavoriteEvents { get; protected set; }

        /// <summary>
        /// Мероприятия, которые создал пользователь
        /// </summary>
        public List<Event> MyEvents { get; protected set; }

        public User(string login, string password)
        {
            ChangeLogin(login);
            ChangePassword(password);
            FavoriteEvents = new List<Event>() {
                new Event("Футбол", "Москва, 16 января 2017")
            };

            MyEvents = new List<Event>() {
                new Event("Футбол", "Москва, 16 января 2017"),
                new Event("Лыжные гонки", "Сочи, 21 января 2017"),
                new Event("Керлинг", "Калининград, 22 января 2017")
            };
        }

        /// <summary>
        /// Поменять логин
        /// </summary>
        /// <param name="newLogin">Новый логин. Не может быть пустой строкой</param>
        public void ChangeLogin(string newLogin)
        {
            if (!string.IsNullOrEmpty(newLogin))
                Login = newLogin;
        }

        /// <summary>
        /// Изменить пароль
        /// </summary>
        /// <param name="newPassword">Новый пароль</param>
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void AddFavoriteEvent(Event fav_event)
        {
            if (fav_event != null && !FavoriteEvents.Contains(fav_event))
            {
                FavoriteEvents.Add(fav_event);
            }
        }

        public void AddFavoriteEvent(List<Event> fav_events)
        {
            if (fav_events != null)
            {
                foreach(var fav_event in fav_events)
                {
                    AddFavoriteEvent(fav_event);
                }
            }
        }
    }
}
