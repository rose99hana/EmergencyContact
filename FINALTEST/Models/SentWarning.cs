using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FINALTEST.Models
{
    public class SentWarning
    {
        public int Id { get; set; }
        public bool MailSent { get; set; }
        public bool SMSSent { get; set; }
        public DateTime SentTime { get; set; }

        public int ContactDetailID { get; set; }
        public int WarningID { get; set; }

        [ForeignKey("ContactDetailID")]
        public virtual ContactDetail ContactDetail { get; set; }

        [ForeignKey("WarningID")]
        public virtual Warning Warning { get; set; }
    }
}