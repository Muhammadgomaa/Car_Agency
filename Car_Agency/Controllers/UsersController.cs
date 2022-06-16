using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Agency.Models;

namespace Car_Agency.Controllers
{
    public class UsersController : Controller
    {
        DB_Context dB = new DB_Context();

        //Check for Username in Create Case
        public ActionResult Check(string User_Name, int? User_ID)
        {
            //Create Case
            if (User_ID == null)
            {
                User user = dB.Users.Where(n => n.User_Name == User_Name).FirstOrDefault();

                //User Not Exist
                if (user == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                //User is Exist
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }

            //Update Case
            else
            {
                User user = dB.Users.Where(n => n.User_Name == User_Name && n.User_ID != User_ID).FirstOrDefault();

                if (user == null)
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
            ViewBag.Users = dB.Users.ToList();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Add(User user)
        {
            dB.Users.Add(user);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }

        public ActionResult Delete()
        {
            ViewBag.Users = dB.Users.ToList();

            return View();
        }

        public ActionResult Delete_Info(int id)
        {
            User user = dB.Users.Where(n => n.User_ID == id).SingleOrDefault();

            dB.Users.Remove(user);
            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }

        public ActionResult Update()
        {
            ViewBag.Users = dB.Users.ToList();

            return View();
        }

        public ActionResult Update_Info(int id)
        {
            User user = dB.Users.Where(n => n.User_ID == id).SingleOrDefault();

            return View(user);
        }

        [HttpPost]
        public ActionResult Update_Info(User user)
        {
            User user1 = dB.Users.Where(n => n.User_ID == user.User_ID).SingleOrDefault();

            user1.User_Name = user.User_Name;
            user1.User_Type = user.User_Type;

            dB.SaveChanges();

            return RedirectToAction("Main", "Home");
        }
    }
}