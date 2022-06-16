namespace Car_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Purchase
    {
        [Key]
        public long Purch_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Purch_Details { get; set; }

        public double Purch_Cost { get; set; }
    }
}
