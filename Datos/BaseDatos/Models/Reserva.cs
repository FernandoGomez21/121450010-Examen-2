using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BaseDatos.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        public int ClienteId { get; set; }
        public Clientes Clientes { get; set; }

        public int TeatroId { get; set; }
        public Teatros Teatros { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }

    }
}
