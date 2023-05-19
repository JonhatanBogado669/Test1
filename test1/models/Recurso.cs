using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Recurso
    {
        private string idrecurso;
        private string agua;
        private string pqsco2;
        private string combustible;
        private string bombero;
        private string tiempototal;
        private string kmrecorrido;

        public string IdRecurso
        {
            set { idrecurso = value; }
            get { return idrecurso; }
        }
        public string Agua
        {
            set { agua = value; }
            get { return agua; }
        }
        public string Pqsco2
        {
            set { pqsco2 = value; }
            get { return pqsco2; }
        }
        public string Combustible
        {
            set { combustible = value; }
            get { return combustible; }
        }
        public string Bombero
        {
            set { bombero = value; }
            get { return bombero; }
        }
        public string TiempoTotal
        {
            set { tiempototal = value; }
            get { return tiempototal; }
        }
        public string KmRecorrido
        {
            set { kmrecorrido = value; }
            get { return kmrecorrido; }
        }
    }
}
