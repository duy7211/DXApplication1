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

namespace DXApplication1.ca
{
    public partial class Calv : Form
    {
        public Calv()
        {
            InitializeComponent();
            GetAllca();
        }
        public void GetAllca()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Ca", con);
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối !");
            }
            finally
            {
                con.Close();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("flag"))
            {

                String stringValue = e.Value as string;
                if (stringValue == null) return;

                switch (stringValue)
                {
                    case "1":
                        e.Value = "Đang sử dụng";
                        break;
                    case "0":
                        e.Value = "không sử dụng";
                        break;
                   
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    tbMsCa.Text = row.Cells[0].Value.ToString();
                    tbCa.Text = row.Cells[1].Value.ToString();


                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbCa.Text != "")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update Ca set flag=@fl where MasoCa=@ms", con);
                cmd.Parameters.AddWithValue("@fl", "0");
                cmd.Parameters.AddWithValue("@ms", tbMsCa.Text);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành Công !" /*+ masoP.ToString()*/);
                    clear();


                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();
                    GetAllca();
                }
            }
        }
        private void clear()
        {
            tbMsCa.Text = "";
            tbCa.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbCa.Text != "")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update Ca set flag=@fl where MasoCa=@ms", con);
                cmd.Parameters.AddWithValue("@fl", "1");
                cmd.Parameters.AddWithValue("@ms", tbMsCa.Text);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành Công !" /*+ masoP.ToString()*/);
                    clear();


                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();
                    GetAllca();
                }
            }
        }
    }
}
