using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tornadoStudio.Areas.Base.Models.ViewModels
{
    public class TestViewModel
    {
        public Guid UserKey { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
    }
}