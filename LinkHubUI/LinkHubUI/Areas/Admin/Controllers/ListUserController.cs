using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class ListUserController : Controller
    {
        public User objBs;
        public ListUserController()
        {
            objBs = new UserBs();
        }
        // GET: Admin/ListUser
        public ActionResult Index()
        {
            return View();
        }
    }
}