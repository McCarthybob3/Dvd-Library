namespace DVDLibraryApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DVDLibraryApplication.EF;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDLibraryApplication.DvdLibraryEF>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDLibraryApplication.DvdLibraryEF context)
        {
          
            context.Directors.AddOrUpdate(
                    g => g.DirectorName,
                    new DirectorEF { DirectorName = "Georgie" }
              
                );

            context.Ratings.AddOrUpdate(
                r => r.RatingName,
                new RatingEF { RatingName = "G" },
                new RatingEF { RatingName = "PG" },
                new RatingEF { RatingName = "PG-13" },
                new RatingEF { RatingName = "R" }
            );

            context.SaveChanges();

            context.DVDs.AddOrUpdate(
                m => m.title,
                new dvdEF
                {
                    title = "Star Wars",
                    directorId = context.Directors.First(g => g.DirectorName == "Georgie").DirectorId,
                    ratingId = context.Ratings.First(r => r.RatingName == "PG").RatingId,
                    realeaseYear = "1972",
                    notes = "not my thing"

                }

            );

            context.DVDs.AddOrUpdate(
          m => m.title,
          new dvdEF
          {
              title = "Star Wars 2",
              directorId = context.Directors.First(g => g.DirectorName == "Sci-Fi").DirectorId,
              ratingId = context.Ratings.First(r => r.RatingName == "PG").RatingId,
              realeaseYear = "1973",
              notes = "not my thing"

          }

      );

        }
    }
}

