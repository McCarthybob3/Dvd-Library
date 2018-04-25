using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVDLibraryApplication.Models
{
    public class EditViewModel
    {
        [Required]
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