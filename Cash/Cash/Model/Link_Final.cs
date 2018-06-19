namespace Cash.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Link_Final
    {
        public int ID { get; set; }

        public int PersonID { get; set; }

        public int ProductID { get; set; }

        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        public decimal Money { get; set; }

        public string Specification { get; set; }

        [Column("Type _of_purchase")]
        public bool Type__of_purchase { get; set; }

        public virtual Person Person { get; set; }

        public virtual Product Product { get; set; }
    }
}
