using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Movil
    {
        private string idmovil;
        private string totalkm;
        private string nomina;

        public string IdMovil
        {
            set { idmovil = value; }
            get { return idmovil; }
        }
        public string TotalKm
        {
            set { totalkm = value; }
            get { return totalkm; }
        }
        public string Nomina
        {
            set { nomina = value; }
            get { return nomina; }
        }
    }
}
