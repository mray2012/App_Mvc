using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Proyecto01.Controllers
{
    public class Cont2Controller : Controller
    {
        // GET: Cont2
        public ActionResult Index()
        {
            return View();
        }

        Proyecto01.Models.pruebaEntities db = new Proyecto01.Models.pruebaEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = db.areas;
            return PartialView("_GridView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(Proyecto01.Models.area item)
        {
            var model = db.areas;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(Proyecto01.Models.area item)
        {
            var model = db.areas;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.id_area == item.id_area);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 id_area)
        {
            var model = db.areas;
            if (id_area >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.id_area == id_area);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model.ToList());
        }
    }
}