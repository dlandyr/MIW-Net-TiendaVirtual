using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtualdlandy.Models;

namespace TiendaVirtualdlandy.Controllers
{
    public class ProductoController : Controller
    {
        private TiendaVirtualContainer tiendaVirtualContainer = new TiendaVirtualContainer();

        // GET: Producto

        [Authorize]
        public ActionResult Index()
        {
            return View(tiendaVirtualContainer.Productos.ToList());

        }

        // POST: Producto

        [HttpPost]
        public ActionResult Index(Producto producto)
        {
            //HttpPostedFileBase stock = producto.stockTemporal;
            return View(tiendaVirtualContainer.Productos.ToList());

        }

        // GET: Productos/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            string nombreArchivo = Path.GetFileNameWithoutExtension(producto.ImageFile.FileName);
            string extension = Path.GetExtension(producto.ImageFile.FileName);
            nombreArchivo = nombreArchivo + DateTime.Now.ToString("yymmssfff") + extension;
            producto.imagen = "~/Images/" + nombreArchivo;
            nombreArchivo = Path.Combine(Server.MapPath("~/Images/"), nombreArchivo);
            producto.ImageFile.SaveAs(nombreArchivo);

            if (ModelState.IsValid)
            {
                tiendaVirtualContainer.Productos.Add(producto);
                tiendaVirtualContainer.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            return View(producto);
        }
        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = tiendaVirtualContainer.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = tiendaVirtualContainer.Productos.Find(id);
            tiendaVirtualContainer.Productos.Remove(producto);
            tiendaVirtualContainer.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}