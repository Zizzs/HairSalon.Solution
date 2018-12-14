using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
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
            return View();
        }

        [HttpPost("/stylists/new")]
        public ActionResult Create(string stylistName)
        {
            StylistClass.Save(stylistName);
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<StylistClass> stylistList = StylistClass.FindById(id);
            List<ClientClass> clientList = ClientClass.GetAllClientsByStylistId(id);
            allInfo.Add("stylists", stylistList);
            allInfo.Add("clients", clientList);
            return View(allInfo);
        }

        [HttpGet("/stylists/{id}/delete")]
        public ActionResult Delete(int id)
        {
            ClientClass.DeleteClientsByStylistId(id);
            StylistClass.Delete(id);
            return View();
        }


        [HttpPost("/stylists/search/stylist")]
        public ActionResult SearchStylist(string name)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            List<StylistClass> stylistList = new List<StylistClass>() {};
            StylistClass stylist = StylistClass.FindByName(name);
            List<ClientClass> clientList = ClientClass.GetAllClientsByStylistId(stylist.GetId());
            Console.WriteLine(stylist.GetName());
            stylistList.Add(stylist);
            allInfo.Add("stylists", stylistList);
            allInfo.Add("clients", clientList);
            return View("ShowStylist", allInfo);
        }

        [HttpGet("/stylists/search")]
        public ActionResult ShowClientAndStylistSearch(int id)
        {
            return View("Search");
        }
    }
}