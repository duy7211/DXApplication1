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
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select distinct Tenlop from Lop", con);
                dataAdapter.Fill(dt);
                cmblop.DataSource = dt;
                cmblop.DisplayMember = "Tenlop";
                cmblop.ValueMember = "Tenlop";
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

        private void LichHoc_Load(object sender, EventArgs e)
        {
            GetAlllop();
            GetAllkhoa();
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

        private void cmblop_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            DataRowView drv = (DataRowView)cmbKhoa.SelectedItem;
            khoa = drv["KhoaHoc"].ToString();
            tenlop = cmblop.SelectedValue.ToString();
            //khoa = cmbKhoa.SelectedValue.ToString();
            DataTable dt = InfoLop();
            //MessageBox.Show(tenlop+"-"+khoa);
            //MessageBox.Show(dt.Rows.Count.ToString());
            if (dt.Rows.Count > 0)
                {
                    tbMalop.Text = dt.Rows[0]["MasoLop"].ToString();
                    tbTenlop.Text = dt.Rows[0]["Tenlop"].ToString();
                    tbkhoa.Text = dt.Rows[0]["KhoaHoc"].ToString();
                    
                }
            DataTable lich = getLichhoc();
            dataGridView1.DataSource = lich;


            
        }

        private DataTable InfoLop()
        {
            DataTable dt = new DataTable();
            if (tenlop != "" && khoa != "")
            {
                
                SqlConnection con = Connect.GetDBConnection();
                con.Open();
                SqlCommand cmd = new SqlCommand("select MasoLop,Tenlop,KhoaHoc from Lop where Tenlop=N'" + tenlop+"' and KhoaHoc='"+khoa+"'",con);
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
            if (tenlop != "" && khoa != "")
            {
                SqlConnection con = Connect.GetDBConnection();
                con.Open();
                
                SqlCommand cmd = new SqlCommand("select Hoten,TenMH,TenPhong,Thu,TenCa,Tenlop,KhoaHoc " +
                    "from ThoiKB tkb,PhancongCV cv,ThoiGianLamviec tg, GiangVien gv, Monhoc mh,Phong p, Lop l,ca c " +
                    "where tkb.MasoPC = cv.MasoPC and tkb.MasoTG = tg.MasoTG and cv.MasoGV = gv.MasoGV and cv.MasoLop = l.MasoLop and cv.MasoMH = mh.MasoMH and tg.MasoCa = c.MasoCa and tg.MasoPhong = p.MasoPhong and TenLop=N'" + tenlop + "' and KhoaHoc=@k order by Thu,TenCa ", con);
                cmd.Parameters.AddWithValue("@k", khoa);
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
    }
}
