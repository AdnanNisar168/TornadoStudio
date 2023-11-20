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
//using System.Web.Http;
using System.Web.Http.Cors;
using System.Data;
using tornadoStudio.TornadoLibrary;
using System.Net;
//cors

namespace tornadoStudio.Areas.Base.Controllers
{
    public class LogInController : Controller
    {
        public List<string> BrokenRules = new List<string>();
        // Access the connection string from web.config
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;
        //var actionResultJson = new ActionResultJson;
        public ActionResult GetLogInByQuery(LogInViewModel model)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            if (IsValid(model))
            {
                ////query
                //// without using model
                //var sql = "SELECT * FROM SecUser2 where UserName = @UserName and Password = @Password";
                //var quryParams = new DynamicParameters();
                //quryParams.Add("@UserName", model.UserName);
                //quryParams.Add("@Password", model.Password);
                //var Users = connection.QueryFirstOrDefault<LogInViewModel>(sql, quryParams);

                ////working
                ////return Json(Users, JsonRequestBehavior.AllowGet);
                ////new
                //if (Users != null)
                //{
                //    if (Users.Password != string.Empty)
                //    {
                //        var result = new ActionResultJson<string>();
                //        result.http_code = System.Net.HttpStatusCode.OK;
                //        result.message = "Logged in successfully";
                //        return Json(result, JsonRequestBehavior.AllowGet);
                //    }
                //    else
                //    {
                //        var result = new ActionResultJson<string>();
                //        result.http_code = System.Net.HttpStatusCode.NotFound;
                //        result.message = "User Not Found";
                //        return Json(result, JsonRequestBehavior.AllowGet);
                //    }

                //}
                //else
                //{
                //    var result = new ActionResultJson<string>();
                //    result.http_code = System.Net.HttpStatusCode.NotFound;
                //    result.message = "User Not Found";
                //    return Json(result, JsonRequestBehavior.AllowGet);
                //}
                var result = new ActionResultJson<string>();
                result.http_code = System.Net.HttpStatusCode.NotFound;
                result.message = "User Not Found";
                return Json(result, JsonRequestBehavior.AllowGet);
                //return Json(new { Message = "Login" }, JsonRequestBehavior.AllowGet);
            }

        }

        private bool IsValid(LogInViewModel request)
        {
            try
            {

                if (string.IsNullOrEmpty(request.UserName))
                {
                    this.BrokenRules.Add("UserName cannot be empty");
                }

                if (string.IsNullOrEmpty(request.Password))
                    this.BrokenRules.Add("Password cannot be empty");

                return this.BrokenRules.Count == 0;
                //will return true if no rules broken
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
            //private ActionResult OK(object p)
            //{
            //    throw new NotImplementedException();
            //}
        }
    }
}