namespace Car_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Customer
    {

        [Key]
        public long Cus_ID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(250)]
        public string Cus_Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(11, ErrorMessage = "The phone number must be 11 Digits", MinimumLength = 11)]
        public string Cus_Phone { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(14, ErrorMessage = "The national id must be 14 numbers", MinimumLength = 14)]
        [Remote("Check", "Customers", ErrorMessage = "The Customer is already exist", AdditionalFields = "Cus_ID")]
        public string National_ID { get; set; }
    }
}
