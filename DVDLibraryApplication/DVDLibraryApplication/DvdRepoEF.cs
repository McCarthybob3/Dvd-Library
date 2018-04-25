using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DVDLibraryApplication.EF;
using DVDLibraryApplication.Models;

namespace DVDLibraryApplication
{
    public class DvdRepoEF : IDvdRepository
    {
        public void Add(dvd dvd)
        {
            var repository = new DvdLibraryEF();
            var newDirector = repository.Directors.FirstOrDefault(d => d.DirectorName == dvd.director);
            if (newDirector == null)
            {
                newDirector = repository.Directors.Add(new DirectorEF { DirectorName = dvd.director });
                repository.SaveChanges();
            }

            var newRating = repository.Ratings.FirstOrDefault(d => d.RatingName == dvd.rating);
            if (newRating == null)
            {
                newRating = repository.Ratings.Add(new RatingEF { RatingName = dvd.rating });
                repository.SaveChanges();
            }

            var DVD = repository.DVDs.Add(
                new EF.dvdEF
                {
                    dvdId = dvd.dvdId,
                    director = newDirector,
                    notes = dvd.notes,
                    realeaseYear = dvd.realeaseYear,
                    rating = newRating,
                    title = dvd.title
                });
            repository.SaveChanges();

        }

        public void Delete(int dvdid)
        {
            var repository = new DvdLibraryEF();
            var DVD = repository.DVDs.Find(dvdid);
            if (DVD != null)
            {
                dvd deleted = new dvd
                {
                    dvdId = DVD.dvdId,
                    director = DVD.director.DirectorName,
                    notes = DVD.notes,
                    realeaseYear = DVD.realeaseYear,
                    rating = DVD.rating.RatingName,
                    title = DVD.title

                };
                repository.DVDs.Remove(DVD);
                repository.SaveChanges();


            }

        }

        public void Edit(dvd dvd)
        {
            var repository = new DvdLibraryEF();
            var newDirector = repository.Directors.FirstOrDefault(d => d.DirectorName == dvd.director);
            if (newDirector == null)
            {
                newDirector = repository.Directors.Add(new DirectorEF { DirectorName = dvd.director });
                repository.SaveChanges();
            }

            var newRating = repository.Ratings.FirstOrDefault(d => d.RatingName == dvd.rating);
            if (newRating == null)
            {
                newRating = repository.Ratings.Add(new RatingEF { RatingName = dvd.rating });
                repository.SaveChanges();
            }
            var TheDvd = repository.DVDs.FirstOrDefault(d => d.dvdId == dvd.dvdId);


            TheDvd.director = newDirector;
                    TheDvd.notes = dvd.notes;
                    TheDvd.realeaseYear = dvd.realeaseYear;
                    TheDvd.rating = newRating;
                    TheDvd.title = dvd.title;
              
            repository.SaveChanges();
        }

        public dvd Get(int dvdid)
        {
            var repository = new DvdLibraryEF();
            var DVD = repository.DVDs.Find(dvdid);
            dvd returnList = new dvd();
            if (DVD != null)
            {
                returnList.dvdId = DVD.dvdId;
                returnList.director = DVD.director.DirectorName;
                returnList.notes = DVD.notes;
                returnList.realeaseYear = DVD.realeaseYear;
                returnList.rating = DVD.rating.RatingName;
                returnList.title = DVD.title;
                return returnList;
            }
            else
                return null;
        }

        public List<dvd> GetAll()
        {
            var repository = new DvdLibraryEF();
            List<dvd> returnDictionary = new List<dvd>();
            var dvdList = repository.DVDs.ToList();

            foreach (EF.dvdEF t in dvdList)
            {
                returnDictionary.Add(
                new dvd
                {
                    dvdId = t.dvdId,
                    director = t.director.DirectorName,
                    notes = t.notes,
                    realeaseYear = t.realeaseYear,
                    rating = t.rating.RatingName,
                    title = t.title

                });
            }
            return returnDictionary;
        }

        public List<dvd> GetDirector(string dvdDirector)
        {
            var repository = new DvdLibraryEF();
            List<dvd> returnDictionary = new List<dvd>();
            var dvdList = repository.DVDs.ToList();
     

            foreach (EF.dvdEF t in dvdList)
            {
                var DVD = t;
                if (DVD.director.DirectorName ==dvdDirector)
                {
                    returnDictionary.Add(


                    new dvd
                    {
                        dvdId = t.dvdId,
                        director = t.director.DirectorName,
                        notes = t.notes,
                        realeaseYear = t.realeaseYear,
                        rating = t.rating.RatingName,
                        title = t.title

                    });
                };
            }
            return returnDictionary;
        }
        // var DVD = repository.DVDs.All(d => d.director.DirectorName == dvdDirector);

    
        

        public List<dvd> GetName(string dvdTitle)
        {
            var repository = new DvdLibraryEF();
            List<dvd> returnDictionary = new List<dvd>();
            var dvdList = repository.DVDs.ToList();


            foreach (EF.dvdEF t in dvdList)
            {
                var DVD = t;
                if (DVD.title == dvdTitle)
                {
                    returnDictionary.Add(


                    new dvd
                    {
                        dvdId = t.dvdId,
                        director = t.director.DirectorName,
                        notes = t.notes,
                        realeaseYear = t.realeaseYear,
                        rating = t.rating.RatingName,
                        title = t.title

                    });
                };
            }
            return returnDictionary;
        }

        public List<dvd> GetRating(string dvdRating)
        {
            var repository = new DvdLibraryEF();
            List<dvd> returnDictionary = new List<dvd>();
            var dvdList = repository.DVDs.ToList();


            foreach (EF.dvdEF t in dvdList)
            {
                var DVD = t;
                if (DVD.rating.RatingName == dvdRating)
                {
                    returnDictionary.Add(


                    new dvd
                    {
                        dvdId = t.dvdId,
                        director = t.director.DirectorName,
                        notes = t.notes,
                        realeaseYear = t.realeaseYear,
                        rating = t.rating.RatingName,
                        title = t.title

                    });
                };
            }
            return returnDictionary;
        }

        public List<dvd> GetYear(string dvdYear)
        {
            var repository = new DvdLibraryEF();
            List<dvd> returnDictionary = new List<dvd>();
            var dvdList = repository.DVDs.ToList();


            foreach (EF.dvdEF t in dvdList)
            {
                var DVD = t;
                if (DVD.realeaseYear == dvdYear)
                {
                    returnDictionary.Add(


                    new dvd
                    {
                        dvdId = t.dvdId,
                        director = t.director.DirectorName,
                        notes = t.notes,
                        realeaseYear = t.realeaseYear,
                        rating = t.rating.RatingName,
                        title = t.title

                    });
                };
            }
            return returnDictionary;
        }
    }
}