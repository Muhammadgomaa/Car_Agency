namespace Car_Agency.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales_Cash
    {
        [Key]
        public long Trans_ID { get; set; }

        public long Cus_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Cus_Name { get; set; }

        [Required]
        [StringLength(250)]
        public string National_ID { get; set; }

        public long User_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string User_Name { get; set; }

        [Required]
        [StringLength(250)]
        public string User_Type { get; set; }

        public long Car_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Car_Model { get; set; }

        [Required]
        [StringLength(250)]
        public string Car_Licence { get; set; }

        public double Car_Price { get; set; }

        [Required]
        [StringLength(250)]
        public string Date { get; set; }

        [Required]
        [StringLength(250)]
        public string Time { get; set; }

        public virtual Car Car { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual User User { get; set; }
    }
}
