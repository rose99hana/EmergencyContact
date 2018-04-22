using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FINALTEST.Models
{
    public class Warning
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(64, ErrorMessage = "This field is limited to 64 digits")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(64, ErrorMessage = "This field is limited to 200 digits")]
        public string Detail { get; set; }

        public virtual ICollection<SentWarning> SentWarnings { get; set; }
    }
}