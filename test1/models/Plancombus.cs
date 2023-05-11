using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Plancombus
    {
        private string idplan_combus;
        private string entidad;
        private string periodo;
        private string idvehiculo;
        private string nombre;
        private string ci;
        private string fecha;
        private string lugar_sal;
        private string km_salida;
        private string lugar_dest;
        private string km_llegada;
        private string km_recorrido;
        private string motivo;
        private string lts_carg;
        private string nro_fact;
        private string imp_total;

        public string Idplancombus
        {
            set { idplan_combus = value; }
            get { return idplan_combus; }
        }
        public string Entidad
        {
            set { entidad = value; }
            get { return entidad; }
        }
        public string Periodo
        {
            set { periodo = value; }
            get { return periodo; }
        }
        public string Idvehiculo
        {
            set { idvehiculo = value; }
            get { return idvehiculo; }
        }
        public string Nombre
        {
            set { nombre = value; }
            get { return nombre; }
        }
        public string Ci
        {
            set { ci = value; }
            get { return ci; }
        }
        public string Fecha
        {
            set { fecha = value; }
            get { return fecha; }
        }
        public string LugarSal
        {
            set { lugar_sal = value; }
            get { return lugar_sal; }
        }
        public string KmSalida
        {
            set { km_salida = value; }
            get { return km_salida; }
        }
        public string LugarDest
        {
            set { lugar_dest = value; }
            get { return lugar_dest; }
        }
        public string KmLlegada
        {
            set { km_llegada = value; }
            get { return km_llegada; }
        }
        public string KmRecorrido
        {
            set { km_recorrido = value; }
            get { return km_recorrido; }
        }
        public string Motivo
        {
            set { motivo = value; }
            get { return motivo; }
        }
        public string LtsCarg
        {
            set { lts_carg = value; }
            get { return lts_carg; }
        }
        public string Nrofact
        {
            set { nro_fact = value; }
            get { return nro_fact; }
        }
        public string Imptotal
        {
            set { imp_total = value; }
            get { return imp_total; }
        }
    }
}
