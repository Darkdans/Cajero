using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Presentación.Ingresar;
using RecoinssoFinal.Presentación.Retirar;
using RecoinssoFinal.Presentación.Transferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoinssoFinal.Presentación.VentanaMenú
{
    public partial class Menú : Form
    {
        BalanceDA balanceDA = new BalanceDA();
        public Menú()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?", "Salir", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    this.Close();
                    VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                    ventanaPrincipal.Show();
                    break;
                case DialogResult.No:
                    return;
            }
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

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres cerrar sesión?", "Salir", MessageBoxButtons.YesNo);
            switch (result)
            {
                case DialogResult.Yes:
                    this.Close();
                    VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                    ventanaPrincipal.Show();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuBalance balance = new MenuBalance();
            int UsuarioID = 0; string Saldo = "";
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            Saldo = balanceDA.MostrarBalanceUsuario(UsuarioID);
            balance.lblUsuario.Text = lblUsuario.Text.ToString();
            balance.lblBalance.Text = Saldo;
            balance.Show();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            string Saldo = "";
            int UsuarioID = 0;
            this.Close();
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            MenuRetirar retirar = new MenuRetirar();
            Saldo = balanceDA.MostrarBalanceUsuario(UsuarioID);
            retirar.lblBalance.Text = Saldo;
            retirar.lblUsuarioID.Text = UsuarioID.ToString();
            retirar.Show();
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            string Saldo = "";
            int UsuarioID = 0;
            this.Close();
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            MenuTransferencia transferencia = new MenuTransferencia();
            Saldo = balanceDA.MostrarBalanceUsuario(UsuarioID);
            transferencia.lblBalance.Text = Saldo;
            transferencia.lblUsuarioID.Text = UsuarioID.ToString();
            transferencia.Show();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string Saldo = "";
            int UsuarioID = 0;
            this.Close();
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            MenuIngresar ingresar = new MenuIngresar();
            Saldo = balanceDA.MostrarBalanceUsuario(UsuarioID);
            ingresar.lblBalance.Text = Saldo;
            ingresar.lblUsuarioID.Text = UsuarioID.ToString();
            ingresar.Show();
        }
    }
}
