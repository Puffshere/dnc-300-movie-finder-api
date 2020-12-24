using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

            //HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(sURL);
            //myRequest.Method = "GET";
            //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            //byte[] byte1 = new byte[] { }; // encoding.GetBytes(formPost);

            if (Session["sessionMovies"] != null)
            {
                Movies = (List<dnc_300_movie_finder_data.Models.MovieFinderModel>)Session["sessionMovies"];
            }
            else
            {
                // go get from api
            }

            WebRequest request = WebRequest.Create(sURL);
            WebResponse response = request.GetResponse();
            string responseFromServer = "";

            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                responseFromServer = reader.ReadToEnd();
            }

            //Movies = string.Desialize();
            Session["sessionMovies"] = Movies;

            var obj = JsonConvert.DeserializeObject(responseFromServer);
            var formatted = JsonConvert.SerializeObject(obj, Formatting.Indented);

            return View(formatted);
        }
    }
}

