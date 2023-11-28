﻿using System;
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

        public ActionResult Save(TestViewModel model)
        {
            //log.Info("Started");
            SqlConnection dbConnection = new SqlConnection(connectionString);
            int rowsAffected = 0;

            try
            {
                var actionResultJson = new ActionResultJson<general_result>((int)Menus.Department);
                actionResultJson.data = new general_result();
                var tests = new List<TestViewModel>();
                var test = new TestViewModel();
                var spParams = new DynamicParameters();
                //if (IsValid(model))
                if (true)
                {
                   // MapValues(model, ref test);

                    tests.Add(test);
                    if(model.UserKey != Guid.Empty)
                    {
                        spParams = new DynamicParameters();
                        spParams.Add("@UserKey", model.UserKey);
                        spParams.Add("@CompanyID", 1);
                        //var result = dbConnection.Query<TestViewModel>("SELECT * FROM TestUser").ToList();
                        //         var query = $"SELECT * FROM {tableName} WHERE " +
                        //"(@UserKey IS NULL OR UserKey = @UserKey) AND " +
                        //"(@CompanyID IS NULL OR CompanyID = @CompanyID) AND " +
                        //"(@UserName IS NULL OR UserName = @UserName) AND " +
                        //"(@Password IS NULL OR Password = @Password)";
                        var query = $"SELECT * FROM TestUser WHERE " +
                        "(@UserKey IS NULL OR UserKey = @UserKey) AND " +
                        "(@CompanyID IS NULL OR CompanyID = @CompanyID) ";


                        //var result = dbConnection.Query<TestViewModel>(query, spParams).ToList();

                        //result 
                        //foreach (var item in result)
                        //{
                        //    // Access and process each item in the result list here
                        //    // For example, you can access properties of TestViewModel using item.PropertyName

                        //}

                         test = dbConnection.Query<TestViewModel>(query, spParams).FirstOrDefault();
                        if(test != null)
                        {
                            test.CompanyID = 1;
                            test.UserKey = model.UserKey;
                            test.Password = model.Password;
                            test.UserName = model.UserName;
                        }


                    }
                    //else
                    //{
                    //    spParams = new DynamicParameters();
                    //    spParams.Add("@UserKey", model.UserKey);
                    //    spParams.Add("@CompanyID", 1);
                    //    spParams.Add("@UserName", model.UserName);
                    //    spParams.Add("@Password", model.Password);
                    //    //string sql = "INSERT INTO YourTableName (FirstName, LastName, Age) VALUES (@FirstName, @LastName, @Age)";
                    //    //var qry = string.Format("insert into {0} (UserKey,CompanyID,UserName,Password) values (@UserKey,@CompanyID,@UserName,@Password)"
                    //    //    , DapperQuery.DBTables.TestUser.ToString());
                    //    //var qry = $"INSERT INTO {tableName} (UserKey, CompanyID, UserName, Password) VALUES (@UserKey, @CompanyID, @UserName, @Password)";
                    //    // var qry = $"INSERT INTO TestUser (UserKey, CompanyID, UserName, Password) VALUES (@UserKey, @CompanyID, @UserName, @Password)";
                    //    int rowsAffected = dbConnection.Execute($"INSERT INTO TestUser (UserKey, CompanyID, UserName, Password) VALUES (@UserKey, @CompanyID, @UserName, @Password)", spParams);

                    //}
                    if(test.UserKey != Guid.Empty)
                    {
                        spParams = new DynamicParameters();
                        spParams.Add("@UserKey", test.UserKey);
                        spParams.Add("@CompanyID", test.CompanyID);
                        spParams.Add("@UserName", test.UserName);
                        spParams.Add("@Password", test.Password);

                        rowsAffected = dbConnection.Execute($"Update TestUser Set CompanyID=@CompanyID," +
                            $" UserName=@UserName, Password=@Password where UserKey = @UserKey", spParams);
                    }
                    



                    //int rowsAffected = dbConnection.Execute(qry);

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Data inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Data insertion failed.");
                    }
                    //tests = DapperQuery.Save(DapperQuery.DBTables.HRDepartment, tests);
                    //CacheManager.Remove(CacheManager.CacheKey.HRDepartment, CurrentCompanyID);

                    actionResultJson.data.key = tests[0].UserKey;
                    actionResultJson.data.number = tests[0].Password;
                    actionResultJson.http_code = HttpStatusCode.OK;
                    actionResultJson.message = "test User is saved successfully";

                }
                else
                {
                    actionResultJson.broken_rules = this.BrokenRules;
                    actionResultJson.http_code = HttpStatusCode.BadRequest;
                    actionResultJson.message = "Please correct following errors:";

                }
                //log.Info("Completed");

                return Json(actionResultJson);

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
        }




        //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        //[HttpPost]
        [EnableCors("*", "*", "*")]
        //[HttpPost]
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