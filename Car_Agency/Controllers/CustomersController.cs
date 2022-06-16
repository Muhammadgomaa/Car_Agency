using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Agency.Models;

namespace Car_Agency.Controllers
{
    public class CustomersController : Controller
    {
        DB_Context dB = new DB_Context();

        //Check for National ID in Create Case
        public ActionResult Check(string National_ID, int? Cus_ID)
        {
            if (Cus_ID == null)
            {
                Customer customer = dB.Customers.Where(n => n.National_ID == National_ID).FirstOrDefault();

                if (customer == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                Customer customer = dB.Customers.Where(n => n.National_ID == National_ID && n.Cus_ID != Cus_ID).FirstOrDefault();

                if (customer == null)
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
            ViewBag.Customers = dB.Customers.ToList();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Add(Customer customer)
        {
            dB.Customers.Add(customer);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }

        public ActionResult Delete()
        {
            ViewBag.Customers = dB.Customers.ToList();

            return View();
        }

        public ActionResult Delete_Info(int id)
        {
            Customer customer =  dB.Customers.Where(n => n.Cus_ID == id).SingleOrDefault();

            dB.Customers.Remove(customer);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }

        public ActionResult Update()
        {
            ViewBag.Customers = dB.Customers.ToList();

            return View();
        }

        public ActionResult Update_Info(int id)
        {
            Customer customer = dB.Customers.Where(n => n.Cus_ID== id).SingleOrDefault();

            return View(customer);
        }

        [HttpPost]
        public ActionResult Update_Info(Customer customer)
        {
            Customer customer1 = dB.Customers.Where(n => n.Cus_ID == customer.Cus_ID).SingleOrDefault();

            customer1.Cus_Name= customer.Cus_Name;
            customer1.Cus_Phone = customer.Cus_Phone;
            customer1.National_ID = customer.National_ID;

            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }
    }
}