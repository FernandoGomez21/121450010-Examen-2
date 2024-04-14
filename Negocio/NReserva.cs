using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos;
using Negocio.Comun;

namespace Negocio
{
    public class NReserva
    {
        private DReserva dReserva;
        public NReserva()
        {
            dReserva = new DReserva();
        }
        public List<Reserva> TodasLasReservas()
        {
            return dReserva.ReservasTodas();
        }
        public int AgregarReserva(Reserva reserva)
        {
            return dReserva.GuardarReservas(reserva);
        }
        public int EditarReserva(Reserva reserva)
        {
            return dReserva.GuardarReservas(reserva);
        }
        public int ElimarReserva(int reserva)
        {
            return dReserva.ElimarReservas(reserva);
        }
    }
}
