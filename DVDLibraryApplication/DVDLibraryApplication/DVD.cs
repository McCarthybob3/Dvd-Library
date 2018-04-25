namespace DVDLibraryApplication
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DVD")]
    public partial class DVD
    {
        public int DvdID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(4)]
        public string ReleaseYear { get; set; }

        public int DirectorID { get; set; }

        public int RatingID { get; set; }

        [StringLength(200)]
        public string Notes { get; set; }

        public virtual Director Director { get; set; }

        public virtual Rating Rating { get; set; }
    }
}
