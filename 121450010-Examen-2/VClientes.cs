using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.BaseDatos.Models;
using Negocio;

namespace _121450010_Examen_2
{
    public partial class VClientes : Form
    {
        private NClientes nClientes;
        public VClientes()
        {
            InitializeComponent();
            nClientes = new NClientes();
        }
        private void cargarDatos()
        {
            DGVDatos.DataSource = nClientes.TodoslosClientes();
        }
        private void VClientes_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void LimpiarDatos()
        {
            TxtClienteId.Text = "";
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            DTPFechaIngreso.Value = DateTime.Now;
            CHKEstado.Checked = false;
            BTNEliminar.BackColor = Color.White;
            errorProvider1.Clear();
        }
        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(TxtNombre.Text.ToString()) || string.IsNullOrWhiteSpace(TxtNombre.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtNombre, "Debe ingresar el Nombre ");
                return FormularioValido;
            }
            if (string.IsNullOrEmpty(TxtApellido.Text.ToString()) || string.IsNullOrWhiteSpace(TxtApellido.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtApellido, "Debe ingresar el Apellido ");
                return FormularioValido;
            }
           
            return FormularioValido;
        }
        private void CHKActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKActivos.Checked == true)
            {
                DGVDatos.DataSource = nClientes.ClientesActivos();
            }
            else
            {
                cargarDatos();
            }
        }
        private void DGVDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtClienteId.Text = DGVDatos.CurrentRow.Cells["ClienteId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            TxtApellido.Text = DGVDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
            DTPFechaIngreso.Value = DateTime.Parse(DGVDatos.CurrentRow.Cells["FechaIngreso"].Value.ToString());
            CHKEstado.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            BTNEliminar.Enabled = false;
            BTNEliminar.BackColor = Color.White;
        }
        private void DGVDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtClienteId.Text = DGVDatos.CurrentRow.Cells["ClienteId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombres"].Value.ToString();
            TxtApellido.Text = DGVDatos.CurrentRow.Cells["Apellidos"].Value.ToString();
            DTPFechaIngreso.Value = DateTime.Parse(DGVDatos.CurrentRow.Cells["FechaIngreso"].Value.ToString());
            CHKEstado.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            BTNEliminar.Enabled = true;
            BTNEliminar.BackColor = Color.Red;
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Clientes Cliente = new Clientes()
                {
                    Nombres = TxtNombre.Text.ToString(),
                    Apellidos = TxtApellido.Text.ToString(),
                    FechaIngreso = DateTime.Now,
                    Estado = CHKEstado.Checked
                };
                if (!string.IsNullOrEmpty(TxtClienteId.Text) || !string.IsNullOrWhiteSpace(TxtClienteId.Text))
                {
                    if (int.Parse(TxtClienteId.Text.ToString()) != 0)
                    {
                        Cliente.ClienteId = int.Parse(TxtClienteId.Text.ToString());
                    }
                }
                nClientes.AgregarClientes(Cliente);
                LimpiarDatos();
                cargarDatos();
            }
        }
        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que decea Eliminar", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(TxtClienteId.Text.ToString()) ||
                  !string.IsNullOrWhiteSpace(TxtClienteId.Text.ToString()))
                {
                    if (int.Parse(TxtClienteId.Text.ToString()) != 0)
                    {
                        var clienteId = int.Parse(TxtClienteId.Text.ToString());
                        nClientes.EliminarCliente(clienteId);
                        cargarDatos();
                        LimpiarDatos();
                        MessageBox.Show("Eliminado con Exito!!");
                    }
                }
            }
        }
        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }
    }
}
