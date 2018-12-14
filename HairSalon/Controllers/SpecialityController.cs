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

        [HttpGet("/stylists/specialities/join")]
        public ActionResult Join()
        {
            Dictionary<string, object> specialitiesStylists = new Dictionary<string, object> {};
            List<StylistClass> stylists = StylistClass.GetAll();
            List<SpecialityClass> specialities = SpecialityClass.GetAll();
            specialitiesStylists.Add("stylists", stylists);
            specialitiesStylists.Add("specialities", specialities);
            
            return View(specialitiesStylists);
        }

        [HttpPost("/stylists/specialities/join")]
        public ActionResult JoinCreate(int stylistId, int specialityId)
        {
            SpecialityClass.SaveSpecialtyToStylist(stylistId, specialityId);
            return RedirectToAction("Index", "Stylist");
        }

        [HttpGet("/stylists/specialities/{id}")]
        public ActionResult Show(int id)
        {
            Dictionary<string, object> allInfo = new Dictionary<string, object> {};
            SpecialityClass speciality = SpecialityClass.FindBySpecialityId(id);
            List<StylistClass> allStylists = StylistClass.GetAllStylistsBySpecialityId(id);
            allInfo.Add("speciality", speciality);
            allInfo.Add("stylists", allStylists);

            return View(allInfo);
        }

        [HttpGet("/stylists/specialities/deleteall")]
        public ActionResult DeleteAll()
        {
            SpecialityClass.ClearAll();
            SpecialityClass.ClearAllFromJoin();
            return RedirectToAction("Index", "Stylist");
        }

        [HttpGet("/stylists/specialities/{id}/delete")]
        public ActionResult Delete(int id)
        {
            SpecialityClass.DeleteSpecialitysBySpecialitytId(id);
            SpecialityClass.DeleteSpeciality(id);
            return View();
        }
    }
}