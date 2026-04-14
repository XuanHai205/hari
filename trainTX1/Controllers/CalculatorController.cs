using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace trainTX1.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: BaiMot
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TinhToan(double a, double b, string op)
        {
            double kq = 0;
            if (op == "+") kq = a + b;
            else if (op == "-") kq = a - b;
            else if (op == "*") kq = a * b;
            else kq = a / b;
            ViewBag.KetQua = kq;
            return View("Index");
        }
    }
}