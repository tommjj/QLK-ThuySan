using QL_ThuySan.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_ThuySan.controls
{
    public partial class LoginController : UserControl
    {
        private FrRoot fRoot;
        public LoginController(FrRoot fRoot)
        {
            InitializeComponent();
            this.fRoot = fRoot;
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            
            string username = tUsername.Text;
            string password = Password.Text;

            SqlDataReader data = fRoot.getDB().QueryRederData("SELECT * FROM accounts WHERE username='"+ username + "'");
            
            //DataTable data2 = fRoot.getDB().QueryTableData("SELECT * FROM accounts");
            //MessageBox.Show(data2.Rows[0].ItemArray[1].ToString());

            if (data.Read())
            {   
                if (data["password"].ToString().Trim() == password)
                {
                    fRoot.Logined();
                }
            }

            data.Close();
        }
            
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
    }
}
