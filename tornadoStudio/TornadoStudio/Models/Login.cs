using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TornadoStudio.Models
{
    public class Login
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}