using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace THe_BOok_MArket.Controllers
{
    public class DTableController : Controller
    {
        // GET: DTable
        public ActionResult Index()
        {
            string cs = ConfigurationManager.ConnectionStrings["The_Book_MarketEntities1"].ConnectionString; 

            using (SqlConnection con = new SqlConnection(cs))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(Server.MapPath("~/CustList.xml")); // REad XML FIle

                DataTable dtCust = ds.Tables["Customer"];
                con.Open();

                using (SqlBulkCopy bc = new SqlBulkCopy(con)) // Declare BUlk Cpy class using the con string
                {
                    bc.DestinationTableName = "Customer";
                    bc.ColumnMappings.Add("Customer_Name", "Customer_Name");
                    bc.ColumnMappings.Add("Customer_Surname", "Customer_Surname");
                    bc.ColumnMappings.Add("Customer_Email", "Customer_Email");
                    bc.ColumnMappings.Add("Customer_Contact", "Customer_Contact");
                    bc.WriteToServer(dtCust);
                }
                  
            }
            return View();
        }
    }
}