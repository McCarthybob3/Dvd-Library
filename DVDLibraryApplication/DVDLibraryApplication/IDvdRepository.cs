using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibraryApplication.Models;

namespace DVDLibraryApplication
{
   public interface IDvdRepository
    {
         dvd Get(int dvdid);
        void Edit(dvd dvd);
        List<dvd> GetName(string dvdTitle);
        List<dvd> GetDirector(string dvdDirector);
        List<dvd> GetRating(string dvdRating);
        List<dvd> GetYear(string dvdYear);
        void Delete(int dvdid);
        void Add(dvd dvd);
        List<dvd> GetAll();
    }
}
