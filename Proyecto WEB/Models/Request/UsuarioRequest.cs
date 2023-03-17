using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_WEB.Models.Request {
    public class UsuarioRequest {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Nacimiento es obligatorio.")]
        [DataType(DataType.Date, ErrorMessage = "Seleccione una fecha")]
        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo Sexo es obligatorio.")]
        public string Sexo { get; set; }
    }
}
