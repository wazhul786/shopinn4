using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopinn4.Models
{
    public class admin
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string AdminId { get; set; }
        [Required]
        public string Password { get; set; }
    }
}