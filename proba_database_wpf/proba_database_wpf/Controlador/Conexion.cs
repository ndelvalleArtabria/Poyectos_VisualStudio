using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace proba_database_wpf.Controlador
{
    class Conexion
    {
        private static SqlConnection con;

        #region Conexion

        static readonly string dataSource = "CANTON-06";
        static readonly string initialCatalog = "GESTION_DLLS";
        static readonly string usuario = "dlls";
        static readonly string contrasinal = "dlls.123";

        public static void Conectar()
        {
            con = new SqlConnection(
                $"Data Source={dataSource};" +
                $"Initial Catalog={initialCatalog};" +
                $"Persist Security Info=True;" +
                $"MultipleActiveResultSets=True;" +
                $"User ID={usuario};" +
                $"Password={contrasinal}");
            con.Open();
            Console.WriteLine("Conectado");
        }
        public static void Desconectar()
        {
            con.Close();
            Console.WriteLine("Desconectado");
        }

        #endregion

        #region Consultas

        public static void insertNewUser(string username, string pass, string mail)
        {
            SqlCommand cmd = new SqlCommand(
                $"INSERT INTO usuarios (nomeusuario, contrasinal, correo) VALUES ('{username}', HASHBYTES('SHA2_512','{pass}'), '{mail}'); "
                ,con);
            cmd.ExecuteNonQuery();
        }
        public static SqlDataReader selectUserId(string username, string pass)
        {
            SqlCommand cmd = new SqlCommand(
                $"SELECT id FROM usuarios WHERE nomeusuario = '{username}' AND contrasinal = HASHBYTES('SHA2_512', '{pass}') ; "
                , con);
            SqlDataReader lector = cmd.ExecuteReader();
            return lector;
        }
        public static SqlDataReader selectUserDlls(int id_usuario)
        {
            SqlCommand cmd = new SqlCommand(
                $"SELECT id, nomedll, descripcion FROM dlls WHERE id_usuario = {id_usuario} ; "
                , con);
            SqlDataReader lector = cmd.ExecuteReader();
            return lector;
        }
        public static void insertNewDll(string nomedll, string descripcion, int id_usuario)
        {
            Console.WriteLine(con.State);
            SqlCommand cmd = new SqlCommand(
                $"INSERT INTO dlls (nomedll, descripcion, id_usuario) VALUES ('{nomedll}', '{descripcion}', {id_usuario});"
                , con);
            cmd.ExecuteNonQuery();
        }
        public static void deleteUserDll(int id_dll)
        {
            SqlCommand cmd = new SqlCommand(
                $"DELETE FROM dlls WHERE id = {id_dll} ; "
                , con);
            cmd.ExecuteNonQuery();
        }
        public static SqlDataReader selectValuesForUpdate(int id_dll)
        {
            SqlCommand cmd = new SqlCommand(
                $"SELECT nomedll, descripcion FROM dlls WHERE id_usuario = {id_dll} ; "
                , con);
            SqlDataReader lector = cmd.ExecuteReader();
            return lector;
        }
        public static void updateUserDll(string nomedll, string descripcion, int id_dll)
        {
            SqlCommand cmd = new SqlCommand(
                $"UPDATE dlls SET nomedll = '{nomedll}' , descripcion = '{descripcion}' WHERE id = {id_dll} ; "
                , con);
            cmd.ExecuteNonQuery();
        }

        #endregion
    }
}
