using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Models
{
    public class Teatros
    {
        [Key]
        public int TeatroId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }

        [NotMapped]
        public string ClienteCombo => $"{Nombre} - {Capacidad}";

    }
}
