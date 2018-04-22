using FINALTEST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FINALTEST
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new DataInitializer());

            //using (var db = new DisasterWarningContext())
            //{
            //    var ContactDetails = new List<ContactDetail>
            //    {
            //        new ContactDetail{Name="Ngo Le Nhat Minh", Phone="070-2822-9928", Mail="rose99hana@gmail.com", UseMail=true, UseSMS=false},
            //        new ContactDetail{Name="Ngo Le Thao Phuong", Phone="070-2823-5435", Mail="phuongngo1932@gmail.com", UseMail=true, UseSMS=true},
            //    };

            //    ContactDetails.ForEach(p => db.ContactDetails.Add(p));

            //    var Warnings = new List<Warning>
            //    {
            //        new Warning{Title="地震警告", Detail="Hgo Nfrir Sfrueg jwfjn wufern rgnern"},
            //        new Warning{Title="津波警告", Detail="Hgo Nfrir Sfrueg jwfjn wufern rgnern"},
            //        new Warning{Title="大雪", Detail="Hgo Nfrir Sfrueg jwfjn wufern rgnern"},
            //        new Warning{Title="大雨", Detail="Hgo Nfrir Sfrueg jwfjn wufern rgnern"},
            //    };

            //    Warnings.ForEach(p => db.Warnings.Add(p));

            //    var SentWarnings = new List<SentWarning>
            //    {
            //        new SentWarning{ContactDetail=ContactDetails[0], Warning=Warnings[0], MailSent=true, SMSSent=false, SentTime=DateTime.Now},
            //        new SentWarning{ContactDetail=ContactDetails[1], Warning=Warnings[0], MailSent=true, SMSSent=true, SentTime=DateTime.Now},
            //        new SentWarning{ContactDetail=ContactDetails[0], Warning=Warnings[2], MailSent=true, SMSSent=false, SentTime=DateTime.Now},
            //        new SentWarning{ContactDetail=ContactDetails[1], Warning=Warnings[2], MailSent=true, SMSSent=true, SentTime=DateTime.Now},

            //    };

            //    SentWarnings.ForEach(p => db.SentWarnings.Add(p));
            //    db.SaveChanges();
            //}
        }
    }
}
