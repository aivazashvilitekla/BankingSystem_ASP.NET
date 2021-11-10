namespace LC.DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            Deposit = new HashSet<Deposit>();
            Loan = new HashSet<Loan>();
        }

        public int PersonID { get; set; }

        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(6)]
        public string Gender { get; set; }

        [Required]
        [StringLength(11)]
        public string IDNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthdate { get; set; }

        public int CountryID { get; set; }

        public int CityID { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(70)]
        public string Email { get; set; }

        public int GuarantorID { get; set; }

        public virtual City City { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> Deposit { get; set; }

        public virtual Guarantor Guarantor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Loan> Loan { get; set; }
    }
}
