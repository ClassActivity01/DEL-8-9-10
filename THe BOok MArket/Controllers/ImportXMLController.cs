using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THe_BOok_MArket.Models;
using System.Xml.Linq;

namespace THe_BOok_MArket.Controllers
{

    public class ImportXMLController : Controller
    {
        private The_Book_MarketEntities db = new The_Book_MarketEntities();
        // GET: ImportXML
        [HttpGet]
        public ActionResult Index()
        {
            return View(); 
        }

        public ActionResult GetData()
        {
            using (The_Book_MarketEntities db = new The_Book_MarketEntities())
            {
                List<Customer> customerList = db.Customers.ToList<Customer>();
                return Json(new { data = customerList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase xmlFile)
        {
            if (xmlFile.ContentType.Equals("application/xml") || xmlFile.ContentType.Equals("text/xml"))
            {
                try
                {
                    var xmlPath = Server.MapPath("~/FileUpload" + xmlFile.FileName);
                    xmlFile.SaveAs(xmlPath);
                    XDocument xDoc = XDocument.Load(xmlPath);
                    List<Customer> custList = xDoc.Descendants("customer").Select
                        (customer => new Customer
                        {
                            Customer_ID = Convert.ToInt32(customer.Element("id").Value),    
                            Customer_Name = customer.Element("name").Value,
                            Customer_Surname = customer.Element("surname").Value,
                            Customer_Email = customer.Element("email").Value,
                            Customer_Contact = customer.Element("contact").Value
                        }).ToList();

                    using (The_Book_MarketEntities db = new The_Book_MarketEntities())
                    {
                        foreach (var i in custList)
                        {
                            var v = db.Customers.Where(a => a.Customer_ID.Equals(i.Customer_ID)).FirstOrDefault();

                            if (v != null)
                            {
                                v.Customer_ID = i.Customer_ID;
                                v.Customer_Name = i.Customer_Name;
                                v.Customer_Surname = i.Customer_Surname;
                                v.Customer_Email = i.Customer_Email;
                                v.Customer_Contact = i.Customer_Contact;

                            }
                            else
                            {
                                db.Customers.Add(i);
                            }
                           
                        }
                        db.SaveChanges();
                        ViewBag.Result = db.Customers.ToList();
                    }
                    return View("Success");
                }
                catch
                {
                    ViewBag.Error = "Cant Import XML File";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.Error = "Cant Import XML File";
                return View("Index");
            }
        }
        //public ActionResult Upload(HttpPostedFileBase xmlFile)
        //{
        //    if (xmlFile.ContentType.Equals("application/xml") || xmlFile.ContentType.Equals("text/xml"))
        //    {
        //        var xmlPath = Server.MapPath("~/FileUpload" + xmlFile.FileName);
        //        xmlFile.SaveAs(xmlPath);
        //        XDocument xDoc = XDocument.Load(xmlPath);   
        //        List<Customer> custList = xDoc.Descendants("customer").Select
        //            (customer => new Customer
        //            {
        //                Customer_ID = Convert.ToInt32(customer.Element("cus_id").Value),
        //                Customer_Name = (customer.Element("name").Value),
        //                Customer_Surname = customer.Element("surname").Value,
        //                Customer_Email = customer.Element("email").Value,
        //                Customer_Contact = customer.Element("contact").Value
        //            }).ToList();

        //        using (The_Book_MarketEntities db = new The_Book_MarketEntities())
        //        {
        //            foreach (var i in custList)
        //            {   
        //                var v = db.Customers.Where(a => a.Customer_ID.Equals(i.Customer_ID)).FirstOrDefault();

        //                if (v != null)
        //                {
        //                    v.Customer_ID = i.Customer_ID;
        //                    v.Customer_Name = i.Customer_Name;
        //                    v.Customer_Surname = i.Customer_Surname;
        //                    v.Customer_Email = i.Customer_Email;
        //                    v.Customer_Contact = i.Customer_Contact;

        //                }
        //                else
        //                {
        //                    db.Customers.Add(i);
        //                }
        //                db.SaveChanges();
        //            }
        //        }
        //        ViewBag.Success = "File uploaded successfully..";
        //    }
        //    else
        //    {
        //        ViewBag.Error = "Invalid file(Upload xml file only)";
        //    }
        //    return View("Index");
        //}


    }
}