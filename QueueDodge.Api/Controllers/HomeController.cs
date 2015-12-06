using Microsoft.AspNet.SignalR;
using QueueDodge.Api.Hubs;
using QueueDodge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QueueDodge.Api.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {



            return View("Index");
        }
    }
}