using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SongController : Controller
    {
        // GET: Song
        public ActionResult Index()
        {
            List<SongVM> songsVM = new List<SongVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetSongs())
                {
                    songsVM.Add(new SongVM(item));
                }
            }

            return View(songsVM);
        }

        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SongVM songVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                    {
                        SongDTO songDTO = new SongDTO
                        {
                            Title = songVM.Title,
                            TopChart = songVM.TopChart,
                            Genre = songVM.Genre,
                            ReleaseDate = songVM.ReleaseDate,
                            Author = songVM.Author,
                            Length = songVM.Length
                        };
                        service.PostSong(songDTO);

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
            SongVM songVM = new SongVM();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                var songDTO = service.GetSongById(id);
                songVM = new SongVM(songDTO);
            }

            return View(songVM);
        }
        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteSong(id);
            }
            return RedirectToAction("Index");
        }

    }
}