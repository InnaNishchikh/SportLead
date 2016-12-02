using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
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

        public User(string login, string password)
        {
            ChangeLogin(login);
            ChangePassword(password);
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
    }
}
