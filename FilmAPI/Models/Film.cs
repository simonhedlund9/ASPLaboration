namespace FilmAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Film")]
    public partial class Film
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Titel { get; set; }

        [Required]
        [StringLength(50)]
        public string Regissör { get; set; }

        public int År { get; set; }
    }
}
