using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class HairSalonController : Controller
    {
        // [HttpGet("/stylists")]
        // public ActionResult Index()
        // {
        //     Dictionary<string, object> allInfo = new Dictionary<string, object>();
        //     List<StylistClass> allStylists = StylistClass.GetAll();
        //     List<ClientClass> allClients = ClientClass.GetAll();
        //     allInfo.Add("stylists", allStylists);
        //     allInfo.Add("clients", allClients);
        //     return View(allInfo);
        // }

        // [HttpGet("/stylists/new")]
        // public ActionResult New()
        // {
        //     return View("NewStylist");
        // }

        // [HttpPost("/stylists/new")]
        // public ActionResult CreateStylist(string stylistName)
        // {
        //     StylistClass.Save(stylistName);
        //     return RedirectToAction("Index");
        // }

        // [HttpGet("/stylists/clients/new")]
        // public ActionResult Show()
        // {
        //     List<StylistClass> allStylists = StylistClass.GetAll();
        //     return View("NewClient", allStylists);
        // }

        // [HttpPost("/stylists/clients/new")]
        // public ActionResult CreateClient(string clientName, int stylistId)
        // {
        //     ClientClass client = new ClientClass(clientName, stylistId);
        //     client.Save();
        //     return RedirectToAction("Index", "StylistController");
        // }

        // [HttpGet("/stylists/{id}")]
        // public ActionResult ShowStylist(int id)
        // {
        //     Dictionary<string, object> allInfo = new Dictionary<string, object>();
        //     List<StylistClass> stylistList = StylistClass.FindById(id);
        //     List<ClientClass> clientList = ClientClass.GetAllClientsByStylistId(id);
        //     allInfo.Add("stylists", stylistList);
        //     allInfo.Add("clients", clientList);
        //     return View("ShowStylist", allInfo);
        // }

        // [HttpGet("/stylists/{id}/delete")]
        // public ActionResult DeleteStylistAndStylistClients(int id)
        // {
        //     ClientClass.DeleteClientsByStylistId(id);
        //     StylistClass.Delete(id);
        //     return View("DeleteStylist");
        // }

        // [HttpGet("/stylists/clients/{id}/delete")]
        // public ActionResult DeleteClient(int id)
        // {
        //     ClientClass.Delete(id);
        //     return View("DeleteClient");
        // }

        // [HttpGet("/stylists/clients/{id}")]
        // public ActionResult ShowClient(int id)
        // {
        //     List<ClientClass> client = ClientClass.GetClientsById(id);
        //     return View("ShowClient", client);
        // }


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
    }
}
