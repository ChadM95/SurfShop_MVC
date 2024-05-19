using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;


namespace SurfShop_MVC.Controllers
{
    public class SurfController : Controller
    {
        // GET: Surf
        public ActionResult Surf()
        {
            //create new http client
            HttpClient client1 = new HttpClient();

            //set client base address
            client1.BaseAddress = new Uri("http://localhost:56348/api/");

            //request from api
            var httpResponseMsg = client1.GetAsync("surfspots");

            httpResponseMsg.Wait();

            var responseMsgFromApi = httpResponseMsg.Result;

            if (responseMsgFromApi.IsSuccessStatusCode)
            {
                var taskObject = responseMsgFromApi.Content.ReadAsAsync<List<SurfSpot>>();

                taskObject.Wait();

                //Finally store the result of this task in a variable to be returned
                var theValueToDisplay = taskObject.Result;

                //add to viewbag to pass to view
                ViewBag.InfoFromApi = theValueToDisplay;

                return View(theValueToDisplay);
            }

            else
            return View();
        }
    }
}