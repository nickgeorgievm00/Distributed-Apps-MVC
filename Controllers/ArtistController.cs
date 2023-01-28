using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ArtistController : Controller
    {
        public ActionResult Index()
        {
            List<ArtistVM> artistsVM = new List<ArtistVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())

            {
                foreach (var item in service.GetArtists())
                {
                    artistsVM.Add(new ArtistVM(item));
                }
            }

            return View(artistsVM);
        }

        public ActionResult Details(int id)
        {
            ArtistVM artistVM = new ArtistVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var artistDTO = service.GetArtistById(id);
                artistVM = new ArtistVM(artistDTO);
            }

            return View(artistVM);
        }

        public ActionResult Create()
        {
            ViewBag.Songs = Helpers.LoadDataUtilities.LoadSongData();
            ViewBag.Albums = Helpers.LoadDataUtilities.LoadAlbumData();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistVM artistVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    ArtistDTO artistDTO = new ArtistDTO
                    {
                        StageName = artistVM.StageName,
                        RealName = artistVM.RealName,
                        Birthday = artistVM.Birthday,
                        CityofLiving = artistVM.CityofLiving,
                        Height = artistVM.Height,
                        SongId = artistVM.SongId,
                        Song = new SongDTO
                        {
                            Id = artistVM.SongId
                        },
                        AlbumId = artistVM.AlbumId,
                        Album = new AlbumDTO
                        {
                            Id = artistVM.AlbumId
                        }
                    };
                    service.PostArtist(artistDTO);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Songs = Helpers.LoadDataUtilities.LoadSongData();
                ViewBag.Albums = Helpers.LoadDataUtilities.LoadAlbumData();
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteArtist(id);
            }
            return RedirectToAction("Index");
        }
    }
}