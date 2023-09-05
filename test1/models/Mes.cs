using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Mes
    {
        private string idmes;
        private string descripcion;

        public string IdMes
        {
            set { idmes = value; }
            get { return idmes; }
        }
        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }
    }
}
