
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
            ValidacionesPersonalizadas(nueva);
            if (!ModelState.IsValid)
            {
                return View(nueva);
            }
            _bd.Categorias.Add(nueva);
            _bd.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET, toma de datos ...
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaID = _bd.Categorias.Find(id);
            if (categoriaID == null)
            {
                return NotFound();
            }

            return View(categoriaID);
        }

        // POST, después de la toma de datos ...
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Categoria antigua)
        {
            // Validación personalizada
            ValidacionesPersonalizadas(antigua);
            if (!ModelState.IsValid)
            {
                return View(antigua);
            }
            _bd.Categorias.Update(antigua);
            _bd.SaveChanges();

            return RedirectToAction("Index");
        }

        private void ValidacionesPersonalizadas(Categoria categoria)
        {
            if (categoria.Nombre == categoria.MostrarOrden.ToString())
            {
                ModelState.AddModelError("Nombre", "Nombre y Orden no pueden coincidir ...");
            }
        }
    }
}
