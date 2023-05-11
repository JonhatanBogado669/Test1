using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Tabla
    {
        private string idtabla;
        private string tras_pac;
        private string cobertura;
        private string acc_trans;
        private string ani_ali;
        private string rescate;
        private string total_mes;
        private string inc_est;
        private string inc_past;
        private string inc_veh;

        public string Idtabla
        {
            set { idtabla = value; }
            get { return idtabla; }
        }
    public string TrasPac
        {
            set { tras_pac = value; }
            get { return tras_pac; }
        }
        public string Cobertura
        {
            set { cobertura = value; }
            get { return cobertura; }
        }
        public string AccTrans
        {
            set { acc_trans = value; }
            get { return acc_trans; }
        }
        public string AniAli
        {
            set { ani_ali = value; }
            get { return ani_ali; }
        }
        public string Rescate
        {
            set { rescate = value; }
            get { return rescate; }
        }
        public string Totalmes
        {
            set { total_mes = value; }
            get { return total_mes; }
        }
        public string Incest
        {
            set { inc_est = value; }
            get { return inc_est; }
        }
        public string Incpast
        {
            set { inc_past = value; }
            get { return inc_past; }
        }
        public string Incveh
        {
            set { inc_veh = value; }
            get { return inc_veh; }
        }
    }
}
