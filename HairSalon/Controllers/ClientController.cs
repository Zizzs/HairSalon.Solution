using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/stylists/clients/new")]
        public ActionResult New()
        {
            List<StylistClass> allStylists = StylistClass.GetAll();
            return View(allStylists);
        }

        [HttpPost("/stylists/clients/new")]
        public ActionResult CreateClient(string clientName, int stylistId)
        {
            ClientClass client = new ClientClass(clientName, stylistId);
            client.Save();
            return RedirectToAction("ShowAll");
        }

        [HttpGet("/stylists/clients/{id}/delete")]
        public ActionResult Delete(int id)
        {
            ClientClass.Delete(id);
            return View();
        }

        [HttpGet("/stylists/clients/{id}")]
        public ActionResult Show(int id)
        {
            ClientClass client = ClientClass.GetClientById(id);
            return View(client);
        }

        [HttpGet("/stylists/clients/showall")]
        public ActionResult ShowAll()
        {
            List<ClientClass> clientList = ClientClass.GetAll();
            return View(clientList);
        }

        [HttpGet("/stylists/clients/deleteall")]
        public ActionResult DeleteAll()
        {
            ClientClass.ClearAll();
            return RedirectToAction("ShowAll");
        }

        [HttpGet("/stylists/clients/{id}/edit")]
        public ActionResult Edit(int id)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object>();
            ClientClass client = ClientClass.GetClientById(id);
            List<StylistClass> stylists = StylistClass.GetAll();
            allInfo.Add("client", client);
            allInfo.Add("stylists", stylists);
            return View("Update", allInfo);
        }

        [HttpPost("/stylists/clients/{id}/edit")]
        public ActionResult Update(int id, string clientName, int stylistId)
        {
            ClientClass.UpdateName(id, clientName);
            ClientClass.UpdateStylist(id, stylistId);
            return RedirectToAction("Show", id);
        }

        [HttpPost("/stylists/searchclient")]
        public ActionResult Search(string clientName)
        {
            ClientClass client = ClientClass.FindByName(clientName);
            int id = client.GetId();
            return RedirectToAction("Show" , new {id});
        }
    }
}