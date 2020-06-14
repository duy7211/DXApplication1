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
    public partial class Changepw : Form
    {
        public Changepw()
        {
            InitializeComponent();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("ID: " + Session.Id + " Tên đăng nhập: " + Session.Username);
            if (edtchagepw.Text != "" && edtrepw.Text != "" && (edtchagepw.Text == edtrepw.Text))
            {
                user update = new user();
                Boolean b = update.UpdatePw(edtrepw.Text);
                
                
                if (b)
                {
                    MessageBox.Show("Cập nhật thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }else
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
            }

            }
        

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            edtchagepw.Text = "";
            edtrepw.Text = "";
        }
    }
}
