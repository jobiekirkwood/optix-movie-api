using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Release Date")]
        public DateOnly ReleaseDate { get; set; }
        public string Title { get; set; }

        [Column(TypeName = "varchar(MAX)")]
        public string Overview { get; set; }

        public float Popularity { get; set; }

        [Display(Name ="Vote Count")]
        public int VoteCount { get; set; }

        [Display(Name = "Vote Average")]

        public float VoteAverage { get; set; }

        [Column(TypeName = "varchar(2)")]

        [Display(Name = "Original Language")]
        public string OriginalLanguage { get; set; }

        public string Genre { get; set; }
        
        [Display(Name = "Poster URL")]
        public string Poster_Url { get; set; }

    }
}
