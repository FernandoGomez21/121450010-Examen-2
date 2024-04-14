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
    public class NTeatro
    {
        private DTeatro dTeatro;
        public NTeatro()
        {
            dTeatro = new DTeatro();
        }
        public List<Teatros> TodoslosTeatros()
        {
            return dTeatro.TeatrosTodos();
        }
        public List<Teatros> TeatrosActivos()
        {
            return dTeatro.TeatrosTodos().Where(c => c.Estado == true).ToList();
        }
        public List<CargarCombos> CargaCombo()
        {
            List<CargarCombos> Datos = new List<CargarCombos>();
            var teatros = dTeatro.TeatrosTodos()
                                      .Where(c => c.Estado == true).Select(c => new
                                      {
                                          c.TeatroId,
                                          c.ClienteCombo,
                                      })
                                      .ToList();
            foreach (var item in teatros)
            {
                Datos.Add(new CargarCombos()
                {
                    Valor = item.TeatroId,
                    Nombre = item.ClienteCombo
                });
            }
            return Datos;
        }
        public int AgregarTeatro(Teatros teatros)
        {
            return dTeatro.GuardarTeatro(teatros);
        }
        public int EditarTeatro(Teatros teatros)
        {
            return dTeatro.GuardarTeatro(teatros);
        }
        public int ElimarTeatro(int teatros)
        {
            return dTeatro.ElimiarTeatro(teatros);
        }


    }
}
