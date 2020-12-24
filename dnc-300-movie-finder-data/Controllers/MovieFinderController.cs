using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace dnc_300_movie_finder_data.Controllers
{
    public class MovieFinderController : Controller
    {
        public List<dnc_300_movie_finder_data.Models.MovieFinderModel> Movies;

        public ActionResult FindMovie()
        {
            string movieTitle = "Ironman";
            string movieId = "tt0231426";
            bool which = false;
            string param1 = "";

            string sURL = "http://www.omdbapi.com/?apikey=3b0ec9e3&t=";

            string param = sURL;

            char first = param[0];
            char second = param[1];
            char last = param[param.Length - 1];

            Console.WriteLine(last);

            if (param == "i")
            {
                which = true;
            }
            else
            {
                which = false;
            }

            if (!which)
            {
                param1 = movieTitle;
            }
            else
            {
                param1 = movieId;
            };

            string fullSURL = sURL + param1;

            string responseFromServer = "";

            WebRequest request = WebRequest.Create(fullSURL);
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