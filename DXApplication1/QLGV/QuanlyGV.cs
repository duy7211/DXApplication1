using DevExpress.XtraEditors.Filtering.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class QuanlyGV : Form
    {
        public QuanlyGV()
        {
            InitializeComponent();
            GetAllGV();
        }
        public string createID()
        {
            string Id = "";
            SqlConnection con = Connect.GetDBConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select MAX(SUBSTRING(MasoGV,3,4)) from GiangVien", con);
            dataAdapter.Fill(dt);


            if (dt.Rows[0][0].ToString() == "")
            {
                Id = "GV0001";
            }
            else
            {
                string d = dt.Rows[0][0].ToString();
                int so = int.Parse(d);
                so += 1;
                if (so < 10)
                {
                    Id = "GV000" + so;
                }
                else if (so < 100)
                {
                    Id = "GV00" + so;
                }
                else
                {
                    Id = "GV" + so;
                }
            }
            return Id;
        }
        public void GetAllGV()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from GiangVien", con);
                dataAdapter.Fill(dt);
                gv1.DataSource = dt;
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
            if (tbHoten.Text != "" && tbGT.Text != "" && tbQ.Text != "" && tbsdt.Text != "" && datebNS.Text != "")
            {
                con.Open();
                string ms = createID();

                SqlCommand cmd = new SqlCommand("insert into GiangVien(MasoGV,Hoten,Gioitinh,Nsinh,Que,SĐT) values(@ms,@ht,@gt,@ns,@q,@sdt)", con);
                cmd.Parameters.AddWithValue("@ms", ms);
                cmd.Parameters.AddWithValue("@ht", tbHoten.Text);
                cmd.Parameters.AddWithValue("@gt", tbGT.Text);
                cmd.Parameters.AddWithValue("@ns", datebNS.Text);
                cmd.Parameters.AddWithValue("@q", tbQ.Text);
                cmd.Parameters.AddWithValue("@sdt", tbsdt.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành Công !");

                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();
                    GetAllGV();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }

        private void gv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gv1.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in gv1.SelectedRows)
                {
                    tbMaso.Text = row.Cells[0].Value.ToString();
                    tbHoten.Text = row.Cells[1].Value.ToString();
                    tbGT.Text = row.Cells[2].Value.ToString();
                    datebNS.Text = row.Cells[3].Value.ToString();
                    tbQ.Text = row.Cells[4].Value.ToString();
                    tbsdt.Text = row.Cells[5].Value.ToString();

                }
            }
            btnThem.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbHoten.Text != "" && tbGT.Text != "" && tbQ.Text != "" && tbsdt.Text != "" && datebNS.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Giangvien where MasoGV=@id", con);
                cmd.Parameters.AddWithValue("@id", tbMaso.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa Thành công !");
                    GetAllGV();
                    clear();
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại!");
                }
                finally
                {
                    con.Close();
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbHoten.Text != "" && tbGT.Text != "" && tbQ.Text != "" && tbsdt.Text != "" && datebNS.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Giangvien set Hoten=@ht,Gioitinh=@gt,NSinh=@ns,Que=@q,SĐT=@sdt where MasoGV=@id", con);
                cmd.Parameters.AddWithValue("@id", tbMaso.Text);
                cmd.Parameters.AddWithValue("@ht", tbHoten.Text);
                cmd.Parameters.AddWithValue("@gt", tbGT.Text);
                cmd.Parameters.AddWithValue("@ns", datebNS.Text);
                cmd.Parameters.AddWithValue("@q", tbQ.Text);
                cmd.Parameters.AddWithValue("@sdt", tbsdt.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật Thành công !");
                    GetAllGV();
                    clear();
                }
                catch
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
                finally
                {
                    con.Close();
                }

            }
        }
        private void clear()
        {
            tbMaso.Text ="";
            tbHoten.Text = "";
            tbGT.Text = "";
            datebNS.Text = "";
            tbQ.Text = "";
            tbsdt.Text = "";
            btnThem.Enabled = true;
        }

        private void QuanlyGV_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
