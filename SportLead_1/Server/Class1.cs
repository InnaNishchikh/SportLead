﻿using Newtonsoft.Json;
using SportLead;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{


    //* Запросить все мероприятия
    //     WebRequest reqGET = WebRequest.Create(
    //     @"http://10.33.67.242:6543/api/v1/all_tournaments");


    /* запросить информацию по событию, 1 - id события
                 WebRequest reqGET = WebRequest.Create(
            @"http://10.33.67.242:6543/api/v1/tournament/1");

     */

    public class Class1
    {
        public static void Main(string[] args)
        {
            WebRequest reqGET = WebRequest.Create(
                @"http://10.33.67.242:6543/api/v1/tournament/4");
           
            WebResponse resp = reqGET.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string s = sr.ReadToEnd();
            Console.WriteLine(s);
            Console.ReadLine();


            //Event e = new Event("Футбол", "treww");
            //string sz = JsonConvert.SerializeObject(e);

            //var e1 = JsonConvert.DeserializeObject<Event>(sz);

        }
    }
}









































































































































































































































































































































































































































































