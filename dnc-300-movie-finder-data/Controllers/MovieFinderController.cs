using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;

namespace dnc_300_movie_finder_data.Controllers
{
    public class MovieFinderController : Controller
    {
        //public string FindMovie(string MovieData = "Hello")
        //{
        //    return MovieData;
        //}
        public ActionResult Index()
        {
            return View();
        }
    }
}
