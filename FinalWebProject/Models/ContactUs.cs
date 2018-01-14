using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWebProject.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactUsID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Subject can not be greater than 50 characters!", MinimumLength = 4)]
        public String Subject { get; set; }
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public String Body { get; set; }
    }
}
