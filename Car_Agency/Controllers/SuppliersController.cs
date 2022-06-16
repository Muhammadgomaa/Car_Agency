using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Agency.Models;

namespace Car_Agency.Controllers
{
    public class SuppliersController : Controller
    {
        DB_Context dB = new DB_Context();

        //Check for National ID in Create Case
        public ActionResult Check(string National_ID, int? Supp_ID)
        {
            //Create Case
            if (Supp_ID == null)
            {
                Supplier supplier = dB.Suppliers.Where(n => n.National_ID == National_ID).FirstOrDefault();

                if (supplier == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

            //Update Case
            else
            {
                Supplier supplier = dB.Suppliers.Where(n => n.National_ID == National_ID && n.Supp_ID != Supp_ID).FirstOrDefault();

                if (supplier == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
        }

        public ActionResult ShowAll()
        {
            ViewBag.Suppliers = dB.Suppliers.ToList();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Add(Supplier supplier)
        {
            dB.Suppliers.Add(supplier);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }

        public ActionResult Delete()
        {
            ViewBag.Suppliers = dB.Suppliers.ToList();

            return View();
        }

        public ActionResult Delete_Info(int id)
        {
            Supplier supplier = dB.Suppliers.Where(n => n.Supp_ID == id).SingleOrDefault();

            dB.Suppliers.Remove(supplier);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }

        public ActionResult Update()
        {
            ViewBag.Suppliers = dB.Suppliers.ToList();

            return View();
        }

        public ActionResult Update_Info(int id)
        {
            Supplier supplier = dB.Suppliers.Where(n => n.Supp_ID == id).SingleOrDefault();

            return View(supplier);
        }

        [HttpPost]
        public ActionResult Update_Info(Supplier supplier)
        {
            Supplier supplier1 = dB.Suppliers.Where(n => n.Supp_ID == supplier.Supp_ID).SingleOrDefault();

            supplier1.Supp_Name= supplier.Supp_Name;
            supplier1.Supp_Phone= supplier.Supp_Phone;
            supplier1.National_ID = supplier.National_ID;

            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }
    }
}