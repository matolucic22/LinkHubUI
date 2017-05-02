using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User.Controllers
{
    public class URLController : Controller
    {
        public UrlBs objBs;
        public CategoryBs objectCatBs;
        public UserBs objUserBs;

        public URLController()
        {
            objBs = new UrlBs();
            objectCatBs = new CategoryBs();
            objUserBs = new UserBs();
        }


        // GET: User/URL
        public ActionResult Index()//display form !!!! MORAŠ JOŠ DORADIT POGLEDAJ VIDEO 5.17. MORA TI BIT UNIQUE PA ZATO NE PRIKAZUJE NISTA AKO SUBMITAS.
        {
            //LinkHubDbEntities db = new LinkHubDbEntities();
           ViewBag.CategoryId = new SelectList(objectCatBs.GetALL().ToList(), "CategoryId", "CategoryName");//table, selected value-value field, displaied value-text field
           ViewBag.UserId = new SelectList(objUserBs.GetALL().ToList(), "UserId", "UserEmail");
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_Url myUrl)
        {


            //LinkHubDbEntities db = new LinkHubDbEntities();
            //ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");//table, selected value-value field, displaied value-text field
            try
            {
                myUrl.IsApproved = "P";
                myUrl.UserId = objUserBs.GetALL().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                if(ModelState.IsValid)
                {
                    objBs.Insert(myUrl);
                    TempData["Msg"] = "Create Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objectCatBs.GetALL().ToList(), "CategoryId", "CategoryName");//table, selected value-value field, displaied value-text field
                    ViewBag.UserId = new SelectList(objUserBs.GetALL().ToList(), "UserId", "UserEmail");
                    return View("Index");
                }
                

            }
            catch (Exception e1)
            {
                
                TempData["Msg"] = "Create Failed: " + e1.Message;
                return RedirectToAction("Index");
            }
          
        }
    }
}