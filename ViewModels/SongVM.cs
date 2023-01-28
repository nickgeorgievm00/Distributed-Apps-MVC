using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class SongVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(25)]
        public string Genre { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        [StringLength(40)]
        public string Author { get; set; }
        [Display(Name = "Highest BG Chart ranking")]
        public byte TopChart { get; set; }
        public TimeSpan Length { get; set; }

        public SongVM() { }

        public SongVM(SongDTO songDTO)
        {
            Id = songDTO.Id;
            Title = songDTO.Title;
            TopChart = songDTO.TopChart;
            Genre = songDTO.Genre;
            ReleaseDate = songDTO.ReleaseDate;
            Length = songDTO.Length;
            Author = songDTO.Author;
        }
    }
}