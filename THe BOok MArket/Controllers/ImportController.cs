using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THe_BOok_MArket.Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using LinqToExcel;
using System.Data.SqlClient;

namespace THe_BOok_MArket.Controllers
{
       public class ImportController : Controller
    {
        private The_Book_MarketEntities db = new The_Book_MarketEntities();
        // GET: Import
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadExcel()
        { 

            return View();
        }

        public FileResult DownloadExcel()
        {
            string path = "/Doc/Users.xlsx";
            return File(path, "application/vnd.ms-excel", "Users.xlsx");
        }

        [HttpPost]
        public JsonResult UploadExcel(Customer customers, HttpPostedFileBase FileUpload)
        {

            List<string> data = new List<string>();
            if (FileUpload != null)
            {
                // tdata.ExecuteCommand("truncate table OtherCompanyAssets");  
                if (FileUpload.ContentType == "application/vnd.ms-excel" || FileUpload.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {


                    string filename = FileUpload.FileName;
                    string targetpath = Server.MapPath("~/Doc/");
                    FileUpload.SaveAs(targetpath + filename);
                    string pathToExcelFile = targetpath + filename;
                    var connectionString = "";
                    if (filename.EndsWith(".xls"))
                    {
                        connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", pathToExcelFile);
                    }
                    else if (filename.EndsWith(".xlsx"))
                    {
                        connectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1\";", pathToExcelFile);
                    }

                    var adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connectionString);
                    var ds = new DataSet();

                    adapter.Fill(ds, "ExcelTable");

                    DataTable dtable = ds.Tables["ExcelTable"];

                    string sheetName = "Sheet1";

                    var excelFile = new ExcelQueryFactory(pathToExcelFile);
                    var artistAlbums = from a in excelFile.Worksheet<Customer>(sheetName) select a;

                    foreach (var a in artistAlbums)
                    {
                        try
                        {
                            if (a.Customer_Name != "" && a.Customer_Surname != "" && a.Customer_Email != "" && a.Customer_Contact.ToString() != "")
                            {
                                Customer TU = new Customer();
                                TU.Customer_Name = a.Customer_Name;
                                TU.Customer_Surname = a.Customer_Surname;
                                TU.Customer_Email = a.Customer_Email;
                                TU.Customer_Contact = a.Customer_Contact; 
                                db.Customers.Add(TU);

                                db.SaveChanges();



                            }
                            else
                            {
                                data.Add("<ul>");
                                if (a.Customer_Name == "" || a.Customer_Name == null) data.Add("<li> name is required</li>");
                                if (a.Customer_Surname == "" || a.Customer_Surname == null) data.Add("<li> Address is required</li>");
                                if (a.Customer_Email == "" || a.Customer_Email == null) data.Add("<li>Email is required</li>");
                                if (a.Customer_Contact.ToString() == "" || a.Customer_Contact == null) data.Add("<li>Contact is required</li>");

                                data.Add("</ul>");
                                data.ToArray();
                                return Json(data, JsonRequestBehavior.AllowGet);
                            }
                        }

                        catch (DbEntityValidationException ex)
                        {
                            foreach (var entityValidationErrors in ex.EntityValidationErrors)
                            {

                                foreach (var validationError in entityValidationErrors.ValidationErrors)
                                {

                                    Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);

                                }

                            }
                        }
                    }
                    //deleting excel file from folder  
                    //using (System.IO.File.Exists(pathToExcelFile)) { }
                    //if ((System.IO.File.Exists(pathToExcelFile)))
                    //{
                    //    System.IO.File.Delete(pathToExcelFile);
                    //}
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //alert message for invalid file format  
                    data.Add("<ul>");
                    data.Add("<li>Only Excel file format is allowed</li>");
                    data.Add("</ul>");
                    data.ToArray();
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                data.Add("<ul>");
                if (FileUpload == null) data.Add("<li>Please choose Excel file</li>");
                data.Add("</ul>");
                data.ToArray();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

    }
}