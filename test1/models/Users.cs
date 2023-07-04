using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1.models
{
    class Users
    {
        private string id;
        private string username;
        private string password;
        private string role;
        private string CI;
        private string correo;
        private string phone;

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Ci { get; set; }
        public string Correo { get; set; }
        public string Phone { get; set; }
    }
}
