using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class ArtistVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Stage Name")]
        [StringLength(25)]
        public string StageName { get; set; }
        [Display(Name = "Real Name")]
        [StringLength(40)]
        public string RealName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        [Display(Name = "Lives in")]
        [StringLength(30)]
        public string CityofLiving { get; set; }
        [Display(Name = "Height(in cm)")]
        public byte Height { get; set; }
        [Display(Name = "Best Song")]
        public int SongId { get; set; }
        [Display(Name = "Best Album")]
        public int AlbumId { get; set; }
        public SongVM SongVM { get; set; }
        public AlbumVM AlbumVM { get; set; }

        public ArtistVM() { }

        public ArtistVM(ArtistDTO artistDTO)
        {
            Id = artistDTO.Id;
            StageName = artistDTO.StageName;
            RealName = artistDTO.RealName;
            Birthday = artistDTO.Birthday;
            CityofLiving = artistDTO.CityofLiving;
            Height = artistDTO.Height;
            SongId = artistDTO.SongId;
            SongVM = new SongVM
            {
                Id = artistDTO.SongId,
                Title = artistDTO.Song.Title,
                TopChart = artistDTO.Song.TopChart,
                Genre = artistDTO.Song.Genre,
                ReleaseDate = artistDTO.Song.ReleaseDate,
                Author = artistDTO.Song.Author,
                Length = artistDTO.Song.Length
            };
            AlbumId = artistDTO.AlbumId;
            AlbumVM = new AlbumVM
            {
                Id = artistDTO.AlbumId,
                Title = artistDTO.Album.Title,
                Genre = artistDTO.Album.Genre,
                ReleaseDate = artistDTO.Album.ReleaseDate,
                CopiesSold = artistDTO.Album.CopiesSold,
                SongsNumber = artistDTO.Album.SongsNumber
            };

        }
        
    }
}