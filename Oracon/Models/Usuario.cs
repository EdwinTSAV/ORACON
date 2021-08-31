using System.ComponentModel.DataAnnotations;

namespace Oracon.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Imagen { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Apellidos { get; set; }

        public string Celular { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo no es una dirección de correo electrónico válida")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Recovery { get; set; }

        [Required(ErrorMessage = "Debe seleccionar uno")]
        public int IdRol { get; set; }

        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string YouTube { get; set; }
        public string Instagram { get; set; }

        public Roles Roles { get; set; }
    }
}
