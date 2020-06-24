using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RandomMovie.Data
{
    public static class MoviesManager
    {
        public const string BaseUrl = "https://www.omdbapi.com/";
        public const string ApiKey = "?i=tt3896198&apikey=5fb154eb";
        public static string templateUrl = BaseUrl + ApiKey;

        public static async Task<Movie> GetMovieByTitle(string Title)
        {
            string searchUrl = $"{templateUrl}&t={Title}";
            HttpClient client = new HttpClient();

            string result = await client.GetStringAsync(searchUrl);
            return JsonConvert.DeserializeObject<Movie>(result);
        }


    }
}
