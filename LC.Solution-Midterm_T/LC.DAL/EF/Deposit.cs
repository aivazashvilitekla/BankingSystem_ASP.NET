namespace LC.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deposit")]
    public partial class Deposit
    {
        public int ID { get; set; }

        public int StartingAmount { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }

        public int Duration { get; set; }

        public int PersonID { get; set; }

        public virtual Person Person { get; set; }
    }
}
