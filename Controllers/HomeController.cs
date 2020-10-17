using Magazyn.Database;
using Magazyn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Magazyn.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tutaj znajdziesz wszystkie informacje o magazynie.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Strona kontaktowa.";

            return View();
        }

        public ActionResult Login()
        {
            if (Session["ID"] == null)
            {
                return View();
            }
            else
            {
                TempData["Loged"] = "Jesteś już zalogowany.";
                return RedirectToAction("UserLoged");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                using (DatabaseAccess db = new DatabaseAccess())
                {
                    var obj = db.User.Where(x => x.UserName.Equals(user.UserName) && x.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["ID"] = obj.ID.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("UserLoged");
                    }
                    else
                    {
                        ViewBag.UserError = "Wpisane dane są błędne";
                    }
                }
            }
            return View(user);
        }

        public ActionResult UserLoged()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                TempData["NeedLogin"] = "Musisz się zalogować, aby zarządzać swoim profilem.";
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session["ID"] = null;
            Session.RemoveAll();
            TempData["Logout"] = "Wylogowano";
            return RedirectToAction("Index", "Home");
        }
    }
}