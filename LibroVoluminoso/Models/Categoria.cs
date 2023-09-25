
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
        [Range(1, 100, ErrorMessage = "El valor de este campo ha de estar entre 1 y 100")]
        public int? MostrarOrden { get; set; }

		public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
}
