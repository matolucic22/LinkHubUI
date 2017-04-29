using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class CategoryController : BaseAdminController
    {
        

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Category category)
        {
            try
            {
                objBs.categoryBs.Insert(category);
                TempData["Msg"] = "Create Successfully";
                return RedirectToAction("Index");

            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed: " + e1.Message;
                return RedirectToAction("Index");
            }

            
        }
    }
}