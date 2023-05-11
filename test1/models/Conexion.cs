using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

class Conexion
{

    public static MySqlConnection conectar()
    {
        string cadenaconexion = "server=localhost" + ";port=3306" + ";user id=root" + ";password=root" + ";database=bombero;";
        MySqlConnection conexionDB = new MySqlConnection(cadenaconexion);
        conexionDB.Open();
        return conexionDB;

    }
}