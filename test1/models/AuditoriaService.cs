using System;
using System.Data.SQLite;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    public class AuditoriaService
    {
        public static void RegistrarAuditoria(string username, string accion)
        {
            try
            {
                    username = UserSession.Username;
                    string horafecha = DateTime.Now.ToString("o");
                    string iduser = "select id from users where username='" + username + "' ";
                    SQLiteCommand cm = new SQLiteCommand(iduser, ConexionDB.conectar());
                    object id = cm.ExecuteScalar();
                    Convert.ToInt32(id);
                    string registrar = "insert into auditoria(idusuario,acceso,accion)values(" + id + ",'" + horafecha + "','" + accion + "')";
                    SQLiteCommand cmd = new SQLiteCommand(registrar, ConexionDB.conectar());
                    cmd.ExecuteNonQuery();
                    return;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
