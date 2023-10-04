using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_ThuySan.models
{
    class Account
    {
        private DepotDB db;
        private int id;
        private string username;
        private string password;

        public int Id
        {
            get { return id; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            set { password = value; }
        }

        public Account(DepotDB db) 
        {
            this.db = db;
        }

        public bool Verification ()
        {
            return true;
        }
    }
}
