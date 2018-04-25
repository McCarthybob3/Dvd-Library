namespace DVDLibraryApplication
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DVDLibraryApplication.EF;

    public partial class DvdLibraryEF : DbContext
    {
        public DvdLibraryEF()
            : base("DvdLibraryEF")
        {
        }

        public virtual DbSet<DirectorEF> Directors { get; set; }
        public virtual DbSet<dvdEF> DVDs { get; set; }
        public virtual DbSet<RatingEF> Ratings { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DirectorEF>()
        //    .Property(e => e.DirectorName)
        //    .IsFixedLength()
        //    .IsUnicode(false);
      

        //    modelBuilder.Entity<dvdEF>()
        //        .Property(e => e.title)
        //        .IsFixedLength()
        //        .IsUnicode(false);

        //    modelBuilder.Entity<dvdEF>()
        //      .Property(e => e.ratingId)
              
              

        //    modelBuilder.Entity<dvdEF>()
        //      .Property(e => e.directorId)
              
              

        //    modelBuilder.Entity<dvdEF>()
        //        .Property(e => e.realeaseYear)
        //        .IsFixedLength()
        //        .IsUnicode(false);

        //    modelBuilder.Entity<dvdEF>()
        //        .Property(e => e.notes)
        //        .IsFixedLength()
        //        .IsUnicode(false);

        //    modelBuilder.Entity<RatingEF>()
        //        .Property(e => e.RatingName)
        //        .IsFixedLength()
        //        .IsUnicode(false);

          
        //}
    }
}
