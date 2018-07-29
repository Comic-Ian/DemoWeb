using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Dal;
using Model;

namespace test20180729.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            AspDemo aspDemo = new AspDemo();
            IList<Test> list = aspDemo.SelectTest();

            return View(list);
        }

        [HttpPost]
        public JsonResult Add(Test t, string temp)
        {
            bool result = false;

            AspDemo aspDemo = new AspDemo();
            result = aspDemo.InsertTest(t);

            return Json(result);
        }

        public JsonResult Upd(Test t, string temp)
        {
            bool result = false;

            AspDemo aspDemo = new AspDemo();
            result = aspDemo.UpdateTest(t);

            return Json(result);
        }

        public JsonResult Del(Test t)
        {
            bool result = false;

            AspDemo aspDemo = new AspDemo();
            result = aspDemo.DeleteTest(t);

            return Json(result);
        }
        public ActionResult test()
        {
            return View();
        }

    }
}