using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CalendarController : Controller
    {
        public class Day
        {
            public string Holiday { get; set; }
            public string data { get; set; }

            //public string Name { get; set; }
        }

        public static string sqlConn = ConfigurationManager.ConnectionStrings["Project"].ToString();
        private string sql;
        
        // GET: Calendar
        public ActionResult Index(Day data)
        {
            DataTable dtable = new DataTable();
            

            using (SqlConnection con = new SqlConnection(sqlConn))
            {
                con.Open();


                using (var cmd = new SqlCommand(sql, con))
                {

                    var reader = cmd.ExecuteReader();
                    dtable.Load(reader);
                    con.Close();
                }
            }
            return View();
        }



    }
}