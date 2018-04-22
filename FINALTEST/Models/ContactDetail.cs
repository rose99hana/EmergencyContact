using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FINALTEST.Models
{
    public class ContactDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required!")]
        [MaxLength(64, ErrorMessage ="This field is limited to 64 digits")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [EmailAddress(ErrorMessage ="Email is not valid!")]
        [MaxLength(64, ErrorMessage = "This field is limited to 128 digits")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(64, ErrorMessage = "This field is limited to 13 digits")]
        public string Phone { get; set; }

        public bool UseMail { get; set; }
        public bool UseSMS { get; set; }

        public virtual ICollection<SentWarning> SentWarnings { get; set; }
    }
}