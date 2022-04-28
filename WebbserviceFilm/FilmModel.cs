namespace WebbserviceFilm
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FilmModel : DbContext
    {
        public FilmModel()
            : base("name=FilmModel")
        {
        }

        public virtual DbSet<Film> Films { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .Property(e => e.Titel)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Regissör)
                .IsUnicode(false);
        }
    }
}
