using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THe_BOok_MArket.Models;
using System.Xml.Serialization;

namespace THe_BOok_MArket.Controllers
{
    public class ExportController : Controller
    {
        private The_Book_MarketEntities db = new The_Book_MarketEntities();

        public ActionResult ExportToXML()
        {

            db.Configuration.ProxyCreationEnabled = false;
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Customers.ToList();

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename = CustomerList.xml");
            Response.ContentType = "text/xml";

            //db.Configuration.LazyLoadingEnabled = false;
            var serializer = new System.Xml.Serialization.XmlSerializer(data.GetType());    
            serializer.Serialize(Response.OutputStream, data);

            return View();
        }
    }
}