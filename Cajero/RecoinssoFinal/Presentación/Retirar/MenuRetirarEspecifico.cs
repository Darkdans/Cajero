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

namespace RecoinssoFinal.Presentación.Retirar
{
    public partial class MenuRetirarEspecifico : Form
    {
        ConexionDA conexion = new ConexionDA();
        public MenuRetirarEspecifico()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            bool exito;
            int Cantidad = 0;
            int UsuarioID = 0;
            string CantidadRetiro = txtCantidadRetirar.Text;
            if (!String.IsNullOrEmpty(CantidadRetiro))
            {
                int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
                int.TryParse(txtCantidadRetirar.Text.ToString(), out Cantidad);
                int Saldo = conexion.VerificarEfectivo(UsuarioID);
                if (Saldo >= Cantidad)
                {
                    exito = conexion.RetirarEfectivo(UsuarioID, Cantidad);
                    if (exito == true)
                    {
                        this.Close();
                        VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                        ventanaPrincipal.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sucedio un error al intentar retirar su efectivo.");
                    }
                } else
                {
                    MessageBox.Show("No dispone de tanto saldo en su cuenta.");
                }
            }
            else
            {
                MessageBox.Show("Favor de ingresar una denominación valida.");
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            /*this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;*/
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCantidadRetirar.Text.Length >= 1)
            {
                string lastChar = txtCantidadRetirar.Text.Substring(0, txtCantidadRetirar.Text.Length - 1);
                txtCantidadRetirar.Text = lastChar;
            }
        }

        private void btnNumero1_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "1";
        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "2";
        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "3";
        }

        private void btnNumero6_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "4";
        }

        private void btnNumero5_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "5";
        }

        private void btnNumero4_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "6";
        }

        private void btnNumero7_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "7";
        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "8";
        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "9";
        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "0";
        }

        private void btnNumero00_Click(object sender, EventArgs e)
        {
            txtCantidadRetirar.Text += "00";
        }
    }
}
