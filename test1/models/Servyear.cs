using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Servyear
    {
        private string idserv_year;
        private string year;
        private string cant;
        private string total;

        public string Idserv
        {
            set { idserv_year = value; }
            get { return idserv_year; }
        }
        public string Year
        {
            set { year = value; }
            get { return year; }
        }
        public string Cant
        {
            set { cant = value; }
            get { return cant; }
        }
        public string Total
        {
            set { total = value; }
            get { return total; }
        }
    }
}
