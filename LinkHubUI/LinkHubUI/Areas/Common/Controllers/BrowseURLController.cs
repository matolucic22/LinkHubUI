using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLController : Controller
    {
        private UrlBs objBs;
        public BrowseURLController()
        {
            objBs = new UrlBs();
        }
        // GET: Common/BrowseURL
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var urls = objBs.GetALL().Where(x => x.IsApproved == "A");
            if (SortBy == "Title")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        urls = urls.OrderBy(x => x.UrlTitle).ToList();
                        break;
                    case "Desc":
                        urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                        break;
                    default:
                        break;

                }

            }
            else if (SortBy == "Url")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        urls = urls.OrderBy(x => x.Url).ToList();
                        break;
                    case "Desc":
                        urls = urls.OrderByDescending(x => x.Url).ToList();
                        break;
                    default:
                        break;

                }

            }
            else if (SortBy == "UrlDesc")
            {
                switch (SortOrder)
                {
                    case "Asc":
                        urls = urls.OrderBy(x => x.UrlDesc).ToList();
                        break;
                    case "Desc":
                        urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                        break;
                    default:
                        break;

                }

            }
            else if(SortBy == "CategoryName")
            {
                
                switch (SortOrder)
                {
                    case "Asc":
                        urls = urls.OrderBy(x => x.tbl_Category.CategoryName).ToList();
                        break;
                    case "Desc":
                        urls = urls.OrderByDescending(x => x.tbl_Category.CategoryName).ToList();
                        break;
                    default:
                        break;

                }
                
            }
            else
            {
                urls = urls.OrderBy(x => x.UrlTitle).ToList();
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.GetALL().Where(x => x.IsApproved == "A").Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            urls = urls.Skip((page - 1) * 10).Take(10);


            return View(urls);
        }
    }
}