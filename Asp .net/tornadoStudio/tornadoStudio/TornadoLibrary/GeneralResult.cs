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
    public class general_result
    {
        public Int32 id;
        public string number;
        public Guid key;
    }
}