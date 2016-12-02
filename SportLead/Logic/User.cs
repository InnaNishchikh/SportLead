using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    /// <summary>
    /// ������������
    /// </summary>
    public class User
    {
        /// <summary>
        /// �����
        /// </summary>
        public string Login { get; protected set; }

        /// <summary>
        /// ������
        /// </summary>
        public string Password { get; protected set; }

        public User(string login, string password)
        {
            ChangeLogin(login);
            ChangePassword(password);
        }

        /// <summary>
        /// �������� �����
        /// </summary>
        /// <param name="newLogin">����� �����. �� ����� ���� ������ �������</param>
        public void ChangeLogin(string newLogin)
        {
            if (!string.IsNullOrEmpty(newLogin))
                Login = newLogin;
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        /// <param name="newPassword">����� ������</param>
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
