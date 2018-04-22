using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FINALTEST.Models
{
    public class TobeSend
    {
        public int Id { get; set; }
        public DateTime SendTime { get; set; }
        public string SendStatus { get; set; }

        public int ContactDetailID { get; set; }
        public int WarningID { get; set; }

        [ForeignKey("ContactDetailID")]
        public virtual ContactDetail ContactDetail { get; set; }

        [ForeignKey("WarningID")]
        public virtual Warning Warning { get; set; }
    }
}