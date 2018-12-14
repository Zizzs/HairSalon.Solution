using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class SpecialityController : Controller
    {
        [HttpGet("/stylists/specialities/showall")]
        public ActionResult ShowAll()
        {
            List<SpecialityClass> allSpecialities = SpecialityClass.GetAll();
            return View(allSpecialities);
        }

        [HttpGet("/stylists/specialities/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/stylists/specialities/new")]
        public ActionResult Create(string speciality)
        {
            SpecialityClass.Save(speciality);
            return RedirectToAction("ShowAll");
        }


    }
}