using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoinssoFinal.DataAccess;
using RecoinssoFinal.Logica;
using RecoinssoFinal.Presentación;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;
using System.Configuration;
using RecoinssoFinal.Presentación.VentanaMenú;

namespace RecoinssoFinal.DataAccess
{

    internal class ConexionDA
    {
        string connectionData = ConfigurationManager.ConnectionStrings["connectionProperties"].ConnectionString;
        SqlConnection Conexion;
        Core core = new Core();

        public SqlConnection EstablecerConexión()
        {
            this.Conexion = new SqlConnection(this.connectionData);
            return this.Conexion;
        }
        public bool ejecturarComandosSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {
                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexión();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;
            }
            catch
            {
                core.messageBox("Ha ocurrido un error al realizar la consulta");
                return false;
            }
        }
        public bool ejecturarComandosSinRetornoDatos(SqlCommand SQLComando, String mensajeBox)
        {
            try
            {
                SqlCommand Comando = SQLComando;
                Comando.Connection = this.EstablecerConexión();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                core.messageBox(mensajeBox);
                return true;
            }
            catch
            {
                core.messageBox("Ha ocurrido un error al realizar la consulta");
                return false;
            }
        }

        /*SELECT (Retorno de datos) */
        public DataSet EjecutarSentencia(SqlCommand sqlCommand)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();
            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlCommand;
                Comando.Connection = EstablecerConexión();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;
            }
        }

        public int login(LoginLB loginLB)
        {
            int Usuario = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionData))
                {
                  
                    conexion.Open();
                    using (SqlCommand commando = new SqlCommand("SELECT usuariosID, nombre, password FROM Usuarios WHERE password ='" + loginLB.password + "'", conexion)) { 
                        SqlDataReader registro = commando.ExecuteReader();
                        if (registro.Read()) {
                            VentanaPrincipal ventana = new VentanaPrincipal();
                            int.TryParse(registro["usuariosID"].ToString(), out Usuario);
                            return Usuario;
                        }
                        else {
                            return Usuario;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return Usuario;

            }
        }

        public string nombreUsuario(int Usuario)
        {
            string Nombre = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionData))
                {

                    conexion.Open();
                    using (SqlCommand commando = new SqlCommand("SELECT nombre FROM Usuarios WHERE usuariosID ='" + Usuario + "'", conexion))
                    {
                        SqlDataReader registro = commando.ExecuteReader();
                        if (registro.Read())
                        {
                            Nombre = registro["nombre"].ToString();
                            return Nombre;
                        }
                        else
                        {
                            return Nombre;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return Nombre;
            }
        }

        public int nombreUsuarioPorClave(int password)
        {
            int usuarioID = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionData))
                {

                    conexion.Open();
                    using (SqlCommand commando = new SqlCommand("SELECT usuariosID FROM Usuarios WHERE password ='" + password + "'", conexion))
                    {
                        SqlDataReader registro = commando.ExecuteReader();
                        if (registro.Read())
                        {
                            int.TryParse(registro["usuariosID"].ToString(), out usuarioID);
                            return usuarioID;
                        }
                        else
                        {
                            return usuarioID;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return usuarioID;
            }
        }

        /// Falta usar a cantidad y con un if seguir
        public int VerificarEfectivo(int usuarioID)
        {
            int Saldo = 0;
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionData))
                {

                    conexion.Open();
                    using (SqlCommand commando = new SqlCommand("SELECT saldo FROM cuentas WHERE usuarioID ='" + usuarioID + "'", conexion))
                    {
                        SqlDataReader registro = commando.ExecuteReader();
                        if (registro.Read())
                        {
                            int.TryParse(registro["saldo"].ToString(), out Saldo);
                            return Saldo;
                        }
                        else
                        {
                            return Saldo;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return Saldo;
            }
        }

        public bool RetirarEfectivo(int usuarioID, int cantidad)
        {
            string mensajeBox = "Se ha retirado el efectivo correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE cuentas SET saldo -= " + cantidad + " WHERE usuarioID = " + usuarioID);
            return ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool AgregarEfectivo(int usuarioID, int cantidad)
        {
            string mensajeBox = "Se ha agregado el efectivo correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE cuentas SET saldo += " + cantidad + " WHERE usuarioID = " + usuarioID);
            return ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }
    }
}
