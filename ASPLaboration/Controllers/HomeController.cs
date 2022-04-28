using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLaboration.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Filmer()
        {
            try
            {
                FilmService.FilmServiceClient Klient = new FilmService.FilmServiceClient();
                List<FilmService.FilmData> filmLista = Klient.GetFilmList().ToList();
                return View(filmLista);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }
    }
}