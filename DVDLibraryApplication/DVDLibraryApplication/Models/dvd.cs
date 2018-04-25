using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DVDLibraryApplication.Models
{


    public class dvd
    {


            [Key]
            public int dvdId { get; set; }
        //    public int directorId { get; set; }
          //  public int? ratingId { get; set; }
            public string title { get; set; }
        public string realeaseYear { get; set; }
        
        public string notes { get; set; }
            public string director { get; set; }
            public string rating { get; set; }
        
    }
}