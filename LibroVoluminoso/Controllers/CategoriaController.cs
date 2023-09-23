
using LibroVoluminoso.Data;
using LibroVoluminoso.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibroVoluminoso.Controllers
{
	public class CategoriaController : Controller
	{
		private readonly AppDbContext _bd;

        public CategoriaController(AppDbContext appDb)
        {
			_bd = appDb;
        }

        public IActionResult Index()
		{
			var listaCategorias = _bd.Categorias.Where(cat => cat.Id > 0).ToList();

			return View(listaCategorias);
		}

        // GET, toma de datos ...
        public IActionResult Crear()
        {
            return View();
        }

        // POST, después de la toma de datos ...
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Categoria nueva)
        {
            // Validación personalizada
            if(nueva.Nombre == nueva.MostrarOrden.ToString())
            {
                ModelState.AddModelError("Nombre", "Nombre y Orden A Mostrar no pueden coincidir ...");
            }
            if(!ModelState.IsValid)
            {
                return View(nueva);
            }
            _bd.Categorias.Add(nueva);
            _bd.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
