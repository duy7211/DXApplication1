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

namespace DXApplication1.QLLopHoc
{
    public partial class QuanlyLop : Form
    {
        public QuanlyLop()
        {
            InitializeComponent();
            GetAllLop();
        }
        public string createID()
        {
            string Id = "";
            SqlConnection con = Connect.GetDBConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select MAX(SUBSTRING(MasoLop,3,4)) from Lop", con);
            dataAdapter.Fill(dt);


            if (dt.Rows[0][0].ToString() == "")
            {
                Id = "LH0001";
            }
            else
            {
                string d = dt.Rows[0][0].ToString();
                int so = int.Parse(d);
                so += 1;
                if (so < 10)
                {
                    Id = "LH000" + so;
                }
                else if (so < 100)
                {
                    Id = "LH00" + so;
                }
                else
                {
                    Id = "LH" + so;
                }
            }
            return Id;
        }
        public void GetAllLop()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Lop", con);
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
            if (tbTenlop.Text != "" && tbKhoa.Text != "")
            {
                con.Open();
                string ms = createID();

                SqlCommand cmd = new SqlCommand("insert into Lop(MasoLop,Tenlop,KhoaHoc) values(@ms,@tl,@k)", con);
                cmd.Parameters.AddWithValue("@ms", ms);
                cmd.Parameters.AddWithValue("@tl", tbTenlop.Text);
                cmd.Parameters.AddWithValue("@k", tbKhoa.Text);  
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
                    GetAllLop();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }
        private void clear()
        {
            tbMalop.Text = "";
            tbTenlop.Text = "";
            tbKhoa.Text = "";
            btnThem.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbTenlop.Text != "" && tbKhoa.Text != "")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update Lop set Tenlop=@tl,KhoaHoc=@k where MasoLop=@id", con);
                cmd.Parameters.AddWithValue("@id", tbMalop.Text);
                cmd.Parameters.AddWithValue("@tl", tbTenlop.Text);
                cmd.Parameters.AddWithValue("@k", tbKhoa.Text);
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
                    GetAllLop();
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
                    tbMalop.Text = row.Cells[0].Value.ToString();
                    tbTenlop.Text = row.Cells[1].Value.ToString();
                    tbKhoa.Text = row.Cells[2].Value.ToString(); 

                }
            }
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbTenlop.Text != "" && tbKhoa.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Lop where MasoLop=@id", con);     
                cmd.Parameters.AddWithValue("@id", tbMalop.Text);
             
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
                    GetAllLop();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }

        private void QuanlyLop_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
    }

