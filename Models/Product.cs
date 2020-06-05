using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopinn4.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        //[DataType(DataType.Upload)]
        public string ProductImage { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public int Offer { get; set; }
    }
}