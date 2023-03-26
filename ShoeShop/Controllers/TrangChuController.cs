using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ShoeShop.Controllers
{
    public class TrangChuController : Controller
    {        // GET: TrangChu

        public ActionResult TrangChu()           
        {

            return View();
        }
    }
}