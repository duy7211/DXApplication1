using DevExpress.Data.Async;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DXApplication1.XepTKB
{
    public partial class FrXepTKB : Form
    {
        
        public FrXepTKB()
        {
            InitializeComponent();
            tkb();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
       
        private void btnXepTKB_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();

                SqlDataAdapter dataAdapter = new SqlDataAdapter("select distinct l.MasoLop " +
                    "from PhanCongCV pc,GiangVien gv,Monhoc mh,Lop l " +
                    "where pc.MasoGV = gv.MasoGV and pc.MasoLop = l.MasoLop and pc.MasoMH = mh.MasoMH", con);
                dataAdapter.Fill(dt);
                con.Close();
                con.Open();
                foreach (DataRow row in dt.Rows)
                {
                    //lấy mã số pc
                   
                    string msl = row["MasoLop"].ToString();
                    DataTable dtPC = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter("select MasoPC from PhancongCV where MasoLop = '" + msl + "'", con);
                    adp.Fill(dtPC);
                    
                    //lấy mã tg làm việc
                    
                    DataTable tg = new DataTable();
                    SqlDataAdapter ad = new SqlDataAdapter("select MasoTG,MasoPhong,MasoCa,Thu from ThoiGianLamviec tg except select tkb.MasoTG, MasoPhong, MasoCa, Thu from ThoiKB tkb, ThoiGianLamviec tg where tkb.MasoTG = tg.MasoTG", con);
                    ad.Fill(tg);

                    //lấy danh sách mã tg trong tkb
                    DataTable dt_TG_TKB = new DataTable();
                    SqlDataAdapter adtg_tkb = new SqlDataAdapter("select MasoTG from ThoiKB", con);
                    adtg_tkb.Fill(dt_TG_TKB);

                    //DataTable tg = DataTgLamviec();
                    int[,] arr = new int[dtPC.Rows.Count, dt.Rows.Count];
                    List<int> a = new List<int>();
                    //dataGridView1.DataSource = dtPC;
                    int[] intarr = new int[tg.Rows.Count];
                    
                    for(int i = 0; i< tg.Rows.Count; i++)
                    {
                       
                        intarr[i] = (int)tg.Rows[i]["MasoTG"];
                    }


                    int max = int.MinValue;
                    int min = int.MaxValue;
                    foreach(DataRow dr in tg.Rows)
                    {
                        int t = dr.Field<int>("MasoTG");
                        max = Math.Max(max, t);
                        min = Math.Min(min, t);
                    }
                    //MessageBox.Show(min + "-" + max);
                    for(int i =0; i < tg.Rows.Count; i++)
                    {
                        //MessageBox.Show(intarr[i].ToString());
                    }

                    //get tkb
                    


                    Random rd = new Random();
                    List<int> num = new List<int>();
                    int number;
                    for(int i = 0; i < dtPC.Rows.Count; i++)
                    {
                        do
                        {
                            number = intarr[rd.Next(0, intarr.Length)];
                      
                        } while (num.Contains(number));
                        num.Add(number);
                       
                    }
                   
                    //thêm pc & tg vào arr
                    for (int i = 0; i < dtPC.Rows.Count; i++)
                    {

                        //int index = rd.Next(0, tg.Rows.Count);
                        arr[i, 0] = (int)dtPC.Rows[i][0];
                        arr[i, 1] = num[i];

                    }

                    
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        string pccv = arr[i, 0].ToString();
                        string tgcv = arr[i, 1].ToString();
                        

                        SqlCommand cd = new SqlCommand("insert into ThoiKB(MasoPC,MasoTG) values(@pc,@tg)", con);

                        cd.Parameters.AddWithValue("@pc", pccv);
                        cd.Parameters.AddWithValue("@tg", tgcv);
                        try
                        {
                            cd.ExecuteNonQuery();
                            tkb();
                            /*DataTable ck = checkDup();
                            if (ck.Rows.Count > 0)
                            {
                                
                                deleteTKB();
                                btnXepTKB.PerformClick();
                                MessageBox.Show(ck.Rows.Count+"");
                               
                            } */
                            

                        }
                        catch
                        {
                            //MessageBox.Show("Tạo thời khóa biểu thất bại");

                        }
                        
                    }

                }
                //Tính độ thích nghi
                DataTable ck = checkDup();
                if (ck.Rows.Count > 0)
                {

                    deleteTKB();
                    btnXepTKB.PerformClick();
                    //MessageBox.Show(ck.Rows.Count + "");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối !");
            }
            finally
            {
                //con.Close();
            }
        }
        public DataTable DataTgLamviec()
        {
            SqlConnection con = Connect.GetDBConnection();
            con.Open();
            DataTable dtTG = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("select MasoTG from ThoiGianLamviec except select MasoTG from ThoiKB", con);
            ad.Fill(dtTG);
            con.Close();
            return dtTG;
        }

        public void tkb()
        {
            DataTable dt = new DataTable();
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                
                SqlDataAdapter ap = new SqlDataAdapter("select Hoten,TenMH,TenPhong,Thu,TenCa,Tenlop,KhoaHoc from ThoiKB tkb,PhancongCV cv,ThoiGianLamviec tg, GiangVien gv, Monhoc mh,Phong p, Lop l,ca c where tkb.MasoPC = cv.MasoPC and tkb.MasoTG = tg.MasoTG and cv.MasoGV = gv.MasoGV and cv.MasoLop = l.MasoLop and cv.MasoMH = mh.MasoMH and tg.MasoCa = c.MasoCa and tg.MasoPhong = p.MasoPhong  order by Thu,TenCa ", con);
                ap.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }catch
            {
                MessageBox.Show("Lỗi!");
            }
            finally
            {
                con.Close();
            }

  
        }

        private void btndeleteLich_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from ThoiKB",con);
            try
            {
                cmd.ExecuteNonQuery();
                tkb();
                
            }
            catch
            {
                MessageBox.Show("Lỗi Xóa lịch");
            }
            
        }

        private DataTable checkDup()
        {
            SqlConnection con = Connect.GetDBConnection();
            con.Open();
            DataTable dt = new DataTable();
            SqlCommand cdm = new SqlCommand("select Hoten,Thu,TenCa from ThoiKB tkb, PhancongCV cv, ThoiGianLamviec tg, GiangVien gv, Monhoc mh, Phong p, Lop l, ca c " +
                "where tkb.MasoPC = cv.MasoPC and tkb.MasoTG = tg.MasoTG and cv.MasoGV = gv.MasoGV and cv.MasoLop = l.MasoLop and cv.MasoMH = mh.MasoMH and tg.MasoCa = c.MasoCa " +
                "and tg.MasoPhong = p.MasoPhong group by Hoten, Thu, tenca having COUNT(*) > 1",con);
            dt.Load(cdm.ExecuteReader());
            con.Close();
            return dt;
        }

        private void deleteTKB()
        {
            SqlConnection con = Connect.GetDBConnection();
            SqlCommand cmd = new SqlCommand("delete from ThoiKB");
            cmd.ExecuteNonQuery();
        }

   
        private void excel_Click(object sender, EventArgs e)
        {
            // Don't save if no data is returned
            if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            // Column headers
            string columnsHeader = "";
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                columnsHeader += dataGridView1.Columns[i].HeaderText + ",";
            }
            sb.Append(columnsHeader + Environment.NewLine);
            // Go through each cell in the datagridview
            foreach (DataGridViewRow dgvRow in dataGridView1.Rows)
            {
                // Make sure it's not an empty row.
                if (!dgvRow.IsNewRow)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        // Append the cells data followed by a comma to delimit.

                        sb.Append(dgvRow.Cells[c].Value + ",");
                    }
                    // Add a new line in the text file.
                    sb.Append(Environment.NewLine);
                }
            }
            // Load up the save file dialog with the default option as saving as a .csv file.
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            //Excel Files|*.xls;*.xlsx;*.xlsm
            //CSV files (*.csv)|*.csv
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // If they've selected a save location...
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false))
                {
                    // Write the stringbuilder text to the the file.
                    sw.WriteLine(sb.ToString());
                }
            }
            // Confirm to the user it has been completed.
            MessageBox.Show("Lưu thành công!.");
        }
    }
}
