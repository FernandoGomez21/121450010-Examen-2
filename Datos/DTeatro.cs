using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.BaseDatos.Models;
using Datos.Core;

namespace Datos
{
    public class DTeatro
    {
        UnitOfWork unitOfWork;

        public DTeatro()
        {
            unitOfWork = new UnitOfWork();
        }
        public int TeatroId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }

        public List<Teatros> TeatrosTodos()
        {
            return unitOfWork.Repository<Teatros>().Consulta().ToList();
        }
        public int GuardarTeatro(Teatros teatros)
        {
            if (teatros.TeatroId == 0)
            {
                unitOfWork.Repository<Teatros>().Agregar(teatros);
                return unitOfWork.Guardar();
            }
            else
            {
                var TeatroInDb = unitOfWork.Repository<Teatros>().Consulta().FirstOrDefault(c => c.TeatroId == teatros.TeatroId);
                if (TeatroInDb != null)
                {
                    TeatroInDb.Nombre = teatros.Nombre;
                    TeatroInDb.Capacidad = teatros.Capacidad;
                    TeatroInDb.Estado = teatros.Estado;
                    unitOfWork.Repository<Teatros>().Editar(teatros);
                    return unitOfWork.Guardar();
                }
                return 0;
            }
        }
        public int ElimiarTeatro(int Teatro)
        {
            var TeatroInDb = unitOfWork.Repository<Teatros>().Consulta().FirstOrDefault(c => c.TeatroId == Teatro);
            if (TeatroInDb != null)
            {
                {
                    unitOfWork.Repository<Teatros>().Eliminar(TeatroInDb);
                    return unitOfWork.Guardar();
                }
            }
            return 0;
        }


    }
}
