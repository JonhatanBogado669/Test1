using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    public class Auditoria
    {
        private string id;
        private string idusuario;
        private string acceso;
        private string accion;


        public string Id
        {
            set { id = value; }
            get { return id; }
        }
        public string Idusuario
        {
            set { idusuario = value; }
            get { return idusuario; }
        }
        public string Acceso
        {
            set { acceso = value; }
            get { return acceso; }
        }
        public string Accion
        {
            set { accion = value; }
            get { return accion; }
        }
    }
}
