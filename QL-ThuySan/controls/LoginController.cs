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

            /*
            using (var context = new Models())
            {
                var acc = new account
                {
                    username = username,
                    password = password
                };

                context.accounts.Add(acc);
                context.SaveChanges();
            }*/

            var query = fRoot.getContext().accounts.SingleOrDefault(s => s.username == username);

            if(query != null)
            {
                if(password == query.password.TrimEnd(' '))
                {
                    fRoot.Logined(query.Id);
                    Password.Text = "";
                    return;
                }
            } 
            
            Lerr.Text = "Tài khoảng hoặc mật khẩu sai!";     
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
