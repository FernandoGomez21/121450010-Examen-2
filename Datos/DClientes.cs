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
    public class DClientes
    {
        UnitOfWork unitOfWork;

        public DClientes()
        {
            unitOfWork = new UnitOfWork();
        }
        public int ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public List<Clientes> ClientesTodos()
        {
            return unitOfWork.Repository<Clientes>().Consulta().ToList();
        }
        public int GuardarClientes(Clientes clientes)
        {
            if (clientes.ClienteId == 0)
            {
                unitOfWork.Repository<Clientes>().Agregar(clientes);
                return unitOfWork.Guardar();
            }
            else
            {
                var ClienteInDb = unitOfWork.Repository<Clientes>().Consulta().FirstOrDefault(c => c.ClienteId == clientes.ClienteId);
                if (ClienteInDb != null)
                {
                    ClienteInDb.Nombres = clientes.Nombres;
                    ClienteInDb.Apellidos = clientes.Apellidos;
                    ClienteInDb.FechaIngreso = clientes.FechaIngreso;
                    ClienteInDb.Estado = clientes.Estado;
                    unitOfWork.Repository<Clientes>().Editar(clientes);
                    return unitOfWork.Guardar();
                }
                return 0;
            }
        }
        public int EliminarCliente(int clientes)
        {
            var ClienteInDb = unitOfWork.Repository<Clientes>().Consulta().FirstOrDefault(c => c.ClienteId == clientes);
            if (ClienteInDb != null)
            {
                {
                    unitOfWork.Repository<Clientes>().Eliminar(ClienteInDb);
                    return unitOfWork.Guardar();
                }
            }
            return 0;
        }


    }
}
