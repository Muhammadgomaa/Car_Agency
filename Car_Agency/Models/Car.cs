namespace Car_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class Car
    {
        [Key]
        public long Car_ID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(250)]
        public string Car_Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(250)]
        public string Car_Model { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public double Car_Price { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(8, ErrorMessage = "The car license must be from 6 to 8 Digits and contains letters and numbers", MinimumLength = 6)]
        [Remote("Check", "Products", ErrorMessage = "This Car is already exist", AdditionalFields = "Car_ID")]
        public string Car_Licence { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public long Supp_ID { get; set; }

        public virtual Supplier Supplier { get; set; }


    }
}
