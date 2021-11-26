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

namespace RecoinssoFinal.Presentación.Transferencia
{
    public partial class MenuTransferencia : Form
    {
        ConexionDA conexion = new ConexionDA();
        public MenuTransferencia()
        {
            InitializeComponent();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnNumero1_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "1";
        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "2";
        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "3";
        }
        private void btnNumero4_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "4";
        }
        private void btnNumero5_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "5";
        }
        private void btnNumero6_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "6";
        }
       
        private void btnNumero7_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "7";
        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "8";
        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "9";
        }

        private void btnNumero00_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "00";
        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {
            txtCantidad.Text += "0";
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text.Length >= 1)
            {
                string lastChar = txtCantidad.Text.Substring(0, txtCantidad.Text.Length - 1);
                txtCantidad.Text = lastChar;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int Cantidad = 0;
            int UsuarioID = 0;
            string CantidadRetiro = txtCantidad.Text;
            if (!String.IsNullOrEmpty(CantidadRetiro))
            {
                int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
                int.TryParse(txtCantidad.Text.ToString(), out Cantidad);
                int Saldo = conexion.VerificarEfectivo(UsuarioID);
                if (Saldo >= Cantidad)
                {
                    this.Close();
                    MenuTransferenciaCuenta menuTrans = new MenuTransferenciaCuenta();
                    menuTrans.lblCantidad.Text = Cantidad.ToString();
                    menuTrans.lblUsuario.Text = UsuarioID.ToString();
                    menuTrans.Show();
                }
                else
                {
                    MessageBox.Show("No dispone de tanto saldo en su cuenta para la transferencia.");
                }

            }
            else
            {
                MessageBox.Show("Favor de ingresar una denominación valida.");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            } else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
