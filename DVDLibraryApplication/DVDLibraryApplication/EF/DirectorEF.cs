using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVDLibraryApplication.EF
{
    public class DirectorEF
    {
        [Key]
        public int DirectorId { get; set; }
        public string DirectorName { get; set; }
    }
}