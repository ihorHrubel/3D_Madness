using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize]
    public class BusketController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult AddToBusket(int? Id)
        {
            var model = db.DModels.Where(m => m.Id == Id).First();
            var id = User.Identity.GetUserId();
            var busket = db.Buskets.Include(b => b.Models).Where(b => b.Id == id).First();
            busket.Models.Add(model);
            db.SaveChanges();
            return RedirectToAction("Details", "DModels", new { Id = Id });
        }

        public ActionResult DeleteFromBusket(int? Id)
        {
            var model = db.DModels.Where(m => m.Id == Id).First();
            var id = User.Identity.GetUserId();
            var busket = db.Buskets.Include(b => b.Models).Where(b => b.Id == id).First();
            busket.Models.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index", "DModels", new { Id = Id });
        }

        public bool IsAdded(string busketId , int modelId)
        {
            var busket = db.Buskets.Include(b => b.Models).Where(b => b.Id == busketId).First();
            if ((busket.Models.Where(m => m.Id == modelId).Count() == 0))
            {
                return false;
            }
            return true;
        } 
    }
}