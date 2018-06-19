namespace Cash.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Family")]
    public partial class Family
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }
    }
}
