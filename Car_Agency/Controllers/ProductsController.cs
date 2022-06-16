using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Agency.Models;

namespace Car_Agency.Controllers
{
    public class ProductsController : Controller
    {
        DB_Context dB = new DB_Context();


        //Check for Car License in Create Case
        public ActionResult Check(string Car_Licence, int? Car_ID)
        {
            //Create Case
            if (Car_ID == null)
            {
                Car car = dB.Cars.Where(n => n.Car_Licence == Car_Licence).FirstOrDefault();

                if (car  == null)
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
                Car car = dB.Cars.Where(n => n.Car_Licence == Car_Licence && n.Car_ID != Car_ID).FirstOrDefault();

                if (car == null)
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
            ViewBag.Cars = dB.Cars.ToList();
            ViewBag.CarIDs1 = dB.Sales_Cash.Select(n => n.Car_ID).ToList();
            ViewBag.CarIDs2 = dB.Sales_Installment.Select(n => n.Car_ID).ToList();

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Suppliers = new SelectList(dB.Suppliers.ToList(), "Supp_ID", "Supp_Name");
          
            return View();
        }

        public ActionResult Add(Car car)
        {
            dB.Cars.Add(car);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }

        public ActionResult Delete()
        {
            ViewBag.Cars = dB.Cars.ToList();
            ViewBag.CarIDs1 = dB.Sales_Cash.Select(n => n.Car_ID).ToList();
            ViewBag.CarIDs2 = dB.Sales_Installment.Select(n => n.Car_ID).ToList();

            return View();
        }

        public ActionResult Delete_Info(int id)
        {
            Car car = dB.Cars.Where(n => n.Car_ID == id).SingleOrDefault();

            dB.Cars.Remove(car);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }

        public ActionResult Update()
        {
            ViewBag.Cars = dB.Cars.ToList();
            ViewBag.CarIDs1 = dB.Sales_Cash.Select(n => n.Car_ID).ToList();
            ViewBag.CarIDs2 = dB.Sales_Installment.Select(n => n.Car_ID).ToList();

            return View();
        }

        public ActionResult Update_Info(int id)
        {
            Car car = dB.Cars.Where(n => n.Car_ID == id).SingleOrDefault();
            ViewBag.Suppliers = new SelectList(dB.Suppliers.ToList(), "Supp_ID", "Supp_Name",car.Supp_ID);

            return View(car);
        }

        [HttpPost]
        public ActionResult Update_Info(Car car)
        {
            Car car1 = dB.Cars.Where(n => n.Car_ID == car.Car_ID).SingleOrDefault();

            car1.Car_Licence = car.Car_Licence;
            car1.Car_Model = car.Car_Model;
            car1.Car_Name = car.Car_Name;
            car1.Car_Price = car.Car_Price;
            car1.Supp_ID = car.Supp_ID;

            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }
    }
}