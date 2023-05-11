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
        private string nombre;

        public string Idmes
        {
            set { idmes = value; }
            get { return idmes; }
        }
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
    }
}
