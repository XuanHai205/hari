using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trainTX1.Models;

namespace trainTX1.Controllers
{
    public class BangDiemController : Controller
    {
        // GET: BangDiem
        public ActionResult Diem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TinhDiem(BangDiemModels model)
        {
            double diemKV = 0;
            if(model.KhuVuc == "Khu vực A") diemKV = 1;
            else if(model.KhuVuc == "Khu vực B") diemKV= 2;
            else if(model.KhuVuc == "Khu vực C") diemKV = 3;

            double diemUuTien = model.LaGiaDinhChinhSach ? 1 : 0;

            model.TongDiem = model.DiemToan + model.DiemLy + model.DiemHoa + diemKV + diemUuTien;

            if (model.TongDiem >= 20) model.KetQua = "Đỗ đại học";
            else if (model.TongDiem >= 15) model.KetQua = "Đỗ cao đẳng";
            else if (model.TongDiem >= 10) model.KetQua = "Đỗ trung cấp";
            else model.KetQua = "Thi trượt";

            return View("KQDiemThi", model);
        }
    }
}