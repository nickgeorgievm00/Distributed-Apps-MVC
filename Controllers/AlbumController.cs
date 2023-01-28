using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AlbumController : Controller
    {
        // GET: Album
        public ActionResult Index()
        {
            List<AlbumVM> albumsVM = new List<AlbumVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetAlbums())
                {
                    albumsVM.Add(new AlbumVM(item));

                }
            }

            return View(albumsVM);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumVM albumVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        AlbumDTO albumDTO = new AlbumDTO
                        {
                            Title = albumVM.Title,
                            Genre = albumVM.Genre,
                            ReleaseDate = albumVM.ReleaseDate,
                            CopiesSold = albumVM.CopiesSold,
                            SongsNumber = albumVM.SongsNumber
                        };
                        service.PostAlbum(albumDTO);

                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            AlbumVM albumVM = new AlbumVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var albumDTO = service.GetAlbumById(id);
                albumVM = new AlbumVM(albumDTO);
            }

            return View(albumVM);
        }
        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteAlbum(id);
            }
            return RedirectToAction("Index");
        }
    }
}