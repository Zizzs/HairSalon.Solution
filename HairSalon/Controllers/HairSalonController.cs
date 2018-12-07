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
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<StylistClass> allStylists = StylistClass.GetAll();
            List<ClientClass> allClients = ClientClass.GetAll();
            allInfo.Add("stylists", allStylists);
            allInfo.Add("clients", allClients);
            return View(allInfo);
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
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult ShowStylist(int id)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<StylistClass> stylistList = StylistClass.FindById(id);
            List<ClientClass> clientList = ClientClass.GetAllClientsByStylistId(id);
            allInfo.Add("stylists", stylistList);
            allInfo.Add("clients", clientList);
            return View("ShowStylist", allInfo);
        }
    }
}
