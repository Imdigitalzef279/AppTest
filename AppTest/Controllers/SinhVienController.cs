using AppTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppTest.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVienController
        public ActionResult Index()
        {
            var listSinhVien = new TestContext().SinhViens.ToList();
            return View(listSinhVien);
        }

        // GET: SinhVienController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SinhVienController/Create
        public ActionResult Create()
        {
            var context = new TestContext();
            var chucVuSelect = new SelectList(context.Lops, "Id", "TenChucVu");
            ViewBag.IdChucVu = chucVuSelect;
            return View();
        }

        // POST: SinhVienController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SinhVien model)
        {
            try
            {
                var context = new TestContext();
                context.SinhViens.Add(model);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVienController/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new TestContext();
            var editing = context.SinhViens.Find(id);
            var chucVuSelect = new SelectList(context.SinhViens, "Id", "TenChucVu");
            ViewBag.IdChucVu = chucVuSelect;
            return View(editing);
        }

        // POST: SinhVienController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SinhVien model)
        {
            try
            {
                var context = new TestContext();
                var oldItem = context.SinhViens.Find(model.Id);
                oldItem.IdChucVu = model.IdChucVu;
                oldItem.LaLopPho = model.LaLopPho;
                oldItem.LaLopTruong = model.LaLopTruong;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SinhVienController/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new TestContext();
            var deleting = context.SinhViens.Find(id);
            return View(deleting);
        }

        // POST: SinhVienController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SinhVien model)
        {
            try
            {
                var context = new TestContext();
                var deleting = context.SinhViens.Find();
                context.SinhViens.Remove(deleting);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
