using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica3.Models;

namespace Practica3.Controllers
{
    public class ProductosController : Controller
    {

        private readonly CompradorContext _context;
        public ProductosController(CompradorContext db)
        {
            _context = db;
        }
        public IActionResult Comprador()
        {
            var comprar = _context.Compradores.OrderBy(p => p.Nombre).ToList();
            return View(comprar);
        }


        public IActionResult CrearSolicitud()
        {
            ViewBag.Categoria = _context.Categorias.ToList().Select(r => new SelectListItem(r.Nom_Categoria, r.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult CrearSolicitud(Comprador r)
        {
            if (ModelState.IsValid)
            {
                _context.Add(r);
                _context.SaveChanges();
                return RedirectToAction("ConfirmarRegistro");
            }
            return View(r);
        }
        public IActionResult ConfirmarRegistro()
        {
            return View();
        }
        public IActionResult BorrarProductos(int id)
        {
            var comprar = _context.Compradores.Find(id);
            _context.Remove(comprar);
            _context.SaveChanges();

            return RedirectToAction("Comprador");
        }
        public IActionResult EditarProductos(int id)
        {
            var region = _context.Compradores.Find(id);
            return View(region);
        }

        [HttpPost]
        public IActionResult EditarProductos(Comprador r)
        {
            if (ModelState.IsValid)
            {
                var region = _context.Compradores.Find(r.Id);
                region.Nombre = r.Nombre;
                _context.SaveChanges();
                return RedirectToAction("Comprador");
            }
            return View(r);
        }



    }
}