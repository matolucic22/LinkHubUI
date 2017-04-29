using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListCategoryController : BaseAdminController
    {
       
        // GET: Admin/ListCategory
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var category = objBs.categoryBs.GetALL();
            if (SortBy == "CategoryName")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        category = category.OrderBy(x => x.CategoryName).ToList();
                        break;
                    case "Desc":
                        category = category.OrderByDescending(x => x.CategoryName).ToList();
                        break;
                    default:
                        break;

                }

            }
            else
            {
                switch (SortOrder)
                {
                    case "Asc":
                        category = category.OrderBy(x => x.CategoryDesc).ToList();
                        break;
                    case "Desc":
                        category = category.OrderByDescending(x => x.CategoryDesc).ToList();
                        break;
                    default:
                        break;

                }

            }


            ViewBag.TotalPages = Math.Ceiling(objBs.categoryBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            category = category.Skip((page - 1) * 10).Take(10);


            return View(category);

           
        }
        public ActionResult Delete(int id)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    objBs.categoryBs.Delete(id);
                    TempData["Msg"] = "Deleted Successfully";
                    return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Index");
                    }

            }catch(Exception e1)
            {
                TempData["Msg"] = "Deleted Failed: "+e1.Message;
                return RedirectToAction("Index");
            }
        }

    }
}