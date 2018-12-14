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
        public ActionResult Edit(int id)
        {
            StylistClass stylist = StylistClass.FindById(id);
            return View("Update", stylist);
        }

        [HttpPost("/stylists/{id}/edit")]
        public ActionResult Update(int id, string stylistName)
        {
            StylistClass.UpdateName(id, stylistName);
            return RedirectToAction("Show", id);
        }
    }
}