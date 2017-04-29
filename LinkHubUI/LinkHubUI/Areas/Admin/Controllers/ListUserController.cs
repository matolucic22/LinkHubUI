using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListUserController : BaseAdminController
    {
        
        // GET: Admin/ListUser
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var users = objBs.userBs.GetALL();
            if (SortBy == "UserEmail")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        users = users.OrderBy(x => x.UserEmail).ToList();
                        break;
                    case "Desc":
                        users = users.OrderByDescending(x => x.UserEmail).ToList();
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
                        users = users.OrderBy(x => x.Role).ToList();
                        break;
                    case "Desc":
                        users = users.OrderByDescending(x => x.Role).ToList();
                        break;
                    default:
                        break;

                }

            }


            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            users = users.Skip((page - 1) * 10).Take(10);


            return View(users);
        }
    }
}