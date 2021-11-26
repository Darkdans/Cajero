using RecoinssoFinal.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecoinssoFinal.Presentación.Ingresar
{
    public partial class MenuIngresar : Form
    {

        ConexionDA conexion = new ConexionDA();
        public MenuIngresar()
        {
            InitializeComponent();
        }

        private void btnNumero1_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "1";
        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "2";
        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "3";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text = "";
        }

        private void btnNumero6_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "6";
        }

        private void btnNumero5_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "5";
        }

        private void btnNumero4_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "4";
        }

        private void btnNumero7_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "7";
        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "8";
        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "9";
        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "0";
        }

        private void btnNumero00_Click(object sender, EventArgs e)
        {
            txtCantidadIngresar.Text += "00";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCantidadIngresar.Text.Length >= 1)
            {
                string lastChar = txtCantidadIngresar.Text.Substring(0, txtCantidadIngresar.Text.Length - 1);
                txtCantidadIngresar.Text = lastChar;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool exito;
            int Cantidad = 0;
            int UsuarioID = 0;
            string CantidadIngreso = txtCantidadIngresar.Text;
            if (!String.IsNullOrEmpty(CantidadIngreso))
            {
                int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
                int.TryParse(txtCantidadIngresar.Text.ToString(), out Cantidad);
                exito = conexion.AgregarEfectivo(UsuarioID, Cantidad);
                if (exito == true)
                {
                    this.Hide();
                    VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                    ventanaPrincipal.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sucedio un error al intentar ingresar su efectivo.");
                }
            }
            else
            {
                MessageBox.Show("Favor de ingresar una denominación valida.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.ShowDialog();
            this.Show();
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
    }
}
