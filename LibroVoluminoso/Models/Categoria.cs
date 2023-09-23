
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace LibroVoluminoso.Models
{
	public class Categoria
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage ="El campo Nombre es obligatorio ...")]
		public string Nombre { get; set; } = "";

        [Required(ErrorMessage = "El campo Orden A Mostrar es obligatorio ...")]
		[DisplayName("Orden A Mostrar")]
        [Range(0, int.MaxValue, ErrorMessage = "El valor de este campo ha de ser mayor o igual a 1 ...")]
        public int? MostrarOrden { get; set; }

		public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
