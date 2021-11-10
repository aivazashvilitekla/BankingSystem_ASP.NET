namespace LC.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Loan")]
    public partial class Loan
    {
        public int ID { get; set; }

        public int Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }

        public int Duration { get; set; }

        public int PersonID { get; set; }

        public int GuarantorID { get; set; }

        public virtual Guarantor Guarantor { get; set; }

        public virtual Person Person { get; set; }
    }
}
