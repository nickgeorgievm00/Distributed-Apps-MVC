using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class AlbumVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(35)]
        public string Genre { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Copies Sold")]
        public long CopiesSold { get; set; }
        [Display(Name = "Number of songs")]
        public byte SongsNumber { get; set; }

        public AlbumVM() { }

        public AlbumVM(AlbumDTO albumDTO)
        {
            Id = albumDTO.Id;
            Title = albumDTO.Title;
            Genre = albumDTO.Genre;
            ReleaseDate = albumDTO.ReleaseDate;
            CopiesSold = albumDTO.CopiesSold;
            SongsNumber = albumDTO.SongsNumber;
        }
    }
}