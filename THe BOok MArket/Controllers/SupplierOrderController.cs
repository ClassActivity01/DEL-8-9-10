using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THe_BOok_MArket.Models;  

namespace THe_BOok_MArket.Controllers
{
    public class SupplierOrderController : Controller 
    {
        public The_Book_MarketEntities db = new The_Book_MarketEntities();

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult GetInventory(string word, int page, int rows, string searchString, string sord)
        {
            using (The_Book_MarketEntities db = new The_Book_MarketEntities())
            {
                //#2 Setting Paging  
                int pageIndex = Convert.ToInt32(page) - 1;
                int pageSize = rows;

                //#3 Linq Query to Get Customer   
                var Results = db.Inventories.Select(
                    a => new
                    {
                        a.Inventory_ID,
                        a.InventoryType_ID,
                        a.Inventory_Name,
                        a.Inventory_Description,
                        a.Inventory_Quantity,
                        a.Minimum_Quantity,
                        a.StockTurn_ID,
                        
                    });

                //#4 Get Total Row Count  
                int totalRecords = Results.Count();
                var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);

                //#5 Setting Sorting    
                if (sord.ToUpper() == "DESC")
                {
                    Results = Results.OrderByDescending(s => s.Inventory_ID);
                    Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
                }
                else
                {
                    Results = Results.OrderBy(s => s.Inventory_ID);
                    Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
                }   
                //#6 Setting Search  
                if (!string.IsNullOrEmpty(searchString))
                {
                    Results = Results.Where(m => m.Inventory_Description == searchString);
                }
                //#7 Sending Json Object to View.  
                var jsonData = new
                {
                    total = totalPages,
                    page,
                    records = totalRecords,
                    rows = Results
                };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }

        }
    }
}