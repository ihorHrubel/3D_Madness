using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BusketController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext db = new ApplicationDbContext();

        public BusketController()
        {
        }

        public BusketController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /*public void Create(int? dModelId)
        {
        
            /*var busket = db.Buskets.Where(b => b.ApplicationUserId == User.Identity.GetUserId()).First();
            var purchase = new Purchase
            {
                ApplicationUserId = User.Identity.GetUserId(),
            }
            var model = db.DModels.Where(m => m.Id == dModelId);
            if (model != null)
            {
                busket.Purchases(;
                db.SaveChanges();
                
            }
            
        }*/
        public ActionResult Create()
        {
            return View();
        }
    }
}