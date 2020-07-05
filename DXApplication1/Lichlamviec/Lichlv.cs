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

namespace DXApplication1.Lichlamviec
{
    
    public partial class Lichlv : Form
    {
        private string tengv;
        //private int i;
        public Lichlv()
        {
            InitializeComponent();
            
        }
        private void GetAllGV()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select MasoGV,Hoten from GiangVien", con);
                dataAdapter.Fill(dt);
                cmbGV.DataSource = dt;
                cmbGV.DisplayMember = "Hoten";
                cmbGV.ValueMember = "MasoGV";
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

        private void cmbGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //i = cmbGV.SelectedIndex;
            tengv = cmbGV.SelectedValue.ToString();
            DataTable dt = GetInfo();
            if(dt.Rows.Count > 0)
            {
                tbMagv.Text = dt.Rows[0]["MasoGV"].ToString();
                tbTengv.Text = dt.Rows[0]["Hoten"].ToString();
                tbDiachi.Text = dt.Rows[0]["Que"].ToString();
                tbSĐT.Text = dt.Rows[0]["SĐT"].ToString();
                //MessageBox.Show(i.ToString());
            }

            DataTable lichlv = GetLichlv();
            try
            {
                dataGridView1.DataSource = lichlv;
            }
            catch
            {
                MessageBox.Show("Không thể thêm vào gridview");
            }
                
            
            
            
            
        }

        private DataTable GetInfo()
        {
            DataTable dt = new DataTable();
            SqlConnection con = Connect.GetDBConnection();
            con.Open();
            if (tengv != "")
            {
                
                SqlCommand cmd = new SqlCommand("select MasoGV,Hoten,Que,SĐT from GiangVien where MasoGV=@ms",con);
                cmd.Parameters.AddWithValue("@ms", tengv);
                
                try
                {
                    dt.Load(cmd.ExecuteReader());
                }
                catch
                {
                    MessageBox.Show("Lỗi!");
                }
                
                
                //MessageBox.Show(dt.Rows[3][0].ToString());
            }
            
            con.Close();
            return dt;
        }
        private DataTable GetLichlv()
        {
            SqlConnection con = Connect.GetDBConnection();
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select Hoten,TenMH,TenPhong,Thu,TenCa,TenNganh,KhoaHoc from ThoiKB tkb,PhancongCV cv,ThoiGianLamviec tg, GiangVien gv, Monhoc mh,Phong p, Lop l,ca c, Nganh n  where tkb.MasoPC = cv.MasoPC and tkb.MasoTG = tg.MasoTG and cv.MasoGV = gv.MasoGV and cv.MasoLop = l.MasoLop and l.MaNganh = n.MaNganh and cv.MasoMH = mh.MasoMH and tg.MasoCa = c.MasoCa and tg.MasoPhong = p.MasoPhong and gv.MasoGV=@ms order by Thu,TenCa", con);
            cmd.Parameters.AddWithValue("@ms", tengv);
            try
            {
                dt.Load(cmd.ExecuteReader());
            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        private void Lichlv_Load(object sender, EventArgs e)
        {
            GetAllGV();
            cmbGV.SelectedIndex = 0;  
            
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
