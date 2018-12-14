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
    }
}