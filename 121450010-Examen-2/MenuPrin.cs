using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _121450010_Examen_2
{
    public partial class MenuPrin : Form
    {
        public MenuPrin()
        {
            InitializeComponent();
        }

        private void teatroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VTeatro teatro = new VTeatro();
            teatro.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VClientes clientes = new VClientes();
            clientes.Show();
        }

        private void reservaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VReserva reserva = new VReserva();
            reserva.Show();
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrin menu = new MenuPrin();
            menu.Show();
        }
    }
}
