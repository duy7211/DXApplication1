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

namespace DXApplication1.Lichhoc
{
    public partial class LichHoc : Form
    {
        private string tenlop = "";
        private string khoa ="";
        private string mslop = "";
        public LichHoc()
        {
            InitializeComponent();
            
        }
        public void GetAlllop()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select MaNganh,TenNganh from Nganh where TenNganh !='*'", con);
                dataAdapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                cmblop.DataSource = dt;
                cmblop.DisplayMember = "TenNganh";
                cmblop.ValueMember = "MaNganh";

            }
            catch (Exception)
            {
                MessageBox.Show("Không load được lớp học!");
            }
            finally
            {
                con.Close();
            }
        }

        private void LichHoc_Load(object sender, EventArgs e)
        {
            GetAlllop();
            //GetAllkhoa();
            //cmblop.SelectedIndex = 0;
            //cmbKhoa.SelectedIndex = 0;
        }

        private void GetAllkhoa()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select Khoahoc from Lop", con);
                dataAdapter.Fill(dt);
                cmbKhoa.DataSource = dt;
                cmbKhoa.DisplayMember = "Khoahoc";
                cmbKhoa.ValueMember = "Khoahoc";
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

      
        private DataTable InfoLop()
        {
            
            DataTable dt = new DataTable();
            if (cmblop.SelectedIndex != -1 )
            {
                
                SqlConnection con = Connect.GetDBConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("select MasoLop,KhoaHoc,TenNganh from lop l, nganh n where l.manganh = n.manganh and MasoLop = '" + mslop +"'",con);
                //cmd.Parameters.AddWithValue("@l", tenlop);
                //cmd.Parameters.AddWithValue("@k", khoa);
                try
                {
                    dt.Load(cmd.ExecuteReader());
                }
                catch
                {
                    //MessageBox.Show("Không load đc info lop!");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Rỗng");
            }
            return dt;
        }
        private DataTable getLichhoc()
        {
            DataTable dt = new DataTable();
            if (cmblop.SelectedIndex != -1 && cmbKhoa.SelectedIndex != -1)
            {
                SqlConnection con = Connect.GetDBConnection();
                con.Open();
                
                SqlCommand cmd = new SqlCommand("select Hoten,TenMH,TenPhong,Thu,TenCa,TenNganh,KhoaHoc from ThoiKB tkb,PhancongCV cv,ThoiGianLamviec tg, GiangVien gv, Monhoc mh,Phong p, Lop l,ca c,Nganh n where tkb.MasoPC = cv.MasoPC and tkb.MasoTG = tg.MasoTG and cv.MasoGV = gv.MasoGV and cv.MasoLop = l.MasoLop and cv.MasoMH = mh.MasoMH and tg.MasoCa = c.MasoCa and tg.MasoPhong = p.MasoPhong and l.MaNganh = n.MaNganh and l.MasoLop=@l order by Thu,TenCa ", con);
                cmd.Parameters.AddWithValue("@l", mslop);
                dt.Load(cmd.ExecuteReader());
                con.Close();
            }
            return dt;
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("TenCa"))
            {

                String stringValue = e.Value as string;
                if (stringValue == null) return;

                switch (stringValue)
                {
                    case "Ca 1":
                        e.Value = "1 2 3";
                        break;
                    case "Ca 2":
                        e.Value = "4 5";
                        break;
                    case "Ca 3":
                        e.Value = "6 7";
                        break;
                    case "Ca 4":
                        e.Value = "8 9 10";
                        break;
                    case "Ca 5":
                        e.Value = "11 12 13";
                        break;
                }
            }
        }

        private void cmblop_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            if (cmbKhoa.SelectedIndex != -1)
            {
                cmbKhoa.ResetText();
                cmbKhoa.SelectedIndex = -1;

            }
            string nganh = "";

            if (cmblop.SelectedIndex != -1)
            {

                nganh = cmblop.SelectedValue.ToString();
            }
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select MasoLop,KhoaHoc from Lop l, Nganh n where l.MaNganh = n.MaNganh and  n.MaNganh='" + nganh + "'", con);
                dataAdapter.Fill(dt);
                //dataGridView1.DataSource = dt;
                cmbKhoa.DataSource = dt;
                cmbKhoa.DisplayMember = "KhoaHoc";
                cmbKhoa.ValueMember = "MasoLop";

                if (cmbKhoa.SelectedIndex != -1)
                {
                    if (dt.Rows.Count == 0)
                    {
                        cmbKhoa.ResetText();
                        cmbKhoa.SelectedIndex = -1;
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Không load được Khoa!");
            }
            finally
            {
                con.Close();
            }
            //DataRowView drv = (DataRowView)cmblop.SelectedItem;
            //tenlop = drv["TenLop"].ToString();
            //tenlop = cmblop.SelectedValue.ToString();
            //DataTable dt = InfoLop();

            /*
             if (dt.Rows.Count > 0)
             {
                 tbMalop.Text = dt.Rows[0]["MasoLop"].ToString();
                 tbTenlop.Text = dt.Rows[0]["Tenlop"].ToString();
                 tbkhoa.Text = dt.Rows[0]["KhoaHoc"].ToString();

             } */
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbKhoa.SelectedIndex != -1)
            {
                mslop = cmbKhoa.SelectedValue.ToString();
            }
            DataRowView drv = (DataRowView)cmbKhoa.SelectedItem;
            //khoa = drv["KhoaHoc"].ToString();
            //tenlop = cmblop.SelectedValue.ToString();
            //khoa = cmbKhoa.SelectedValue.ToString();
            DataTable dt = InfoLop();
            //MessageBox.Show(tenlop+"-"+khoa);
            //MessageBox.Show(dt.Rows.Count.ToString());
            if (dt.Rows.Count > 0)
            {
                tbMalop.Text = dt.Rows[0]["MasoLop"].ToString();
                tbTenlop.Text = dt.Rows[0]["TenNganh"].ToString();
                tbkhoa.Text = dt.Rows[0]["KhoaHoc"].ToString();

            }
            DataTable lich = getLichhoc();
            dataGridView1.DataSource = lich;
            

        }

        private void clear()
        {
            tbkhoa.Text = "";
            tbTenlop.Text = "";
            tbkhoa.Text = "";
        }
    }
}
