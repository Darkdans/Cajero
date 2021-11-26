using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;
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
    public partial class Usuarios : Form
    {
        string mensajeBox = "Los campos con * son importantes y no pueden estar vacios.";
        Logica.Core core = new Core();
        UsuariosDA usuariosDA = new UsuariosDA();
        UsuariosLB usuariosLB = new UsuariosLB();
        public Usuarios()
        {
            InitializeComponent();
            RefrescarGrid();
        }

        public void RefrescarGrid()
        {
            //Se traen los elementos de la base de datos para refrescar la tabla.//
            dgvUsuarios.DataSource = usuariosDA.MostrarUsuarios().Tables[0];
            dgvUsuarios.Columns[0].Visible = false; //ID/
            //Se renombran los encabezados//
            dgvUsuarios.Columns[1].HeaderText = "Usuario";
            dgvUsuarios.Columns[2].HeaderText = "Nombre";
            dgvUsuarios.Columns[3].HeaderText = "Apellido Paterno";
            dgvUsuarios.Columns[4].HeaderText = "Apellido Materno";
            dgvUsuarios.Columns[5].HeaderText = "Contraseña";
            dgvUsuarios.Columns[6].HeaderText = "Correo";
            dgvUsuarios.Columns[7].HeaderText = "Teléfono";
            dgvUsuarios.Columns[8].HeaderText = "Puesto";
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;
            dgvUsuarios.ClearSelection();
            //Validación para que escoga solo elementos de la fila//
            if (indice >= 0)
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                btnAgregar.Enabled = false;
                cbxPuesto.DataSource = null;
                cbxPuesto.Items.Clear();
                lblID.Text = dgvUsuarios.Rows[indice].Cells[0].Value.ToString();
                txtUsuario.Text = dgvUsuarios.Rows[indice].Cells[1].Value.ToString();
                txtNombre.Text = dgvUsuarios.Rows[indice].Cells[2].Value.ToString();
                txtApellidoMaterno.Text = dgvUsuarios.Rows[indice].Cells[3].Value.ToString();
                txtApellidoPaterno.Text = dgvUsuarios.Rows[indice].Cells[4].Value.ToString();
                txtContrasena.Text = dgvUsuarios.Rows[indice].Cells[5].Value.ToString();
                txtCorreo.Text = dgvUsuarios.Rows[indice].Cells[6].Value.ToString();
                txtTelefono.Text = dgvUsuarios.Rows[indice].Cells[7].Value.ToString();
                RegistroSeleccionadoCombobox(indice);
            }
        }

        private UsuariosLB RecuperarInformación()
        {
            //Se recuperan los valores insertados en la interfaz gráfica y se pasan en un objeto//
            int ID = 0; int.TryParse(lblID.Text, out ID);
            usuariosLB.ID = ID;
            usuariosLB.usuario = txtUsuario.Text;
            usuariosLB.nombre = txtNombre.Text;
            usuariosLB.apellidoPaterno = txtApellidoPaterno.Text;
            usuariosLB.apellidoMaterno = txtApellidoMaterno.Text;
            usuariosLB.password = txtContrasena.Text;
            usuariosLB.telefono = txtTelefono.Text;
            usuariosLB.correo = txtCorreo.Text;
            int IDPuesto = 0; int.TryParse(cbxPuesto.SelectedValue.ToString(), out IDPuesto);
            usuariosLB.puestoID = IDPuesto;
            return usuariosLB;
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        public void LimpiarEntradas()
        {
            lblID.Text = "";
            txtUsuario.Text = "";
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtContrasena.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
            CargarCombobox(); //Lo pone en el indice 0 al ser pocos registros//
            //Activar/desactivar botones según lo que se requiera //
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            RefrescarGrid();
        }

        public void CargarCombobox()
        {
            cbxPuesto.DataSource = usuariosDA.MostrarPuestos().Tables[0];
            cbxPuesto.DisplayMember = "Puesto";
            cbxPuesto.ValueMember = "ID_puestos";
        }

        public void RegistroSeleccionadoCombobox(int indice)
        {
            int IDPuesto = 0; int.TryParse(dgvUsuarios.Rows[indice].Cells[8].Value.ToString(), out IDPuesto);
            cbxPuesto.DataSource = usuariosDA.MostrarNombrePuesto_De_IDUsuario(IDPuesto).Tables[0];
            cbxPuesto.DisplayMember = "Puesto";
            cbxPuesto.ValueMember = "ID_puestos";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Puesto = cbxPuesto.Text;
            string Usuario = txtUsuario.Text;
            string Nombre = txtNombre.Text;
            string Password = txtContrasena.Text;
            string Correo = txtCorreo.Text;
            if (String.IsNullOrEmpty(Puesto) || String.IsNullOrEmpty(Usuario) || String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Correo))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                bool result = Puesto.Equals("Seleccione");
                if (result) {
                    core.messageBox("Favor de seleccionar un puesto valido.");
                } else {
                    //Se agrega el registro de usuario//
                    usuariosDA.AgregarConSupervisor(RecuperarInformación());
                    LimpiarEntradas();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Mensaje = MessageBox.Show("¿Seguro que quieres eliminar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
            switch (Mensaje)
            {
                case DialogResult.Yes:
                    usuariosDA.Eliminar(RecuperarInformación());
                    LimpiarEntradas();
                    RefrescarGrid();
                    break;
                case DialogResult.No:
                    return;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Puesto = cbxPuesto.Text;
            string Usuario = txtUsuario.Text;
            string Nombre = txtNombre.Text;
            string Password = txtContrasena.Text;
            string Correo = txtCorreo.Text;
            if (String.IsNullOrEmpty(Puesto) || String.IsNullOrEmpty(Usuario) || String.IsNullOrEmpty(Nombre) || String.IsNullOrEmpty(Password) || String.IsNullOrEmpty(Correo))
            {
                core.messageBox(mensajeBox);
            }
            else
            {
                bool result = Puesto.Equals("Seleccione");
                if (result)
                {
                    core.messageBox("Favor de seleccionar un puesto valido.");
                }
                else
                {
                    DialogResult Mensaje = MessageBox.Show("¿Seguro que quieres modificar este registro?", "Mensaje del sistema", MessageBoxButtons.YesNo);
                    switch (Mensaje)
                    {
                        case DialogResult.Yes:
                            usuariosDA.Modificar(RecuperarInformación());
                            LimpiarEntradas();
                            RefrescarGrid();
                            break;
                        case DialogResult.No:
                            return;
                    }
                }
            }
            
        }



        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarCombobox();
        }

        private void cbxPuesto_Click(object sender, EventArgs e)
        {
            CargarCombobox();
        }

  
    }
}
