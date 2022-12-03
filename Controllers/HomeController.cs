using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        masterEntities db = new masterEntities();
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetUserList()
        {
           

            List<User> userList = db.Users.ToList();
            return Json(userList, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetUserById(int Id)
        {
            User model = db.Users.Where(x => x.Id == Id).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SaveDataInDatabase(User model)
        {
            var result = false;
            try
            {
                if (model.Id > 0)
                {
                    User us = db.Users.SingleOrDefault(x =>  x.Id == model.Id);
                    us.Name = model.Name;
                    us.Email = model.Email;
                    us.Phone_no = model.Phone_no;
                    us.City = model.City;
                    us.State = model.State;
                    us.Address = model.Address;
                    us.Agree = model.Agree;
                   
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    User us = new User();
                    us.Name = model.Name;
                    us.Email = model.Email;
                    us.Phone_no = model.Phone_no;
                    us.City = model.City;
                    us.State = model.State;
                    us.Address = model.Address;
                    us.Agree = model.Agree;
                    db.Users.Add(us);
                    db.SaveChanges();
      
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public JsonResult DeleteUserRecord(int Id)
        {
            bool result = false;

           User us = db.Users.SingleOrDefault(x => x.Id ==Id);
            db.Users.Remove(us);
           
               
             db.SaveChanges();
             result = true;
           

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}