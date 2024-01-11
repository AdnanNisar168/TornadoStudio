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

//using System;
//using System.Threading.Tasks;
//using RestSharp;

namespace tornadoStudio.Areas.Base.Controllers
{
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //[EnableCors("*", "*", "*")]
    public class UserController : Controller
    {
        public List<string> BrokenRules = new List<string>();
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

        public ActionResult GetUserByUserKey()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            var parameters = new DynamicParameters();
            parameters.Add("@UserKey", "DBEB0C00-ACF8-4ADA-BED0-C03A96912BEC");

            var result = connection.Query<UserViewModel>(
                  "spSecUser2GetByUserKey",
                  parameters,
                  commandType: CommandType.StoredProcedure
              );

            //  return result.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //public static async Task Main()
        //{

        //    var url = "https://api.alvochat.com/instance1199/messages/chat";
        //    var client = new RestClient(url);

        //    var request = new RestRequest(url, Method.Post);
        //    request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //    request.AddParameter("token", "YourToken");
        //    request.AddParameter("to", "16315555555");
        //    request.AddParameter("body", "WhatsApp API on alvochat.com works good");
        //    request.AddParameter("priority", "");
        //    request.AddParameter("preview_url", "");
        //    request.AddParameter("message_id", "");


        //    RestResponse response = await client.ExecuteAsync(request);
        //    var output = response.Content;
        //    Console.WriteLine(output);
        //}
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

        //public ActionResult Save(UserViewModel model)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new ActionResultJson<string>
        //        {
        //           // http_code = HttpStatusCode.InternalServerError,
        //            message = ex.Message,
        //            broken_rules = this.BrokenRules
        //        });
        //    }
        //}

        public ActionResult DapperSPMethod()
        {
            var spParams = new DynamicParameters();
            
            try
            {
                spParams.Add("@UserKey", "DBEB0C00-ACF8-4ADA-BED0-C03A96912BEC");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   var data = DapperQuery.GetListBySP<UserViewModel>(DapperQuery.StoredProcedures.spSecUser2GetByUserKey, spParams);
                    return Json(data, JsonRequestBehavior.AllowGet);


                }
                //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(Attendance), "application/json");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error is :",ex);
            }
            return Json(spParams, JsonRequestBehavior.AllowGet);
        }

        //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        //[HttpPost]
        //[EnableCors("*", "*", "*")]
        //[HttpPost]
        //public ActionResult List(string sortColumn, string sortOrder, int pageLength, int pageNumber, string username, string password)
        public ActionResult List(Guid? UserKey)
        {
            var totalRecords = 0;
            var model = new List<UserViewModel>();
            var datatablesNetList = new DataTablesNetList<UserViewModel>();
            try
            {
                var spParams = new DynamicParameters();
                //spParams.Add("@CompanyID", CurrentCompanyID);
                spParams.Add("@CompanyID", 1);
                spParams.Add("@UserKey", UserKey);
                //spParams.Add("@UserName", username);
                //spParams.Add("@PassWord", password);
                //spParams.Add("@SearchName", SearchName);
                //spParams.Add("@sortColumn", sortColumn);
                //spParams.Add("@sortOrder", sortOrder);
                //spParams.Add("@pageNumber", pageNumber);
                //spParams.Add("@recordsPerPage", pageLength);
                spParams.Add("@TotalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);


                model = DapperQuery.GetListBySP<UserViewModel>(DapperQuery.StoredProcedures.spSecUser2GetByUserKey, spParams);
                totalRecords = spParams.Get<int?>("@totalRecords").GetValueOrDefault();

                datatablesNetList.data = model;

                datatablesNetList.recordsTotal = totalRecords;
                datatablesNetList.recordsFiltered = totalRecords;
            }
            catch (Exception ex)
            {
                //log.Error(ex);
                return Json(new ActionResultJson<string>
                {
                    http_code = HttpStatusCode.InternalServerError,
                    message = ex.Message,
                    broken_rules = this.BrokenRules
                });
            }
            //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(model), "application/json");
            //return Json(model, JsonRequestBehavior.AllowGet);
            return Json(datatablesNetList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Guid id)
        {
            ActionResultJson<general_result> actionResultJson = new ActionResultJson<general_result>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                //log.Info("Started");
                var qry = string.Format("Delete from {0} where CompanyID = @CompanyID and UserKey=@UserKey"
                        , DapperQuery.DBTables.SecUser2.ToString());
                var parms = new DynamicParameters();
                parms.Add("@CompanyID", 1);
                //"BEE6295E-C796-4B77-B54E-A2BDA3544D93"
                parms.Add("@UserKey", id);
                //DapperQuery.Delete(DapperQuery.DBTables.InvGender, "GenderID", id);
                connection.Execute(qry, parms);
                actionResultJson.http_code = HttpStatusCode.OK;
                actionResultJson.message = "Record deleted successfully";

                //log.Debug("Completed");
            }
            catch (Exception ex)
            {
                //log.Error(ex);
                actionResultJson.http_code = HttpStatusCode.InternalServerError;
                actionResultJson.message = "There was some server error";
            }

            return Json(actionResultJson);
        }

        public ActionResult Index(Guid? id)
        {
            var model = new UserViewModel();
            var spParams = new DynamicParameters();

            try
            {
                //log.Info("Started");

                if (id.HasValue)
                {
                    spParams.Add("@CompanyID", 1);
                    spParams.Add("@UserKey", id);
                    model = DapperQuery.GetListBySP<UserViewModel>(DapperQuery.StoredProcedures.spSecUser2GetByUserKey2, spParams).FirstOrDefault();

                }
                else
                {
                    //model.UpdatedOn = DateTime.Now;
                    //model.DepartmentCode = DapperQuery.NewNumber(DapperQuery.DBTables.HRDepartment, "DepartmentCode");//automatic code
                }
                //log.Info("Complete");

                //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(model), "application/json");

                return Json(model);
            }
            catch (Exception ex)
            {
                //log.Error(ex);
                return Json(ex);
                //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(model), "application/json");
            }
        }
        //public ActionResult Save(UserViewModel model)
        //{
        //    //log.Info("Started");

        //    try
        //    {
        //        var actionResultJson = new ActionResultJson<general_result>((int)Menus.Gender);
        //        actionResultJson.data = new general_result();
        //        var genders = new List<GenderViewModel>();
        //        var gender = new GenderViewModel();

        //        if (IsValid(model))
        //        {   //genders is a list
        //            MapValues(model, ref gender);
        //            genders.Add(gender);
        //            genders = DapperQuery.SaveChanges(DapperQuery.DBTables.InvGender, genders);
        //            CacheManager.Remove(CacheManager.CacheKey.InvGender, CurrentCompanyID);


        //            actionResultJson.data.id = genders[0].GenderID;
        //            actionResultJson.data.number = genders[0].GenderCode;
        //            actionResultJson.http_code = HttpStatusCode.OK;
        //            actionResultJson.message = "Gender is saved successfully";

        //        }
        //        else
        //        {
        //            actionResultJson.broken_rules = this.BrokenRules;
        //            actionResultJson.http_code = HttpStatusCode.BadRequest;
        //            actionResultJson.message = "Please correct following errors:";

        //        }
        //        log.Debug("Completed");

        //        return Json(actionResultJson);

        //    }
        //    catch (Exception ex)
        //    {

        //        log.Error(ex);
        //        return Json(new ActionResultJson<string>
        //        {
        //            http_code = HttpStatusCode.InternalServerError,
        //            message = ex.Message,
        //            broken_rules = this.BrokenRules
        //        });
        //    }
        //}





    }
    }