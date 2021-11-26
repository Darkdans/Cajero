using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoinssoFinal.Logica;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace RecoinssoFinal.DataAccess
{ 
    internal class UsuariosDA {
        ConexionDA conexion;
        public UsuariosDA()
        {
            conexion = new ConexionDA();
        }
        public DataSet MostrarUsuarios()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Usuarios");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarPuestos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Puestos");
            return conexion.EjecutarSentencia(sentencia);
        }

        public DataSet MostrarNombrePuesto_De_IDUsuario(int puestoID)
        {
            SqlCommand SQLComando = new SqlCommand("SELECT * FROM puestos WHERE ID_puestos = @ID_puesto");
            SQLComando.Parameters.Add("@ID_puesto", SqlDbType.Int).Value = puestoID;
            return conexion.EjecutarSentencia(SQLComando);
        }

        public bool Registrarse(UsuariosLB objUsuario)
        {
            string mensajeBox = "Se ha agregado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("INSERT INTO [dbo].[Usuarios] (usuario, nombre, apellidoMaterno, apellidoPaterno, password, correo, telefono, puestoID)" +
                "VALUES(@Usuario, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Password, @Correo, @Telefono, @ID_puesto)");
            SQLComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = objUsuario.usuario;
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objUsuario.nombre;
            SQLComando.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = objUsuario.apellidoMaterno;
            SQLComando.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = objUsuario.apellidoPaterno;
            SQLComando.Parameters.Add("@Password", SqlDbType.VarChar).Value = objUsuario.password;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = objUsuario.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objUsuario.correo;
            SQLComando.Parameters.Add("@ID_puesto", SqlDbType.Int).Value = 1; //Sin permisos//
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool AgregarConSupervisor(UsuariosLB objUsuario)
        {
            string mensajeBox = "Se ha agregado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("INSERT INTO Usuarios (usuario, nombre, apellidoPaterno, apellidoMaterno, password, correo, telefono, puestoID) VALUES" +
                "(@Usuario, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @Password, @Correo, @Telefono, @ID_puesto)");
            SQLComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = objUsuario.usuario;
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objUsuario.nombre;
            SQLComando.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = objUsuario.apellidoPaterno;
            SQLComando.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = objUsuario.apellidoMaterno;
            SQLComando.Parameters.Add("@Password", SqlDbType.VarChar).Value = objUsuario.password;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = objUsuario.telefono;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objUsuario.correo;
            SQLComando.Parameters.Add("@ID_usuario", SqlDbType.Int).Value = objUsuario.ID;
            SQLComando.Parameters.Add("@ID_puesto", SqlDbType.Int).Value = objUsuario.puestoID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Modificar(UsuariosLB objUsuario)
        {
            string mensajeBox = "Se ha modificado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("UPDATE Usuarios SET usuario = @Usuario, nombre = @Nombre, " +
                " apellidoPaterno = @ApellidoPaterno, apellidoMaterno = @ApellidoMaterno, correo = @Correo, password = @Password," +
                " telefono = @Telefono, puestoID = @ID_puesto  WHERE [ID] = @ID_usuario");
            SQLComando.Parameters.Add("@ID_usuario", SqlDbType.Int).Value = objUsuario.ID;
            SQLComando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = objUsuario.usuario;
            SQLComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = objUsuario.nombre;
            SQLComando.Parameters.Add("@ApellidoPaterno", SqlDbType.VarChar).Value = objUsuario.apellidoPaterno;
            SQLComando.Parameters.Add("@ApellidoMaterno", SqlDbType.VarChar).Value = objUsuario.apellidoMaterno;
            SQLComando.Parameters.Add("@Correo", SqlDbType.VarChar).Value = objUsuario.correo;
            SQLComando.Parameters.Add("@Password", SqlDbType.VarChar).Value = objUsuario.password;
            SQLComando.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = objUsuario.telefono;
            SQLComando.Parameters.Add("@ID_puesto", SqlDbType.Int).Value = objUsuario.puestoID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

        public bool Eliminar(UsuariosLB objUsuario)
        {
            string mensajeBox = "Se ha eliminado los datos correctamente.";
            SqlCommand SQLComando = new SqlCommand("DELETE FROM Usuarios WHERE [ID] = @ID_usuario");
            SQLComando.Parameters.Add("@ID_usuario", SqlDbType.Int).Value = objUsuario.ID;
            return conexion.ejecturarComandosSinRetornoDatos(SQLComando, mensajeBox);
        }

    }
}
