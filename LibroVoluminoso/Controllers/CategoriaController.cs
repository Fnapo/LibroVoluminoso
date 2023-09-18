
using LibroVoluminoso.Data;
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
	}
}
