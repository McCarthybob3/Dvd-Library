using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web;
using DVDLibraryApplication.Models;

namespace DVDLibraryApplication

{

    public class DvdRepoMock : IDvdRepository
    {
        private  List<Rating> _ratings = new List<Rating>
        {new Rating
        {RatingID =1, Rating1="PG-13" },
            new Rating
            {
                RatingID=2, Rating1="G"
            }

        };

        private  List<Director> _directors = new List<Director>
        {
             new Director
        {DirectorID=1, Name="Ivan Reitman" },
            new Director
            {
                DirectorID=2, Name="Andrew Stanton"
            }
,            new Director{
    DirectorID=3, Name="John G. Avildsen"
            }
        };

        private  List<dvd> _dvds = new List<dvd>
    {
        new dvd
            { dvdId=1, title="Ghostbusters", director="Ivan Reitman" , realeaseYear="1984", rating="PG-13"},
        new dvd
            { dvdId=2, title="Finding Nemo", director="Andrew Stanton", realeaseYear="2003", rating="G"},
        new dvd
            { dvdId=3, title="Rocky", director="John G. Avildsen",realeaseYear="1976",rating="PG-13" }
    };

        public  List<dvd> GetAll()
        {
            return _dvds;
        }

        public  dvd Get(int dvdId)
        {
            return _dvds.FirstOrDefault(m => m.dvdId == dvdId);
        }
        public List< dvd> GetName(string dvdTitle)
        {
            List<dvd> list = new List<dvd>();
            var selection = _dvds.FirstOrDefault(m => m.title == dvdTitle);
            list.Add(selection);
            return list;
        }
        public List<dvd> GetDirector(string dvdDirector)
        {
            List<dvd> list = new List<dvd>();
            var selection = _dvds.FirstOrDefault(m => m.director == dvdDirector);
            list.Add(selection);
            return list;
                
        }
        public List<dvd> GetRating(string dvdRating)
        {
            List<dvd> list = new List<dvd>();
            var selection = _dvds.FirstOrDefault(m => m.rating == dvdRating);
            list.Add(selection);
            return list;
        }
        public List<dvd> GetYear(string dvdYear)
        {
            List<dvd> list = new List<dvd>();
            var selection = _dvds.FirstOrDefault(m => m.realeaseYear == dvdYear);
            list.Add(selection);
            return list;
        }


        public  void Add(dvd dvd)
        {
            dvd.dvdId = _dvds.Max(m => m.dvdId) + 1;
            _dvds.Add(dvd);
        }

        public  void Edit(dvd dvd)
        {
            var found = _dvds.FirstOrDefault(m => m.dvdId == dvd.dvdId);

            if (found != null)
                found = dvd;
        }

        public  void Delete(int dvdID)
        {

            _dvds.RemoveAll(m => m.dvdId == dvdID);
           
           
        }
    }
}