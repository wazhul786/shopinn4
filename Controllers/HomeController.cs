using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopinn4.Models;
using shopinn4.Databasecontext;

namespace shopinn4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        Modeldbcontext db = new Modeldbcontext();
        public ActionResult Index(string x = "", string y = "")
        {
            var usr1 = Session["user"];
            if (Session["user"] != null)
            {

                var usr2 = db.reg.Where(v => v.EmailId == usr1).FirstOrDefault();
                ViewBag.name = usr2.Name;

            }
            ViewBag.count = db.crt.Where(v => v.EmailId == usr1).Count();
            var cat = db.cat.ToList();
            ViewBag.cat1 = cat;
            var prod = db.prod.ToList();
            ViewBag.prod1 = prod;
            ViewBag.num = db.prod.Count();
            ViewBag.x = x;
            ViewBag.y = y;
            return View();
        }
        public ActionResult Prod_details(int x = 0, string y = "")
        {
            var usr1 = Session["user"];
            if (Session["user"] != null)
            {

                var usr2 = db.reg.Where(v => v.EmailId == usr1).FirstOrDefault();
                ViewBag.name = usr2.Name;

            }
            ViewBag.count = db.crt.Where(v => v.EmailId == usr1).Count();
            var cat = db.cat.ToList();
            ViewBag.cat1 = cat;
            var details = db.prod.Where(v => v.ID == x).FirstOrDefault();
            ViewBag.y = y;

            return View(details);
        }
        public ActionResult Cart(int x = 0)
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Prod_details", new { x = x, y = "Please Login First" });
            }
            else
            {
                var ss = db.prod.Where(v => v.ID == x).FirstOrDefault();
                var usr1 = Session["user"];
                var usr2 = db.reg.Where(v => v.EmailId == usr1).FirstOrDefault();
                var ss1 = new Cart();
                ss1.Category = ss.Category;
                ss1.ProductName = ss.ProductName;
                ss1.ProductImage = ss.ProductImage;
                ss1.ProductPrice = ss.ProductPrice;
                ss1.Offer = ss.Offer;
                ss1.Name = usr2.Name;
                ss1.Gender = usr2.Gender;
                ss1.EmailId = usr2.EmailId;
                ss1.PhoneNo = usr2.PhoneNo;
                ss1.Address = usr2.Address;
                ss1.City = usr2.City;
                ss1.Country = usr2.Country;
                ss1.DateOfBirth = usr2.DateOfBirth;

                db.crt.Add(ss1);
                db.SaveChanges();
                return RedirectToAction("Prod_details", new { x = x, y = "Added Successfully" });
            }
        }
        public ActionResult Cart_list(int x = 0, int num = 0, string m = "")
        {
            var usr1 = Session["user"];
            if (Session["user"] != null)
            {
                var usr2 = db.reg.Where(v => v.EmailId == usr1).FirstOrDefault();
                ViewBag.name = usr2.Name;
                ViewBag.count = db.crt.Where(v => v.EmailId == usr1).Count();

                var cart_list = db.crt.Where(v => v.EmailId == usr1).ToList();
                ViewBag.cart_list = cart_list;
                ViewBag.m = m;
                return View();
            }
            else
            {
                if (num == 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Prod_details", new { x = x });
                }
            }
        }
        public ActionResult Remove(int x = 0)
        {
            var usr1 = Session["user"];
            if (Session["user"] != null)
            {
                var ss = db.crt.Where(v => v.ID == x).FirstOrDefault();
                db.crt.Remove(ss);
                db.SaveChanges();
                return RedirectToAction("Cart_list");
            }
            else
            {
                return RedirectToAction("Cart_list");
            }
        }
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(Feedback acc)
        {
            db.fdbk.Add(acc);
            db.SaveChanges();
            ViewBag.m1 = "send your query successfully";
            return View();
        }
        public ActionResult Proceed(int s = 0)
        {
            var usr1 = Session["user"];
            if (Session["user"] != null)
            {
                var usr2 = db.reg.Where(v => v.EmailId == usr1).FirstOrDefault();
                ViewBag.name = usr2.Name;
                ViewBag.count = db.crt.Where(v => v.EmailId == usr1).Count();

                var cart_list = db.crt.Where(v => v.EmailId == usr1).ToList();
                ViewBag.cart_list = cart_list;
                ViewBag.s = s;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Proceed(Cart acc, DateTime CurrentDate, string bank, string accnum, string ordernum, int TotalPrice)
        {
            var usr1 = Session["user"];
            if (Session["user"] != null)
            {
                Orders ss1 = new Orders();
                var ss = db.crt.Where(v => v.PhoneNo == acc.PhoneNo).ToList();
                foreach (var q in ss)
                {
                ss1.Category = q.Category;
                ss1.ProductName = q.ProductName;
                ss1.ProductImage = q.ProductImage;
                ss1.ProductPrice = q.ProductPrice.ToString();
                ss1.Offer = q.Offer.ToString();
                ss1.TotalPrice = TotalPrice;
                ss1.UserName = q.Name;
                ss1.AccountNo = accnum;
                ss1.MobileNo = q.PhoneNo;
                ss1.Address = q.Address;
                ss1.Bank = bank;
                ss1.City = q.City;
                ss1.OrderNo = ordernum;
                ss1.CurrentDate = CurrentDate;

                    db.odr.Add(ss1);
                    db.SaveChanges();

                        db.crt.Remove(q);
                        db.SaveChanges();
                    }
                //}

                return RedirectToAction("Cart_list", new { m = ordernum });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration acc)
        {
            var usr = db.reg.Where(v => v.EmailId == acc.EmailId).FirstOrDefault();
            if (usr == null)
            {
                db.reg.Add(acc);
                db.SaveChanges();
                ViewBag.m1 = "Registration Successfully Done";
            }
            else
            {
                ViewBag.m1 = "You Have Already account";
            }
            return View();
        }
        public ActionResult Login()
        {
            if (Session["user"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Login(Registration acc)
        {
            var usr = db.reg.Where(v => v.EmailId == acc.EmailId && v.Password == acc.Password).FirstOrDefault();
            if (usr == null)
            {
                ViewBag.m1 = "Check Your EmailId Or Password";
            }
            else
            {
                Session["user"] = usr.EmailId;
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult logout()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", new { y = "Please Login First" });
            }
            else
            {
                Session.RemoveAll();
                return RedirectToAction("Index", new { y = "Successfully Logout" });
            }
        }
        public ActionResult Contact()
        {
            var usr1 = Session["user"];
            ViewBag.count = db.crt.Where(v => v.EmailId == usr1).Count();
            return View();
        }
        public ActionResult Buy(int x=0)
        {
            return RedirectToAction("Cart", new { x = x });
        }
    }
}
