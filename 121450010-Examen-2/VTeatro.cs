using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos.BaseDatos.Models;
using Negocio;

namespace _121450010_Examen_2
{
    public partial class VTeatro : Form
    {
        private NTeatro nTeatro;
        public VTeatro()
        {
            InitializeComponent();
            nTeatro = new NTeatro();
        }
        private void cargarDatos()
        {
            DGVDatos.DataSource = nTeatro.TodoslosTeatros();
        }
        private void VClientes_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void LimpiarDatos()
        {
            TxtTeatroId.Text = "";
            TxtNombre.Text = "";
            TxtCapacidad.Text = "";
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
            if (string.IsNullOrEmpty(TxtCapacidad.Text.ToString()) || string.IsNullOrWhiteSpace(TxtCapacidad.Text.ToString()))
            {
                FormularioValido = false;
                errorProvider1.SetError(TxtCapacidad, "Debe ingresar la Capacidad ");
                return FormularioValido;
            }

            return FormularioValido;
        }
        private void CHKActivos_CheckedChanged(object sender, EventArgs e)
        {
            if (CHKActivos.Checked == true)
            {
                DGVDatos.DataSource = nTeatro.TeatrosActivos();
            }
            else
            {
                cargarDatos();
            }
        }
        private void DGVDatos_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtTeatroId.Text = DGVDatos.CurrentRow.Cells["TeatroId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            TxtCapacidad.Text = DGVDatos.CurrentRow.Cells["Capacidad"].Value.ToString();
            CHKEstado.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            BTNEliminar.Enabled = false;
            BTNEliminar.BackColor = Color.White;
        }
        private void DGVDatos_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TxtTeatroId.Text = DGVDatos.CurrentRow.Cells["TeatroId"].Value.ToString();
            TxtNombre.Text = DGVDatos.CurrentRow.Cells["Nombre"].Value.ToString();
            TxtCapacidad.Text = DGVDatos.CurrentRow.Cells["Capacidad"].Value.ToString();
            CHKEstado.Checked = bool.Parse(DGVDatos.CurrentRow.Cells["Estado"].Value.ToString());
            BTNEliminar.Enabled = true;
            BTNEliminar.BackColor = Color.Red;
        }
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Teatros teatros = new Teatros()
                {
                    Nombre = TxtNombre.Text.ToString(),
                    Capacidad = int.Parse(TxtCapacidad.Text.ToString()),
                    Estado = CHKEstado.Checked
                };
                if (!string.IsNullOrEmpty(TxtTeatroId.Text) || !string.IsNullOrWhiteSpace(TxtTeatroId.Text))
                {
                    if (int.Parse(TxtTeatroId.Text.ToString()) != 0)
                    {
                        teatros.TeatroId = int.Parse(TxtTeatroId.Text.ToString());
                    }
                }
                nTeatro.AgregarTeatro(teatros);
                LimpiarDatos();
                cargarDatos();
            }
        }
        private void BTNEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que decea Eliminar", "Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(TxtTeatroId.Text.ToString()) ||
                  !string.IsNullOrWhiteSpace(TxtTeatroId.Text.ToString()))
                {
                    if (int.Parse(TxtTeatroId.Text.ToString()) != 0)
                    {
                        var teatroId = int.Parse(TxtTeatroId.Text.ToString());
                        nTeatro.ElimarTeatro(teatroId);
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

        private void VTeatro_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
