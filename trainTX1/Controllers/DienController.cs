using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trainTX1.Models;

namespace trainTX1.Controllers
{
    public class DienController : Controller
    {
        // GET: Dien
        public ActionResult TienDien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TinhTienDien(DienModels model)
        {
            double soDien = model.csm - model.csc;
            double tien = 0;
            if (soDien < 100) tien = soDien * 2000;
            else if (soDien <= 150) tien = 100 * 2000 + (soDien - 100) * 2500;
            else if (soDien <= 200) tien = 100 * 2000 + 50 * 2500 + (soDien - 150) * 3000;
            else tien = 100 * 2000 + 50 * 2500 + 50 * 3000 + (soDien - 2000) * 4000;

            if (model.LoaiDien == "Kinh doanh") tien *= 1.2;
            else if (model.LoaiDien == "Sản xuất") tien *= 1.3;
            if (model.HoUuTien) tien *= 0.9;

            model.SoDien = soDien;
            model.ThanhTien = tien;

            return View("KetQua", model);
        }
    }
}