using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Utils.OAuth;
using DevExpress.XtraDashboardLayout;
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

namespace DXApplication1.PCCongViec
{
    public partial class PhanCongCV : Form
    {
        public string gv = "";
        public string mh = "";
        public string lop = "";
        public string khoa = "";
        //public string idpc = "";
        public PhanCongCV()
        {
            InitializeComponent();
            LoadData();
            GetAllPC();
            //tbid.Visible = false;
            clear();
            
        }

        public void LoadData()
        {
            SqlConnection con = Connect.GetDBConnection();
            //Load Giảng viên
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select MasoGV,Hoten from GiangVien", con);
                dataAdapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                cbGV.DataSource = dt;
                cbGV.DisplayMember = "Hoten";
                cbGV.ValueMember = "MasoGV";
            }
            catch (Exception)
            {
                MessageBox.Show("Không load được giảng viên!");
            }
            finally
            {
                con.Close();
            }
            //Load lớp
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select distinct Tenlop from Lop", con);
                dataAdapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                cbLop.DataSource = dt;
                cbLop.DisplayMember = "Tenlop";
                cbLop.ValueMember = "Tenlop";
                
            }
            catch (Exception)
            {
                MessageBox.Show("Không load được lớp học!");
            }
            finally
            {
                con.Close();
            }
            //Load môn
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select MasoMH,TenMH from Monhoc", con);
                dataAdapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                cbMH.DataSource = dt;
                cbMH.DisplayMember = "TenMH";
                cbMH.ValueMember = "MasoMH";
            }
            catch (Exception)
            {
                MessageBox.Show("Không load được Môn học!");
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select KhoaHoc from Lop", con);
                dataAdapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                cbKhoa.DataSource = dt;
                cbKhoa.DisplayMember = "KhoaHoc";
                cbKhoa.ValueMember = "KhoaHoc";
            }
            catch (Exception)
            {
                MessageBox.Show("Không load được Khoa!");
            }
            finally
            {
                con.Close();
            }
        }
        public string createID()
        {
            string Id = "";
            SqlConnection con = Connect.GetDBConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select MAX(SUBSTRING(MasoPC,3,4)) from PhancongCV", con);
            dataAdapter.Fill(dt);


            if (dt.Rows[0][0].ToString() == "")
            {
                Id = "PC0001";
            }
            else
            {
                string d = dt.Rows[0][0].ToString();
                int so = int.Parse(d);
                so += 1;
                if (so < 10)
                {
                    Id = "PC000" + so;
                }
                else if (so < 100)
                {
                    Id = "PC00" + so;
                }
                else
                {
                    Id = "PC" + so;
                }
            }
            return Id;
        }
        public void clear()
        {
            
            tbid.Text = "";
        }
        public void GetAllPC()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("select MasoPC,Hoten,TenMH,Tenlop,Khoahoc " +
                    "from PhancongCV pc,GiangVien gv,Monhoc mh,Lop l " +
                    "where pc.MasoGV = gv.MasoGV and pc.MasoLop = l.MasoLop and pc.MasoMH = mh.MasoMH ", con);
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
            string khoa = cbKhoa.SelectedValue.ToString();
            string giangvien = cbGV.SelectedValue.ToString();
            string lop = cbLop.SelectedValue.ToString();
            string mh = cbMH.SelectedValue.ToString();
            string malop = "";
            SqlConnection con = Connect.GetDBConnection();
            //lấy mã lớp
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select MasoLop from Lop where Tenlop=N'"+ lop +"' and KhoaHoc=N'" + khoa + "'", con);
                ad.Fill(dt);
                //TenLop= N'"+ lop +"',
                malop = dt.Rows[0][0].ToString();
                
            }
            catch (Exception)
            {
                //MessageBox.Show("Không load được giảng viên!");
                MessageBox.Show("Tên lớp: "+lop+" Khóa: "+khoa);
            }
            finally
            {
                con.Close();
            }
            if (khoa != "" && giangvien !="" && lop!="" && mh != "")
            {
                //string id = createID();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into PhancongCV(MasoGV,MasoMH,MasoLop) values(@gv,@mh,@l)", con);
                //cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@gv", giangvien);
                cmd.Parameters.AddWithValue("@mh", mh);
                cmd.Parameters.AddWithValue("@l", malop);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành Công !");
                    //clear();


                }
                catch (Exception)
                {
                    MessageBox.Show("Thêm thất bại");

                }
                finally
                {
                    con.Close();
                    GetAllPC();
                }
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string khoa = cbKhoa.SelectedValue.ToString();
            string giangvien = cbGV.SelectedValue.ToString();
            string lop = cbLop.SelectedValue.ToString();
            string mh = cbMH.SelectedValue.ToString();
            string malop = "";
            SqlConnection con = Connect.GetDBConnection();
            //lấy mã lớp
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select MasoLop from Lop where Tenlop=N'" + lop + "' and KhoaHoc=N'" + khoa + "'", con);
                ad.Fill(dt);
                //TenLop= N'"+ lop +"',
                malop = dt.Rows[0][0].ToString();

            }
            catch (Exception)
            {
                //MessageBox.Show("Không lấy được mã lớp!");
                //MessageBox.Show("Tên lớp: " + lop + " Khóa: " + khoa);
            }
            finally
            {
                con.Close();
            }
            if (khoa != "" && giangvien != "" && lop != "" && mh != "")
            {
                string idpc = tbid.Text;
                
                con.Open();
                SqlCommand cmd = new SqlCommand("update PhancongCV set MasoGV=@gv,MasoMH=@mh,MasoLop=@l where MasoPC=@idpc", con);
                
                cmd.Parameters.AddWithValue("@gv", giangvien);
                cmd.Parameters.AddWithValue("@mh", mh);
                cmd.Parameters.AddWithValue("@l", malop);
                cmd.Parameters.AddWithValue("@idpc", idpc);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công thành Công !");
                    //clear();


                }
                catch (Exception)
                {
                    MessageBox.Show("Cập nhật thất bại");

                }
                finally
                {
                    con.Close();
                    GetAllPC();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //clear();
            
            if (dataGridView1.Rows.Count > 0)
            {
                
                 foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                 {
                     tbid.Text = row.Cells[0].Value.ToString();
                     //cbGV.SelectedText = row.Cells[1].Value.ToString();
                     mh = row.Cells[2].Value.ToString();
                     lop = row.Cells[3].Value.ToString();
                     khoa = row.Cells[4].Value.ToString();
                     gv = row.Cells[1].Value.ToString();

                 }
                
            }
            int indexgv = cbGV.FindString(gv);
            cbGV.SelectedIndex = indexgv;
            int indexmh = cbMH.FindString(mh);
            cbMH.SelectedIndex = indexmh;
            int indexlop = cbLop.FindString(lop);
            cbLop.SelectedIndex = indexlop;
            int indexkhoa = cbKhoa.FindString(khoa);
            cbKhoa.SelectedIndex = indexkhoa;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string khoa = cbKhoa.SelectedValue.ToString();
            string giangvien = cbGV.SelectedValue.ToString();
            string lop = cbLop.SelectedValue.ToString();
            string mh = cbMH.SelectedValue.ToString();
            string malop = "";
            SqlConnection con = Connect.GetDBConnection();
            //lấy mã lớp
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select MasoLop from Lop where Tenlop=N'" + lop + "' and KhoaHoc=N'" + khoa + "'", con);
                ad.Fill(dt);
                //TenLop= N'"+ lop +"',
                malop = dt.Rows[0][0].ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Không lấy được mã lớp!");
                //MessageBox.Show("Tên lớp: " + lop + " Khóa: " + khoa);
            }
            finally
            {
                con.Close();
            }
            if (khoa != "" && giangvien != "" && lop != "" && mh != "")
            {
                string idpc = tbid.Text;
               
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from PhancongCV where MasoPC=@idpc", con);
                
                cmd.Parameters.AddWithValue("@gv", giangvien);
                cmd.Parameters.AddWithValue("@mh", mh);
                cmd.Parameters.AddWithValue("@l", malop);
                cmd.Parameters.AddWithValue("@idpc", idpc);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công thành Công !");
                    //clear();


                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thất bại!");

                }
                finally
                {
                    con.Close();
                    GetAllPC();
                }
            }
        }
    }
}
