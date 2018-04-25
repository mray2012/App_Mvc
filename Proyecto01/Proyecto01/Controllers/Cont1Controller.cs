using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Proyecto01.Controllers
{
    public class Cont1Controller : Controller
    {
        // GET: Cont1
        public ActionResult Index()
        {
            return View();
        }

        Proyecto01.Models.pruebaEntities db = new Proyecto01.Models.pruebaEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            var model = db.usuarios;
            return PartialView("_GridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(Proyecto01.Models.usuario item)
        {
            var model = db.usuarios;
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
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(Proyecto01.Models.usuario item)
        {
            var model = db.usuarios;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.idUsuario == item.idUsuario);
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
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 idUsuario)
        {
            var model = db.usuarios;
            if (idUsuario >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.idUsuario == idUsuario);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }
    }
}