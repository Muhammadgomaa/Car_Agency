﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Agency.Models;

namespace Car_Agency.Controllers
{
    public class InstallmentController : Controller
    {
        DB_Context dB = new DB_Context();

        public ActionResult Get_Info_Customer()
        {
            ViewBag.Customer = dB.Customers.ToList();

            return View();
        }

        public ActionResult Get_Info_Car(int id)
        {
            Session.Add("customerid", id);

            ViewBag.Car = dB.Cars.ToList();
            ViewBag.CarIDs1 = dB.Sales_Cash.Select(n => n.Car_ID).ToList();
            ViewBag.CarIDs2 = dB.Sales_Installment.Select(n => n.Car_ID).ToList();

            return View();
        }

        public ActionResult Create(int id)
        {
            Session.Add("carid", id);

            int userid = int.Parse(Session["userid"].ToString());
            int cusid = int.Parse(Session["customerid"].ToString());
            int carid = int.Parse(Session["carid"].ToString());


            Customer customer = dB.Customers.Where(n => n.Cus_ID == cusid).SingleOrDefault();
            Car car = dB.Cars.Where(n => n.Car_ID == carid).SingleOrDefault();
            User user = dB.Users.Where(n => n.User_ID == userid).SingleOrDefault();

            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh:mm tt");

            ViewBag.customer = customer;
            ViewBag.car = car;
            ViewBag.user = user;
            ViewBag.date = date;
            ViewBag.time = time;

            return View();
        }

        public ActionResult Add(Sales_Installment _Installment)
        {
            dB.Sales_Installment.Add(_Installment);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }
    }
}