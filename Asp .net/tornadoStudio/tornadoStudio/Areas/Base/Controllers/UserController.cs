using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//for using connectin string
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
//for using connectin string
using tornadoStudio.Areas.Base.Models.ViewModels;

//dapper
using Dapper;
//cors
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data;
//cors

namespace tornadoStudio.Areas.Base.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class UserController : Controller
    {
        // Access the connection string from web.config
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        // GET: Base/User
        public ActionResult Index(UserViewModel model)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();//("Select * from SecUser2");
                    cmd.CommandText = "SELECT * FROM SecUser2 ";
                    cmd.CommandTimeout = 15;
                    cmd.CommandType = CommandType.Text;
                    // You can use the connection to query your database here
                    //ExecuteCommand("Your command here");
                    cmd.ExecuteScalar();
                    return Json(cmd, JsonRequestBehavior.AllowGet);

                }
                catch (Exception ex)
                {
                    // Handle exceptions
                }
            }

            //return View();
            var name = "Ali";

            return Json(new { Name = name }, JsonRequestBehavior.AllowGet);
        }
    }
}