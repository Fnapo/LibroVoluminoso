
using System.ComponentModel.DataAnnotations;

namespace LibroVoluminoso.Models
{
	public class Categoria
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Nombre { get; set; }

		public int MostrarOrden { get; set; }

		public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
