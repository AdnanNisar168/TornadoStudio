using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace tornadoStudio.TornadoLibrary
{
    public class ActionResultJson<T>
    {
        public HttpStatusCode http_code = HttpStatusCode.OK;
        public int menuId = 0;
        public string message = string.Empty;
        public List<string> broken_rules = new List<string>();
        public T data;

        public ActionResultJson()
        {
        }

        public ActionResultJson(int menuId)
        {
            this.menuId = menuId;
        }

    }
}