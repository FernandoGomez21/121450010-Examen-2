using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(75)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(75)]
        public string Apellidos { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }

        public bool Estado { get; set; }

        [NotMapped]
        public string ClienteCombo => $"{Nombres} - {Apellidos}";
    }
}
