namespace Car_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public partial class User
    {

        [Key]
        public long User_ID { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Remote("Check", "Users", ErrorMessage = "The Username is already exist", AdditionalFields = "User_ID")]
        [StringLength(250)]
        public string User_Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(6, ErrorMessage = "The Password must be 6 Digits")]
        [StringLength(250)]
        public string User_Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(250)]
        public string User_Type { get; set; }
    }
}
