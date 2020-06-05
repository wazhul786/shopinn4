using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopinn4.Models;
using shopinn4.Databasecontext;

namespace shopinn4.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        Modeldbcontext db = new Modeldbcontext();
        public ActionResult Index(string x = "")
        {
            if (Session["admin"] == null)
            {
                ViewBag.msg = x;
                return View();
            }
            else
            {
                return RedirectToAction("admin_prof");
            }
        }
        [HttpPost]
        public ActionResult Index(admin acc)
        {
            var usr = db.adm.Where(v => v.AdminId == acc.AdminId && v.Password == acc.Password).FirstOrDefault();
            if (usr == null)
            {
                ViewBag.msg = "Check yur ID r Passwrd";
                return View();
            }
            else
            {
                Session["admin"] = usr.AdminId;
                return RedirectToAction("admin_prof");
            }
        }
        public ActionResult admin_prof()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", new { x = "Please Login First" });
            }
            else
            {
                return View();
            }
        }
        public ActionResult Catagory()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", new { x = "Please Login First" });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Catagory(Catagory acc)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", new { x = "Please Login First" });
            }
            else
            {
                var usr = db.cat.Where(v => v.cat == acc.cat).FirstOrDefault();
                if (usr == null)
                {
                    db.cat.Add(acc);
                    db.SaveChanges();
                    ViewBag.msg = "added successfully";
                    return View();
                }
                else
                {
                    ViewBag.msg = "Catagory Already exist";
                    return View();
                }
            }
        }
        public ActionResult Product()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", new { x = "Please Login First" });
            }
            else
            {
                var list = db.cat.ToList();
                ViewBag.list = list;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Product(Product acc)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", new { x = "Please Login First" });
            }
            else
            {
                var usr = db.prod.Where(v => v.ProductName == acc.ProductName).FirstOrDefault();
                var list = db.cat.ToList();
                ViewBag.list = list;
                if (usr == null)
                {
                    db.prod.Add(acc);
                    db.SaveChanges();
                    ViewBag.msg = "added successfully";
                    return View();
                }
                else
                {
                    ViewBag.msg = "Product Already exist";
                    return View();
                }
            }
        }
        public ActionResult Orders()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", new { x = "Please Login First" });
            }
            else
            {
                var list = db.odr.ToList();
                return View(list);
            }
        }
        public ActionResult Feedback()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", new { x = "Please Login First" });
            }
            else
            {
                var list = db.fdbk.ToList();
                return View(list);
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", new { x = "Successfully Logout" });
        }

    }
}
