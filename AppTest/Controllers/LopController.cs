using AppTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppTest.Controllers
{
    public class LopController : Controller
    {
        // GET: LopController
        public ActionResult Index()
        {
            var listLop = new TestContext().Lops.ToList();
            return View(listLop);
        }

        // GET: LopController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LopController/Create
        public ActionResult Create()
        {
            var context = new TestContext();
            var chucVuSelect = new SelectList(context.Lops, "Id", "TenChucVu");
            ViewBag.IdChucVu = chucVuSelect;
            return View();
        }

        // POST: LopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Lop model)
        {
            try
            {
                var context = new TestContext();
                context.Lops.Add(model);
                context.SaveChanges();          
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LopController/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new TestContext();
            var editing = context.Lops.Find(id);
            var chucVuSelect = new SelectList(context.Lops, "Id", "TenChucVu");
            ViewBag.IdChucVu = chucVuSelect;
            return View(editing);
        }

        // POST: LopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Lop model)
        {
            try
            {
                var context = new TestContext();
                var oldItem = context.Lops.Find(model.Id);
                oldItem.MaLop = model.MaLop;
                oldItem.SoBd = model.SoBd;
                oldItem.Id = model.Id;
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LopController/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new TestContext();
            var deleting = context.Lops.Find(id);
            return View(deleting);
        }

        // POST: LopController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Lop model)
        {
            try
            {
                var context = new TestContext();
                var deleting = context.Lops.Find();
                context.Lops.Remove(deleting);
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
