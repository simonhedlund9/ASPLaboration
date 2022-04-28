namespace FilmAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FilmModell : DbContext
    {
        public FilmModell()
            : base("name=FilmModell")
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
