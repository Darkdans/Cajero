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
    public partial class MenuRetirar : Form
    {
        ConexionDA conexion = new ConexionDA();
        BalanceDA balanceDA = new BalanceDA();
        public MenuRetirar()
        {
            InitializeComponent();
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

        private void btn5000_Click(object sender, EventArgs e)
        {
            int valor = 5000;
            bool exito;
            int Cantidad = 0;
            int UsuarioID = 0;
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            int Saldo = conexion.VerificarEfectivo(UsuarioID);
            if (Saldo >= Cantidad)
            {
                exito = conexion.RetirarEfectivo(UsuarioID, valor);
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
            }
            else
            {
                MessageBox.Show("No dispone de tanto saldo en su cuenta.");
            }
        }

        private void btn2000_Click(object sender, EventArgs e)
        {
            int valor = 2000;
            bool exito;
            int Cantidad = 0;
            int UsuarioID = 0;
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            int Saldo = conexion.VerificarEfectivo(UsuarioID);
            if (Saldo >= Cantidad)
            {
                exito = conexion.RetirarEfectivo(UsuarioID, valor);
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
            }
            else
            {
                MessageBox.Show("No dispone de tanto saldo en su cuenta.");
            }
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            int valor = 1000;
            bool exito;
            int Cantidad = 0;
            int UsuarioID = 0;
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            int Saldo = conexion.VerificarEfectivo(UsuarioID);
            if (Saldo >= Cantidad)
            {
                exito = conexion.RetirarEfectivo(UsuarioID, valor);
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
            }
            else
            {
                MessageBox.Show("No dispone de tanto saldo en su cuenta.");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            VentanaPrincipal ventanaPrincipal = new VentanaPrincipal();
            ventanaPrincipal.Show();
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            int valor = 500;
            bool exito;
            int Cantidad = 0;
            int UsuarioID = 0;
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            int Saldo = conexion.VerificarEfectivo(UsuarioID);
            if (Saldo >= Cantidad)
            {
                exito = conexion.RetirarEfectivo(UsuarioID, valor);
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
            }
            else
            {
                MessageBox.Show("No dispone de tanto saldo en su cuenta.");
            }
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            int valor = 200;
            bool exito;
            int Cantidad = 0;
            int UsuarioID = 0;
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            int Saldo = conexion.VerificarEfectivo(UsuarioID);
            if (Saldo >= Cantidad)
            {
                exito = conexion.RetirarEfectivo(UsuarioID, valor);
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
            }
            else
            {
                MessageBox.Show("No dispone de tanto saldo en su cuenta.");
            }
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            int valor = 100;
            bool exito;
            int Cantidad = 0;
            int UsuarioID = 0;
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            int Saldo = conexion.VerificarEfectivo(UsuarioID);
            if (Saldo >= Cantidad)
            {
                exito = conexion.RetirarEfectivo(UsuarioID, valor);
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
            }
            else
            {
                MessageBox.Show("No dispone de tanto saldo en su cuenta.");
            }
        }

        private void btnOtro_Click(object sender, EventArgs e)
        {
            string Saldo = "";
            int UsuarioID = 0;
            this.Close();
            int.TryParse(lblUsuarioID.Text.ToString(), out UsuarioID);
            MenuRetirarEspecifico retirar = new MenuRetirarEspecifico();
            Saldo = balanceDA.MostrarBalanceUsuario(UsuarioID);
            retirar.lblBalance.Text = Saldo;
            retirar.lblUsuarioID.Text = UsuarioID.ToString();
            retirar.Show();
        }
    }
}
