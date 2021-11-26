using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;
using System.Configuration;
using System.Data.SqlClient;
using RecoinssoFinal.Presentación.VentanaMenú;

namespace RecoinssoFinal.Presentación
{
    public partial class VentanaPrincipal : Form
    {
        LoginLB loginLB = new LoginLB();
        ConexionDA conexion = new ConexionDA();
        Core core = new Core();

        string connectionData = ConfigurationManager.ConnectionStrings["connectionProperties"].ConnectionString;
        SqlConnection Conexion;

        public SqlConnection EstablecerConexión()
        {
            this.Conexion = new SqlConnection(this.connectionData);
            return this.Conexion;
        }

        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void BarradeTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public VentanaPrincipal()
        {
            InitializeComponent();
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

        private void btnNumero1_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "1";
        }

        private void btnNumero2_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "2";
        }

        private void btnNumero3_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "3";
        }

        private void btnNumero4_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "4";
        }

        private void btnNumero5_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "5";
        }

        private void btnNumero6_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "6";
        }

        private void btnNumero7_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "7";
        }

        private void btnNumero8_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "8";
        }

        private void btnNumero9_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "9";
        }

        private void btnNumeroGato_Click(object sender, EventArgs e)
        {

        }

        private void btnNumero0_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "0";
        }

        private void btnNumero00_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "00";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres salir?", "Salir", MessageBoxButtons.YesNo);
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
            txtPassword.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length >= 1)
            {
                string lastChar = txtPassword.Text.Substring(0, txtPassword.Text.Length - 1);
                txtPassword.Text = lastChar;
            }
        }

        private LoginLB recuperarInformación()
        {
            loginLB.password = txtPassword.Text;
            return loginLB;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string Password = txtPassword.Text;
            if (String.IsNullOrEmpty(Password))
            {
                core.messageBox("No debe estar el PIN/Clave vacios.");
            }
            else
            {
                int estatus = conexion.login(recuperarInformación());
                if (estatus > 0)
                {
                    VentanaPrincipal ventana = new VentanaPrincipal();
                    this.Close();
                    Menú menu = new Menú();
                    string Nombre = conexion.nombreUsuario(estatus);
                    menu.lblUsuario.Text = Nombre.ToString();
                    menu.lblUsuarioID.Text = estatus.ToString();
                    menu.Show();
                }
                else
                {
                    core.messageBox("PIN incorrecto, favor de intentarlo de nuevo.");
                }
            }
        }
    }
}
