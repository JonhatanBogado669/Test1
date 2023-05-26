using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Informe
    {
        private string idinforme;
        private string fechaenv;
        private string horamesanho;
        private string cantcia_est;
        private string autor;
        private string telefono;
        private string lugar;
        private string fax;
        private string fechacierre;
        private string cantserv;
        private string idserv1040;
        private string idserv1041;
        private string idserv1043;

        public string IdInforme
        {
            set { idinforme = value; }
            get { return idinforme; }
        }
        public string FechaEnv
        {
            set { fechaenv = value; }
            get { return fechaenv; }
        }
        public string HoraMesAnho
        {
            set { horamesanho = value; }
            get { return horamesanho; }
        }
        public string CantCiaEst
        {
            set { cantcia_est = value; }
            get { return cantcia_est; }
        }
        public string Autor
        {
            set { autor = value; }
            get { return autor; }
        }
        public string Telefono
        {
            set { telefono = value; }
            get { return telefono; }
        }
        public string Lugar
        {
            set { lugar = value; }
            get { return lugar; }
        }
        public string Fax
        {
            set { fax = value; }
            get { return fax; }
        }
        public string FechaCierre
        {
            set { fechacierre = value; }
            get { return fechacierre; }
        }
        public string CantServ
        {
            set { cantserv = value; }
            get { return cantserv; }
        }
        public string IdServ1040
        {
            set { idserv1040 = value; }
            get { return idserv1040; }
        }
        public string IdServ1041
        {
            set { idserv1041 = value; }
            get { return idserv1041; }
        }
        public string IdServ1043
        {
            set { idserv1043 = value; }
            get { return idserv1043; }
        }
    }
}
