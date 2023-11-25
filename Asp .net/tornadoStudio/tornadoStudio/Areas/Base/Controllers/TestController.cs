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
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    //[EnableCors("*", "*", "*")]
    public class TestController : Controller
    {
        public List<string> BrokenRules = new List<string>();
        // Access the connection string from web.config
        string connectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnection"].ConnectionString;

        public ActionResult Index(Guid? id)
        {
            var model = new TestViewModel();
            var spParams = new DynamicParameters();

            try
            {
                //log.Info("Started");

                if (id.HasValue)
                {
                    spParams.Add("@CompanyID", 1);
                    spParams.Add("@UserKey", id);
                    model = DapperQuery.GetListBySP<TestViewModel>(DapperQuery.StoredProcedures.spTestUserGetByUserKey, spParams).FirstOrDefault();

                }
                else
                {
                    //model.UpdatedOn = DateTime.Now;
                    //model.DepartmentCode = DapperQuery.NewNumber(DapperQuery.DBTables.HRDepartment, "DepartmentCode");//automatic code
                }
                //log.Info("Complete");

                //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(model), "application/json");
                return Json(model, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //log.Error(ex);
                Console.WriteLine("Error : ", ex);
                //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(model), "application/json");
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }




        //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        //[HttpPost]
        [EnableCors("*", "*", "*")]
        [HttpPost]
        //public ActionResult List(string sortColumn, string sortOrder, int pageLength, int pageNumber, string username, string password)
        //[HttpGet]
        public ActionResult List(string sortColumn, string sortOrder, int pageLength, int pageNumber, string username, string password)
        {
            var datatablesNetList = new DataTablesNetList<TestViewModel>();
            var totalRecords = 0;

            try
            {
                var spParams = new DynamicParameters();
                spParams.Add("@CompanyID", 1);
                spParams.Add("@Password", username);
                spParams.Add("@UserName", password);
                spParams.Add("@sortColumn", sortColumn);
                spParams.Add("@sortOrder", sortOrder);
                spParams.Add("@pageNumber", pageNumber);
                spParams.Add("@recordsPerPage", pageLength);
                spParams.Add("@totalRecords", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var model = DapperQuery.GetListBySP<TestViewModel>(DapperQuery.StoredProcedures.spTestUserGetByCompanyIDSortingPaging, spParams);
                totalRecords = spParams.Get<int?>("@totalRecords").GetValueOrDefault();

                datatablesNetList.data = model;

                datatablesNetList.recordsTotal = totalRecords;
                datatablesNetList.recordsFiltered = totalRecords;

            }
            catch (Exception ex)
            {
                //log.Error(ex);
                Console.WriteLine("Error : ", ex);
            }
            //return Content(Newtonsoft.Json.JsonConvert.SerializeObject(datatablesNetList), "application/json");
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

     



    }
    }