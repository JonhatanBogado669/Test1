using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class PasswordReset
    {
        private string id;
        private string username;
        private string reset_code;

        public string Id { get; set; }
        public string Username { get; set; }
        public string ResetCode { get; set; }
    }
}
