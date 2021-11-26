using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Presentación.VentanaMenú;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoinssoFinal.Presentación
{
    public partial class MenuBalance : Form
    {
        BalanceDA balance = new BalanceDA();

        public MenuBalance()
        {
            InitializeComponent();
        }

        private void MenuBalance_Load(object sender, EventArgs e)
        {
            int UsuarioID = 0;
            int.TryParse(lblUsuarioID.Text, out UsuarioID);
            balance.MostrarBalanceUsuario(UsuarioID);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            /*this.WindowState = FormWindowState.Normal;
              btnMaximizar.Visible = true;
              btnRestaurar.Visible = false;*/
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = System.Windows.Forms.MessageBox.Show("¿Estás seguro de que quieres salir?", "Salir", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    Application.Exit();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaPrincipal menu = new VentanaPrincipal();
            menu.ShowDialog();
            this.Show();
        }
    }
}
