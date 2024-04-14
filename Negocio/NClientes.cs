using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.BaseDatos.Models;
using Negocio.Comun;

namespace Negocio
{
    public class NClientes
    {
        private DClientes dclientes;
        public NClientes()
        {
            dclientes = new DClientes();
        }
        public List<Clientes> TodoslosClientes()
        {
            return dclientes.ClientesTodos();
        }
        public List<Clientes> ClientesActivos()
        {
            return dclientes.ClientesTodos().Where(c => c.Estado == true).ToList();
        }
        public List<CargarCombos> CargaCombo()
        {
            List<CargarCombos> Datos = new List<CargarCombos>();
            var clientes = dclientes.ClientesTodos()
                                      .Where(c => c.Estado == true).Select(c => new
                                      {
                                          c.ClienteId,
                                          c.ClienteCombo,
                                      })
                                      .ToList();
            foreach (var item in clientes)
            {
                Datos.Add(new CargarCombos()
                {
                    Valor = item.ClienteId,
                    Nombre = item.ClienteCombo
                });
            }
            return Datos;
        }
        public int AgregarClientes(Clientes clientes)
        {
            return dclientes.GuardarClientes(clientes);
        }
        public int EditarClientes(Clientes clientes)
        {
            return dclientes.GuardarClientes(clientes);
        }
        public int EliminarCliente(int clientes)
        {
            return dclientes.EliminarCliente(clientes);
        }


    }
}
