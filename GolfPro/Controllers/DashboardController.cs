using GolfPro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfPro.Controllers
{
    public class DashboardController : Controller
    {
        Sqlconnection connection = new Sqlconnection();

        // GET: Dashboard
        public ActionResult adminLogin()
        {
            return View();
        }

        public ActionResult DashboardSetting()
        {
            return View();
        }

        public ActionResult InvalidSetting()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Match_Login(login Login_Block)
        {
            //generate the query to check the user name or passwod
            String qry = "select * from admin_Setting where admin_Name='" + Login_Block.admin_Name + "' and admin_Password='" + Login_Block.admin_Password + "'";
            DataTable tbl = new DataTable();

            int x = connection.AdminLoginTest(qry);
            if (x > 0)
            {
                return View("DashboardSetting");
            }
            else
            {
                return View("InvalidSetting");
            }


        }
    }
}