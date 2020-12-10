using System;
using System.ComponentModel.DataAnnotations;

namespace jueguitoEnApi.Models
{
    public class Jugador
    {
        [Key]
        public int JugadorId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el tiempo")]
        public double puntuacion { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el mensaje")]
        public string Mensaje { get; set; }
    }
}
