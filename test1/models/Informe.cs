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
        private string serv1040;
        private string serv1041;
        private string serv1043;

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
        public string Serv1040
        {
            set { serv1040 = value; }
            get { return serv1040; }
        }
        public string Serv1041
        {
            set { serv1041 = value; }
            get { return serv1041; }
        }
        public string Serv1043
        {
            set { serv1043 = value; }
            get { return serv1043; }
        }
    }
}
