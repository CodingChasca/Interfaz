using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Http;
using Interfaz.Models;
using System;

namespace Interfaz.Controllers
{
    public class HomeController : Controller
    {
        private string url = "http://10.210.37.236/API/";
        private UpdateHistory history = new UpdateHistory();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SocialNetwork()
        {
            return View();
        }

        public ActionResult FollowersCount()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetUsername(string name)
        {
            string mensaje = await CallAPIAsync(url+"publicacion/"+name);
            ViewBag.Likes = "Se ha registrado el usuario";
            return View("~/Views/home/FollowersCount.cshtml");
        }

        public async Task<ActionResult> UpdateFollowers()
        {
            string result = await CallAPIAsync(url + "ganador");
            DateTime time = DateTime.UtcNow;
            int likes = int.Parse(await CallAPIAsync(url + "likes/1"));
            if (result.Equals("\"\""))
            {
                ViewBag.Likes = "Van " + likes + " likes";
            }
            else
            {
                ViewBag.Likes = "El usuario ganador es " + result;
            }
            Memento m = new Memento(likes, time);
            history.AddMemento(m);
            return View("~/Views/home/FollowersCount.cshtml");
        }
        
        static async Task<string> CallAPIAsync(string path)
        {
            string res = null;
            HttpClient client = new HttpClient();
            
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                res = await response.Content.ReadAsStringAsync();
            }
            return res;
        }
    }
}