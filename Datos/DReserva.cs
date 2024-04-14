using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos.Core;

namespace Datos
{
    public class DReserva
    {

        UnitOfWork unitOfWork;

        public DReserva()
        {
            unitOfWork = new UnitOfWork();
        }
        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        public int TeatroId { get; set; }
        public DateTime FechaIngreso { get; set; }

        public List<Reserva> ReservasTodas()
        {
            return unitOfWork.Repository<Reserva>()
                .Consulta()
                .Include(c => c.Clientes)
                .Include(c => c.Teatros)
                .ToList();
        }
        public int GuardarReservas(Reserva reserva)
        {
            if (reserva.ReservaId == 0)
            {
                unitOfWork.Repository<Reserva>().Agregar(reserva);
                return unitOfWork.Guardar();
            }
            else
            {
                var ReservaInDb = unitOfWork.Repository<Reserva>().Consulta().FirstOrDefault(c => c.ReservaId == reserva.ReservaId);
                if (ReservaInDb != null)
                {
                    ReservaInDb.ClienteId = reserva.ClienteId;
                    ReservaInDb.TeatroId = reserva.TeatroId;
                    ReservaInDb.FechaIngreso = reserva.FechaIngreso;
                    unitOfWork.Repository<Reserva>().Editar(reserva);
                    return unitOfWork.Guardar();
                }
                return 0;
            }
        }
        public int ElimarReservas(int reserva)
        {
            var ReservaInDb = unitOfWork.Repository<Reserva>().Consulta().FirstOrDefault(c => c.ReservaId == reserva);
            if (ReservaInDb != null)
            {
                {
                    unitOfWork.Repository<Reserva>().Eliminar(ReservaInDb);
                    return unitOfWork.Guardar();
                }
            }
            return 0;
        }


    }
}
