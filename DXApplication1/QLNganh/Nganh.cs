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

namespace DXApplication1.QLNganh
{
    public partial class Nganh : Form
    {
        public Nganh()
        {
            InitializeComponent();
            GetAllNganh();
        }

        private void clear()
        {
            tbManganh.Text = "";
            tbTennganh.Text = "";
            
            btnThem.Enabled = true;
        }
        public string createID()
        {
            string Id = "";
            SqlConnection con = Connect.GetDBConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select MAX(SUBSTRING(MaNganh,3,4)) from Nganh", con);
            dataAdapter.Fill(dt);


            if (dt.Rows[0][0].ToString() == "")
            {
                Id = "NG0001";
            }
            else
            {
                string d = dt.Rows[0][0].ToString();
                int so = int.Parse(d);
                so += 1;
                if (so < 10)
                {
                    Id = "NG000" + so;
                }
                else if (so < 100)
                {
                    Id = "NG00" + so;
                }
                else
                {
                    Id = "NG" + so;
                }
            }
            return Id;
        }
        public void GetAllNganh()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Nganh", con);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbTennganh.Text != "")
            {
                con.Open();
                string ms = createID();

                SqlCommand cmd = new SqlCommand("insert into Nganh(MaNganh,TenNganh) values(@ms,@n)", con);
                cmd.Parameters.AddWithValue("@ms", ms);  
                cmd.Parameters.AddWithValue("@n", tbTennganh.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành Công !");
                    clear();

                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();
                    GetAllNganh();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbTennganh.Text != "")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update Nganh set TenNganh=@n where MaNganh=@id", con);
                cmd.Parameters.AddWithValue("@id", tbManganh.Text);
                cmd.Parameters.AddWithValue("@n", tbTennganh.Text);
                
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công thành Công !");
                    clear();

                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();
                    GetAllNganh();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    tbManganh.Text = row.Cells[0].Value.ToString();
                    tbTennganh.Text = row.Cells[1].Value.ToString();
                    

                }
            }
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbTennganh.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Nganh where MaNganh=@id", con);
                cmd.Parameters.AddWithValue("@id", tbManganh.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành Công !");
                    clear();


                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();
                    GetAllNganh();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }

        private void Nganh_DoubleClick(object sender, EventArgs e)
        {
            clear();
        }
    }
}
