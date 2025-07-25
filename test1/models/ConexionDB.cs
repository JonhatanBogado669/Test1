using System;
using System.IO;
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
            Console.WriteLine("Ruta absoluta: " + Path.GetFullPath("data.sqlite"));
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
    }
}
