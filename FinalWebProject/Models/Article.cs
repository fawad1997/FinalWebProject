using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalWebProject.Models
{
    public class Article
    {
        [Key]
        public int ArticleID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Title can not be greater than 50 characters!", MinimumLength = 1)]
        public String Title { get; set; }
        [Required]
        public String Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }
    }
}
