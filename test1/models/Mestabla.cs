using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Mestabla
    {
        private string idmes;
        private string idtabla;

        public string Idmes
        {
            set { idmes = value; }
            get { return idmes; }
        }
        public string Idtabla
        {
            set { idtabla = value; }
            get { return idtabla; }
        }
    }
}
