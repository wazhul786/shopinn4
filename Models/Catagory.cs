using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopinn4.Models
{
    public class Catagory
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string cat { get; set; }
    }
}