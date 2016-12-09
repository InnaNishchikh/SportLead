using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportLead
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

        /// <summary>
        /// ��������� �����������
        /// </summary>
        public List<Event> FavoriteEvents { get; protected set; }

        /// <summary>
        /// �����������, ������� ������ ������������
        /// </summary>
        public List<Event> MyEvents { get; protected set; }

        public User(string login, string password)
        {
            ChangeLogin(login);
            ChangePassword(password);
            FavoriteEvents = new List<Event>() {
                new Event("������", "������, 16 ������ 2017")
            };

            MyEvents = new List<Event>() {
                new Event("������", "������, 16 ������ 2017"),
                new Event("������ �����", "����, 21 ������ 2017"),
                new Event("�������", "�����������, 22 ������ 2017")
            };
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
