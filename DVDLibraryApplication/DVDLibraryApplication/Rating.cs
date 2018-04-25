namespace DVDLibraryApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rating()
        {
            DVDs = new HashSet<DVD>();
        }

        public int RatingID { get; set; }

        [Column("Rating")]
        [Required]
        [StringLength(10)]
        public string Rating1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DVD> DVDs { get; set; }
    }
}
