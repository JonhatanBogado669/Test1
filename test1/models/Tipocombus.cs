using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Tipocombus
    {
        private string idtipo_combus;
        private string descripcion;

        public string IdTipoCombus
        {
            set { idtipo_combus = value; }
            get { return idtipo_combus; }
        }
        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }
    }
}
