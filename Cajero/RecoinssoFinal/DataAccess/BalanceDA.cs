using RecoinssoFinal.Logica;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecoinssoFinal.DataAccess
{
    internal class BalanceDA
    {
        string connectionData = ConfigurationManager.ConnectionStrings["connectionProperties"].ConnectionString;
        SqlConnection Conexion;
        Core core = new Core();

        public SqlConnection EstablecerConexión()
        {
            this.Conexion = new SqlConnection(this.connectionData);
            return this.Conexion;
        }
        ConexionDA conexion;
        public BalanceDA()
        {
            conexion = new ConexionDA();
        }
        public string MostrarBalanceUsuario(int UsuarioID)
        {
            string Balance = "";
            try
            {
                using (SqlConnection conexion = new SqlConnection(connectionData))
                {

                    conexion.Open();
                    using (SqlCommand commando = new SqlCommand(" SELECT saldo FROM cuentas WHERE usuarioID = '" + UsuarioID + "'", conexion))
                    {
                        SqlDataReader registro = commando.ExecuteReader();
                        if (registro.Read())
                        {
                            Balance = registro["saldo"].ToString();
                            return Balance;
                        }
                        else
                        {
                            return Balance;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
                return Balance;

            }
        }
    }
}
