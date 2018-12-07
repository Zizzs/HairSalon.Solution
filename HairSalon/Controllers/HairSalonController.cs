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
            return View("NewStylist");
        }

        [HttpPost("/stylists/new")]
        public ActionResult CreateStylist(string stylistName)
        {
            StylistClass stylist = new StylistClass(stylistName);
            stylist.Save();
            List<StylistClass> allStylists = StylistClass.GetAll();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/clients/new")]
        public ActionResult Show()
        {
            List<StylistClass> allStylists = StylistClass.GetAll();
            return View("NewClient", allStylists);
        }

        [HttpPost("/stylists/clients/new")]
        public ActionResult CreateClient(string clientName, int stylistId)
        {
            ClientClass client = new ClientClass(clientName, stylistId);
            client.Save();
            List<ClientClass> allClients = ClientClass.GetAll();
            return View("Index", allClients);
        }
    }
}
