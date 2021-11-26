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
    public partial class MenuTransferenciaCuenta : Form
    {
        ConexionDA conexion = new ConexionDA();
        BalanceDA balanceDA = new BalanceDA();
        public MenuTransferenciaCuenta()
        {
            InitializeComponent();
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


        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres salir de la operación?", "Salir", MessageBoxButtons.YesNo);
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
            txtCuenta.Text += "1";
        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "2";
        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "3";
        }
        private void btnNumero4_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "4";
        }
        private void btnNumero5_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "5";
        }
        private void btnNumero6_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "6";
        }
        private void btnNumero7_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "7";
        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "8";
        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "9";
        }

        private void btnNumero00_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "00";
        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {
            txtCuenta.Text += "0";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCuenta.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCuenta.Text.Length >= 1)
            {
                string lastChar = txtCuenta.Text.Substring(0, txtCuenta.Text.Length - 1);
                txtCuenta.Text = lastChar;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool exito, resultadoRetiro;
            int Cantidad = 0;
            int UsuarioID = 0;
            int UsuarioDestinatario = 0;
            int ClaveDestinatario = 0;
            string Destinatario = txtCuenta.Text;
            if (!String.IsNullOrEmpty(Destinatario))
            {
                int.TryParse(lblUsuario.Text.ToString(), out UsuarioID);
                int.TryParse(lblCantidad.Text.ToString(), out Cantidad);
                int.TryParse(txtCuenta.Text.ToString(), out ClaveDestinatario);
                UsuarioDestinatario = conexion.nombreUsuarioPorClave(ClaveDestinatario);
                if (UsuarioID != UsuarioDestinatario)
                {
                    exito = conexion.AgregarEfectivoSinMensaje(UsuarioDestinatario, Cantidad);
                    if (exito == true)
                    {
                        resultadoRetiro = conexion.RetirarEfectivoSinMensaje(UsuarioID, Cantidad);
                        if (resultadoRetiro == true)
                        {
                            MessageBox.Show("La transferencia fue un éxito");
                            this.Close();
                            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
                            ventanaPrincipal.Show();
                        }
                        else
                        {
                            MessageBox.Show("Sucedio un error al intentar retirar fondos a su cuenta.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sucedio un error al intentar ingresar dinero al destinatario.");
                    }
                }
                else
                {
                    MessageBox.Show("La cuenta destino no puede ser igual que tu cuenta.");
                }
            }
            else
            {
                MessageBox.Show("Favor de ingresar una clave de usuario valida.");
            }
        }

    }
}
