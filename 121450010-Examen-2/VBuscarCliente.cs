using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace _121450010_Examen_2
{
    public partial class VBuscarCliente : Form
    {
        NClientes nCliente;

        public string ClienteId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Estado { get; set; }

        public VBuscarCliente()
        {
            InitializeComponent();
            nCliente = new NClientes();
        }
        private void cargarDatos()
        {
            dgvProductos.DataSource = nCliente.ClientesActivos();

        }

        private void VBuscarCliente_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void dgvProductos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ClienteId = dgvProductos.CurrentRow.Cells["ClienteId"].Value.ToString();
            Nombres = dgvProductos.CurrentRow.Cells["Nombres"].Value.ToString();
            Apellidos = dgvProductos.CurrentRow.Cells["Apellidos"].Value.ToString();
            Estado = dgvProductos.CurrentRow.Cells["Estado"].Value.ToString();
            this.Visible = false;
        }
    }
}
