using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace shopinn4.Models
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductImage { get; set; }
        [Required]
        public string ProductPrice { get; set; }
        [Required]
        public string Offer { get; set; }
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string AccountNo { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Bank { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string OrderNo { get; set; }
        [Required]
        public DateTime CurrentDate { get; set; }
    }
}