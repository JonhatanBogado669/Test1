using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Vehiculo
    {
        private string idvehiculo;
        private string descripcion;
        private string chapa;
        private string idtipo_combus;

        public string IdVehiculo
        {
            set { idvehiculo = value; }
            get { return idvehiculo; }
        }public string Descripcion
        {
            set { descripcion = value; }
            get { return descripcion; }
        }
        public string Chapa
        {
            set { chapa = value; }
            get { return chapa; }
        }
        public string IdTipoCombus
        {
            set { idtipo_combus = value; }
            get { return idtipo_combus; }
        }
    }
}
