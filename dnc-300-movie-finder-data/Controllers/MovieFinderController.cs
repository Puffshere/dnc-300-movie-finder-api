using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace dnc_300_movie_finder_data.Controllers
{
    public class MovieFinderController : Controller
    {
        public List<dnc_300_movie_finder_data.Models.MovieFinderModel> Movies;
        public ActionResult FindMovie()
        {
            string sURL = "http://www.omdbapi.com/?apikey=3b0ec9e3&i=tt0111161";
            string responseFromServer = "";

            WebRequest request = WebRequest.Create(sURL);
            WebResponse response = request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
            }

            //Adds formatting to return Json using Newtonsoft.Json
            var obj = JsonConvert.DeserializeObject(responseFromServer);
            var formattedMovieData = JsonConvert.SerializeObject(obj, Formatting.Indented);

            //Movies = string.Desialize();
            Session["sessionMovies"] = Movies;

            if (Session["sessionMovies"] != null)
            {
                Movies = (List<dnc_300_movie_finder_data.Models.MovieFinderModel>)Session["sessionMovies"];
            }
            else
            {
                // go get from api
            }

            return View(formattedMovieData);
        }
    }
}
