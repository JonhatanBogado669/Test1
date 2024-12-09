using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace test1.models
{
    class ConexionDB
    {
        public static SQLiteConnection conectar()
        {
            string connectionString = "Data Source= bomberoDB.db;Version=3;";
            SQLiteConnection conexionDB = new SQLiteConnection(connectionString);

            try
            {
                conexionDB.Open();
                Console.WriteLine("Conexión exitosa a SQLite!");
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("Error al conectar a SQLite: " + ex.Message);
            }

            return conexionDB;
        }
        
        public static void InsertarAuditoria(int idUsuario, string accion)
        {
            using (var conexion = conectar())
            {
                
                string query = "INSERT INTO Auditoria (idusuario, acceso, accion) VALUES (@IdUsuario, @Acceso, @Accion)";
                using (var cmd = new SQLiteCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.Parameters.AddWithValue("@Acceso", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Accion", accion);

                    cmd.ExecuteNonQuery();
                }
                
            }

        }
    }
}
