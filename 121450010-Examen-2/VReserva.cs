using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Datos.BaseDatos.Models;
using Negocio;

namespace _121450010_Examen_2
{
    public partial class VReserva : Form
    {
        private NReserva nReserva;
        private NClientes nclientes;
        private NTeatro nTeatro;
        public VReserva()
        {
            InitializeComponent();
            nReserva = new NReserva();
            nclientes = new NClientes();
            nTeatro = new NTeatro();
        }
        private void CHKEstado_CheckedChanged(object sender, EventArgs e)
        {


        }
        private void cargarDatos()
        {
            DGVDatos.DataSource = nReserva.TodasLasReservas();
            var clientes = nReserva.TodasLasReservas().Select(c => new { c.ReservaId,c.FechaIngreso ,c.ClienteId, c.Clientes.Nombres, c.TeatroId, c.Teatros.Capacidad});
            DGVDatos.DataSource = clientes.ToList();

        }
        private void DGVDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtReservaId.Text = DGVDatos.CurrentRow.Cells["ReservaId"].Value.ToString();
            TxtBuscarCliente.Text = DGVDatos.CurrentRow.Cells["ClienteId"].Value.ToString();
            var TeatroId = DGVDatos.CurrentRow.Cells["TeatroId"].Value.ToString();
            CBXTeatroId.SelectedValue = int.Parse(TeatroId);
            DTPFechaReserva.Value = DateTime.Parse(DGVDatos.CurrentRow.Cells["FechaIngreso"].Value.ToString());
            BTNEliminar.Enabled = false;
            BTNEliminar.BackColor = Color.White;
            buscarCliente();
        }
        private void DGVDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtReservaId.Text = DGVDatos.CurrentRow.Cells["ReservaId"].Value.ToString();
            TxtBuscarCliente.Text = DGVDatos.CurrentRow.Cells["ClienteId"].Value.ToString();
            var TeatroId = DGVDatos.CurrentRow.Cells["TeatroId"].Value.ToString();
            CBXTeatroId.SelectedValue = int.Parse(TeatroId);
            DTPFechaReserva.Value = DateTime.Parse(DGVDatos.CurrentRow.Cells["FechaIngreso"].Value.ToString());
            BTNEliminar.Enabled = true;
            BTNEliminar.BackColor = Color.Red;
            buscarCliente();
        }
        private bool ValidarCliente()
        {
            var FormularioValido = true;

            if (string.IsNullOrEmpty(TxtBuscarCliente.Text.ToString()) || string.IsNullOrWhiteSpace(TxtBuscarCliente.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtBuscarCliente, "Debe ingresar el Id Valido");
                return FormularioValido;
            }

            return FormularioValido;
        }
        private bool ValidarDatos()
        {
            var FormularioValido = true;
            if (string.IsNullOrEmpty(TxtBuscarCliente.Text.ToString()) || string.IsNullOrWhiteSpace(TxtBuscarCliente.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtBuscarCliente, "Debe ingresar el Id ");
                return FormularioValido;
            }
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
        private void cargarCombos()
        {
            CBXTeatroId.DataSource = nTeatro.CargaCombo();
            CBXTeatroId.DisplayMember = "Nombre";
            CBXTeatroId.ValueMember = "Valor";
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Reserva reserva = new Reserva()
                {
                    ClienteId = int.Parse(TxtBuscarCliente.Text.ToString()),
                    TeatroId = int.Parse(CBXTeatroId.SelectedValue.ToString()),
                    FechaIngreso = DTPFechaReserva.Value,
                };
                if (!string.IsNullOrEmpty(TxtReservaId.Text) || !string.IsNullOrWhiteSpace(TxtReservaId.Text))
                {
                    if (int.Parse(TxtReservaId.Text.ToString()) != 0)
                    {
                        reserva.ReservaId = int.Parse(TxtReservaId.Text.ToString());
                    }
                }
                nReserva.AgregarReserva(reserva);
                LimpiarDatos();
                cargarDatos();
            }
        }

        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que decea Eliminar", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(TxtReservaId.Text.ToString()) ||
                  !string.IsNullOrWhiteSpace(TxtReservaId.Text.ToString()))
                {
                    if (int.Parse(TxtReservaId.Text.ToString()) != 0)
                    {

                        var reservaId = int.Parse(TxtReservaId.Text.ToString());
                        nReserva.ElimarReserva(reservaId);
                        cargarDatos();
                        LimpiarDatos();
                        MessageBox.Show("Eliminado con Exito!!");

                    }
                }
            }
        }
        private void LimpiarDatos()
        {
            TxtBuscarCliente.Clear();
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            TxtReservaId.Text = "";
            BTNEliminar.BackColor = Color.White;
            errorProvider1.Clear();
            DTPFechaReserva.Value = DateTime.Now;
        }
        private void LimpiarClientes()
        {
            TxtBuscarCliente.Clear();
            TxtNombre.Text = "";
            TxtApellido.Text = "";

            errorProvider1.Clear();
        }
        private void BTNLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
        }

        private void BTNBuscarCliente_Click(object sender, EventArgs e)
        {
            VBuscarCliente vcliente = new VBuscarCliente();
            vcliente.ShowDialog();
            if(vcliente !=null)
            {
                TxtBuscarCliente.Text = vcliente.ClienteId;
                TxtNombre.Text = vcliente.Nombres;
                TxtApellido.Text = vcliente.Apellidos;

            }

        }

        private void VReserva_Load(object sender, EventArgs e)
        {
            cargarDatos();
            cargarCombos();
        }
        private void buscarCliente()
        {

            if (ValidarCliente())
            {
                var clienteId = int.Parse(TxtBuscarCliente.Text);
                var clientes = nclientes.ClientesActivos().FirstOrDefault(c => c.ClienteId == clienteId);

                if (int.Parse(TxtBuscarCliente.Text) > 0)
                {
                    if (clientes != null)
                    {
                        TxtBuscarCliente.Text = clienteId.ToString();
                        TxtNombre.Text = clientes.Nombres;
                        TxtApellido.Text = clientes.Apellidos;
                    }
                    else
                    {
                        MessageBox.Show("No Existe el Cliente");
                        LimpiarClientes();
                    }
                }
                else
                {
                    MessageBox.Show("No Existe el Cliente");
                    LimpiarClientes();
                }
            }
        }


        private void BTNBuscar_Click(object sender, EventArgs e)
        {
            buscarCliente();
        }
    }
}
