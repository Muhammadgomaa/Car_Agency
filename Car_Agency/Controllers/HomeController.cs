using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car_Agency.Models;

namespace Car_Agency.Controllers
{
    public class HomeController : Controller
    {
        DB_Context dB = new DB_Context();

        public ActionResult Login()
        {
            //if coockies founded in pc
            if (Request.Cookies["coockie"] != null)
            {
                Session["userid"] = Request.Cookies["coockie"].Values["id"];
                return RedirectToAction("Main");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user, string rememberme)
        {
            User user1 = dB.Users.Where(n => n.User_Name == user.User_Name && n.User_Password == user.User_Password).SingleOrDefault();

            if (user1 != null)
            {
                Session.Add("userid", user1.User_ID);

                //cookie 
                //if checkbox is checked
                if (rememberme == "true")
                {
                    HttpCookie cookie = new HttpCookie("coockie"); //create file
                    cookie.Values.Add("id", user1.User_ID.ToString()); //save data
                    cookie.Expires = DateTime.Now.AddDays(90); //expire date
                    Response.Cookies.Add(cookie);
                }

                return RedirectToAction("Main");
            }
            else
            {
                ViewBag.status = "Invalid Username or Password";
                return View();
            }
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Operation()
        {
            //long User_id = long.Parse(Session["userid"].ToString());

            //User user = dB.Users.Where(n => n.User_ID == User_id).FirstOrDefault();

            //ViewBag.userType = user.User_Type;

            return View();
        }

        public ActionResult Logout()
        {
            Session["userid"] = null;
            HttpCookie cookie = new HttpCookie("coockie"); //create file
            cookie.Expires = DateTime.Now.AddDays(-15); //expire date (to delete coockie)
            Response.Cookies.Add(cookie);
            return RedirectToAction("Login");
        }
    }
}