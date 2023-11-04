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
        //public ActionResult Index(UserViewModel model)
        //{

        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        //try
        //        //{
        //        //    connection.Open();
        //        //    SqlCommand cmd = new SqlCommand();//("Select * from SecUser2");
        //        //    cmd.CommandText = "SELECT * FROM SecUser2 ";
        //        //    cmd.CommandTimeout = 15;
        //        //    cmd.CommandType = CommandType.Text;
        //        //    // You can use the connection to query your database here
        //        //    //ExecuteCommand("Your command here");
        //        //    cmd.ExecuteScalar();
        //        //    return Json(cmd, JsonRequestBehavior.AllowGet);

        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    // Handle exceptions
        //        //}
        //        //by sp
        //        //result = cn.Query<T>(Enum.GetName(typeof(StoredProcedures), storedProcedure), spParams, commandType: CommandType.StoredProcedure, commandTimeout: timeout).ToList();
        //        //https://www.youtube.com/watch?v=DboyInxNgXc link

        //        //SqlCommand cmd = new SqlCommand("spSecUser2GetByUserKey", connection);
        //        var parameters = new DynamicParameters();
        //        // Add any parameters if your stored procedure requires them
        //        parameters.Add("@UserKey", "DBEB0C00-ACF8-4ADA-BED0-C03A96912BEC");
        //        var result = new List<UserViewModel>();
        //        result = connection.Query<UserViewModel>("spSecUser2GetByUserKey", parameters, commandType: CommandType.StoredProcedure);

        //    }

        //    //return View();
        //    var name = "Ali";

        //    return Json(new { Name = name }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult  GetUserByUserKey()
        {
            
            SqlConnection connection = new SqlConnection(connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@UserKey", "DBEB0C00-ACF8-4ADA-BED0-C03A96912BEC");

          var  result = connection.Query<UserViewModel>(
                "spSecUser2GetByUserKey",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            //  return result.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserByQuery()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            

            //query
            // without using model
            var sql = "SELECT * FROM SecUser2";
            var customers = connection.Query(sql);
            //query

            //query
            // using model
            var sql1 = "SELECT * FROM SecUser2";
            var a1 = connection.Query<UserViewModel>(sql1);
            //query

            //query
            // using QueryAsync
            //var sql2 = "SELECT * FROM SecUser2";
            //var a2 = await connection.QueryAsync<UserViewModel>(sql2);
            //query




            //  return result.ToList();
            return Json(a1, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Save(UserViewModel model)
        {
            try
            {

            }
            catch (Exception ex)
            {

                log.Error(ex);
                return Json(new ActionResultJson<string>
                {
                    http_code = HttpStatusCode.InternalServerError,
                    message = ex.Message,
                    broken_rules = this.BrokenRules
                });
            }
        }
}