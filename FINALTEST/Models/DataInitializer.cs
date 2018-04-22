using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FINALTEST.Models
{
    public class DataInitializer : DropCreateDatabaseAlways<DisasterWarningContext>
    {
        protected override void Seed(DisasterWarningContext db)
        {

            var ContactDetails = new List<ContactDetail>
            {
                new ContactDetail{Name="Ngo Le Nhat Minh", Phone="070-2822-9928", Mail="rose99hana@gmail.com", UseMail=true, UseSMS=false},
                new ContactDetail{Name="Ngo Le Thao Phuong", Phone="070-2823-5435", Mail="phuongngo1932@gmail.com", UseMail=true, UseSMS=true},
            };

            ContactDetails.ForEach(p => db.ContactDetails.Add(p));
            db.SaveChanges();

            var Warnings = new List<Warning>
            {
                new Warning{Title="地震警告", Detail="Hgo Nfrir Sfrueg jwfjn wufern rgnern"},
                new Warning{Title="津波警告", Detail="Hgo Nfrir Sfrueg jwfjn wufern rgnern"},
                new Warning{Title="大雪", Detail="Hgo Nfrir Sfrueg jwfjn wufern rgnern"},
                new Warning{Title="大雨", Detail="Hgo Nfrir Sfrueg jwfjn wufern rgnern"},
            };

            Warnings.ForEach(p => db.Warnings.Add(p));
            db.SaveChanges();

            var SentWarnings = new List<SentWarning>
            {
                new SentWarning{ContactDetail=ContactDetails[0], Warning=Warnings[0], MailSent=true, SMSSent=false, SentTime=DateTime.Now},
                new SentWarning{ContactDetail=ContactDetails[1], Warning=Warnings[0], MailSent=true, SMSSent=true, SentTime=DateTime.Now},
                new SentWarning{ContactDetail=ContactDetails[0], Warning=Warnings[3], MailSent=true, SMSSent=false, SentTime=DateTime.Now},
                new SentWarning{ContactDetail=ContactDetails[1], Warning=Warnings[3], MailSent=true, SMSSent=true, SentTime=DateTime.Now},

            };

            SentWarnings.ForEach(p => db.SentWarnings.Add(p));
            db.SaveChanges();
        }
    }
}