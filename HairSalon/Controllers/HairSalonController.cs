using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class HairSalonController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<StylistClass> allStylists = StylistClass.GetAll();
            return View(allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/stylists/new")]
        public ActionResult Create(string stylistName)
        {
            StylistClass stylist = new StylistClass(stylistName);
            stylist.Save();
            List<StylistClass> allStylists = StylistClass.GetAll();
            return View("Index", allStylists);
        }
    }
}
