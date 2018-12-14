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
            return View();
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
            return RedirectToAction("ShowAll");
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            StylistClass stylist = StylistClass.FindById(id);
            List<ClientClass> clientList = ClientClass.GetAllClientsByStylistId(id);
            allInfo.Add("stylists", stylist);
            allInfo.Add("clients", clientList);
            return View(allInfo);
        }

        [HttpGet("/stylists/showall")]
        public ActionResult ShowAll()
        {
            List<StylistClass> stylistList = StylistClass.GetAll();
            return View(stylistList);
        }

        [HttpGet("/stylists/{id}/delete")]
        public ActionResult Delete(int id)
        {
            ClientClass.DeleteClientsByStylistId(id);
            StylistClass.Delete(id);
            return View();
        }

        [HttpGet("/stylists/deleteall")]
        public ActionResult DeleteAll()
        {
            StylistClass.ClearAll();
            return RedirectToAction("ShowAll");
        }

        [HttpGet("/stylists/{id}/edit")]
        public ActionResult Update(int id)
        {
            StylistClass.FindById(id);
            return RedirectToAction("Update", id);
        }
        // [HttpPost("/stylists/search/stylist")]
        // public ActionResult SearchStylist(string name)
        // {
        //     Dictionary<string, object> allInfo = new Dictionary<string, object>();
        //     List<StylistClass> stylistList = new List<StylistClass>() {};
        //     StylistClass stylist = StylistClass.FindByName(name);
        //     List<ClientClass> clientList = ClientClass.GetAllClientsByStylistId(stylist.GetId());
        //     Console.WriteLine(stylist.GetName());
        //     stylistList.Add(stylist);
        //     allInfo.Add("stylists", stylistList);
        //     allInfo.Add("clients", clientList);
        //     return View("ShowStylist", allInfo);
        // }

        // [HttpGet("/stylists/search")]
        // public ActionResult ShowClientAndStylistSearch(int id)
        // {
        //     return View("Search");
        // } 
    }
}