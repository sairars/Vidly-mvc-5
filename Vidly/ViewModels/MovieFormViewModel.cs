using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        public short? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }


        public string Title 
        { 
            get
            {
                return (Id == 0) ? "New" : "Edit";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
            Name = movie.Name;
            GenreId = movie.GenreId;
        }
    }
}