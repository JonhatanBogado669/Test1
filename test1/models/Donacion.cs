using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Donacion
    {
        private string iddonacion;
        private string donador;
        private string descripcion;
        private string cantidad;

        public string IdDonacion
        {
            set { iddonacion = value; }
            get { return iddonacion; }
        }
        public string Donador
        {
            set { donador = value; }
            get { return donador; }
        }
        public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }
        public string Cantidad
        {
            set { cantidad = value; }
            get { return cantidad; }
        }
    }
}
