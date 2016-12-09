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
            Events = new List<Event>() {
                new Event("������", "������, 16 ������ 2017"),
                new Event("���������", "�����������, 17 ������ 2017"),
                new Event("�������", "������������, 18 ������ 2017"),
                new Event("������", "����, 19 ������ 2017"),
                new Event("��������", "��������, 20 ������ 2017"),
                new Event("������ �����", "����, 21 ������ 2017"),
                new Event("�������", "�����������, 22 ������ 2017"),
                new Event("������", "������, 23 ������ 2017"),
                new Event("�������", "�����-���������, 24 ������ 2017"),
                new Event("��������", "�������, 25 ������ 2017"),
                new Event("������", "������, 26 ������ 2017"),
                new Event("���������� ��������", "��������, 27 ������ 2017"),
                new Event("����������", "������, 1 ������� 2017"),
                new Event("����", "�����������, 17 ������� 2017"),
                new Event("��������", "������������, 18 ������� 2017"),
                new Event("������", "����, 19 ������� 2017"),
                new Event("������ ��������", "��������, 20 ������� 2017"),
                new Event("������������", "����, 21 ������� 2017"),
                new Event("�����", "�����������, 22 ������� 2017"),
                new Event("��������", "������, 23 ������� 2017"),
                new Event("����������", "�����-���������, 24 ������� 2017"),
                new Event("���������", "�������, 25 ������� 2017"),
                new Event("���", "������, 26 ������� 2017"),
                new Event("�������� �������", "��������, 27 ������� 2017")
            };
        }

        /// <summary>
        /// ����������� �� ������������
        /// </summary>
        public bool IsUserLogin { get; protected set; }

        public void SetUser (User user)
        {
            User = user;
            IsUserLogin = false;
        }   

        /// <summary>
        /// ������������ ������������
        /// TODO �������� � ����������
        /// </summary>
        public void LoginUser()
        {
            IsUserLogin = true;
        }

        public void AddFavorite(int position)
        {
            User.FavoriteEvents.Add(Events[position]);
        }

        public void RemoveFavorite(int position)
        {
            User.FavoriteEvents.Remove(Events[position]);
        }
    }
}