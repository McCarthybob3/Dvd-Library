using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DVDLibraryApplication.Models
{
    public class AddDvdRequest
    {
        
        public int dvdId { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string realeaseYear { get; set; }
        [Required]
        public string director { get; set; }
        [Required]
        public string rating { get; set; }
        public string notes { get; set; }

    }
}