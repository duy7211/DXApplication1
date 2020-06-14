using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            string username = edtuser.Text;
            string password = edtpw.Text;
            user us = new user();
            string id = us.GetID(username, password);
            if(id != "")
            {
                
                Session.Id = id.ToString();
                Session.Username = username.ToString();
         
                Form1 fr1 = new Form1();
                this.Hide();
                fr1.ShowDialog();
                this.Close();
                
                //MessageBox.Show(id);

            }
            else
            {
                MessageBox.Show("Sai Tài khoản hoặc mật khẩu !");
            }
        }

        private void retype_Click(object sender, EventArgs e)
        {
            edtuser.Text = "";
            edtpw.Text = "";
        }
    }
}
