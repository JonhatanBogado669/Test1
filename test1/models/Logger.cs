using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace test1.models
{
    public class Logger
    {
        public void Log(string username, string accion)
        {
                int idUsuario= Login.ObtenerIdUsuario(username);
                ConexionDB.InsertarAuditoria(idUsuario, accion);
        }
    }

}
