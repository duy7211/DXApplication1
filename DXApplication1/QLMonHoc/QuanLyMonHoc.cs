using DXApplication1.QLNganh;
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

namespace DXApplication1.QLMonHoc
{
    public partial class QuanLyMonHoc : Form
    {
        public QuanLyMonHoc()
        {
            InitializeComponent();
            LoadData();
            GetAllMH();
        }
        private void clear()
        {
            tbMamon.Text = "";
            tbTenmon.Text = "";
            tbstc.Text = "";
            btnThem.Enabled = true;
            cbNganh.ResetText();
            cbNganh.SelectedIndex = -1;
        }
        public string createID()
        {
            string Id = "";
            SqlConnection con = Connect.GetDBConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select MAX(SUBSTRING(MasoMH,3,4)) from Monhoc", con);
            dataAdapter.Fill(dt);


            if (dt.Rows[0][0].ToString() == "")
            {
                Id = "MH0001";
            }
            else
            {
                string d = dt.Rows[0][0].ToString();
                int so = int.Parse(d);
                so += 1;
                if (so < 10)
                {
                    Id = "MH000" + so;
                }
                else if (so < 100)
                {
                    Id = "MH00" + so;
                }
                else
                {
                    Id = "MH" + so;
                }
            }
            return Id;
        }
        public void GetAllMH()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select MasoMH,TenMH,Sotc,TenNganh from Monhoc m, Nganh n where m.MaNganh=n.MaNganh", con);
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                //select MasoMH,TenMH,Sotc,TenNganh from Monhoc m, Nganh n where m.MaNganh=n.MaNganh
                //select MasoMH,TenMH,Sotc,MaNganh from Monhoc
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
            if (tbTenmon.Text != "" && tbstc.Text != "")
            {
                con.Open();
                string ms = createID();
                string Nganh = cbNganh.SelectedValue.ToString();

                SqlCommand cmd = new SqlCommand("insert into Monhoc(MasoMH,TenMH,Sotc,MaNganh) values(@ms,@tm,@stc,@n)", con);
                cmd.Parameters.AddWithValue("@ms", ms);
                cmd.Parameters.AddWithValue("@tm", tbTenmon.Text);
                cmd.Parameters.AddWithValue("@stc", tbstc.Text);
                cmd.Parameters.AddWithValue("@n", Nganh);
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
                    GetAllMH();
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
            if (tbTenmon.Text != "" && tbstc.Text != "")
            {
                con.Open();
                string Nganh = cbNganh.SelectedValue.ToString();

                SqlCommand cmd = new SqlCommand("update Monhoc set TenMH=@tm,Sotc=@stc,MaNganh=@n where MasoMH=@id", con);
                cmd.Parameters.AddWithValue("@id", tbMamon.Text);
                cmd.Parameters.AddWithValue("@tm", tbTenmon.Text);
                cmd.Parameters.AddWithValue("@stc", tbstc.Text);
                cmd.Parameters.AddWithValue("@n", Nganh);
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
                    GetAllMH();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string nganh = "";
            if (dataGridView1.Rows.Count > 0)
            {
                
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    tbMamon.Text = row.Cells[0].Value.ToString();
                    tbTenmon.Text = row.Cells[1].Value.ToString();
                    tbstc.Text = row.Cells[2].Value.ToString();
                    nganh = row.Cells[3].Value.ToString();
                }
            }
            int indexNghanh = cbNganh.FindString(nganh);
            cbNganh.SelectedIndex = indexNghanh;
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbTenmon.Text != "" && tbstc.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Monhoc where MasoMH=@id", con);
                cmd.Parameters.AddWithValue("@id", tbMamon.Text);

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
                    GetAllMH();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }

        private void QuanLyMonHoc_DoubleClick(object sender, EventArgs e)
        {
            clear();
        }

        private void LoadData()
        {
            SqlConnection con = Connect.GetDBConnection();
            //Load Giảng viên
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Nganh", con);
                dataAdapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                cbNganh.DataSource = dt;
                cbNganh.DisplayMember = "TenNganh";
                cbNganh.ValueMember = "MaNganh";
            }
            catch (Exception)
            {
                MessageBox.Show("Không load được giảng viên!");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
