using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                    SqlDataAdapter ad = new SqlDataAdapter("select MasoTG from ThoiGianLamviec except select MasoTG from ThoiKB", con);
                    ad.Fill(tg);

                    //lấy danh sách mã tg trong tkb
                    DataTable dt_TG_TKB = new DataTable();
                    SqlDataAdapter adtg_tkb = new SqlDataAdapter("select MasoTG from ThoiKB", con);
                    adtg_tkb.Fill(dt_TG_TKB);

                    //DataTable tg = DataTgLamviec();
                    int[,] arr = new int[dtPC.Rows.Count, dt.Rows.Count];
                    List<int> a = new List<int>();
                    dataGridView1.DataSource = dtPC;
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


                    Random rd = new Random();
                    List<int> num = new List<int>();
                    int number;
                    for(int i = 0; i < dtPC.Rows.Count; i++)
                    {
                        do
                        {
                            number = intarr[rd.Next(0, intarr.Length)];
                            //intarr[}
                            /*foreach(DataRow t in dt_TG_TKB.Rows)
                            {
                                if(number == (int)t["MasoTG"])
                                {
                                    ++number;
                                } */

                        } while (num.Contains(number));
                        num.Add(number);
                       
                    }
                    //MessageBox.Show(min + "-" + max);
                    //MessageBox.Show(dtPC.Rows.Count + " - " + tg.Rows.Count);
                    /*
                    for (int i = 0; i < dtPC.Rows.Count; i++)
                    {
                        int index = rd.Next(min, max);
                        if (num.Contains(index))
                        {
                            i--;
                            continue;
                        }
                        num.Add(index);
                        MessageBox.Show(index.ToString());
                    }*/

                    //thêm pc & tg vào arr
                    for (int i = 0; i < dtPC.Rows.Count; i++)
                    {

                        int index = rd.Next(0, tg.Rows.Count);
                        arr[i, 0] = (int)dtPC.Rows[i][0];
                        arr[i, 1] = num[i];

                    }

                    
                    for (int i = 0; i < arr.GetLength(0); i++)
                    {
                        string pccv = arr[i, 0].ToString();
                        string tgcv = arr[i, 1].ToString();
                        //MessageBox.Show(arr[i, 0].ToString() + " - " + arr[i, 1].ToString());
                        SqlCommand cd = new SqlCommand("insert into ThoiKB(MasoPC,MasoTG) values(@pc,@tg)", con);

                        cd.Parameters.AddWithValue("@pc", pccv);
                        cd.Parameters.AddWithValue("@tg", tgcv);
                        try
                        {
                            cd.ExecuteNonQuery();
                            //MessageBox.Show("Tạo thời khóa biểu thành công");
                        }
                        catch
                        {
                            //MessageBox.Show("Tạo thời khóa biểu thất bại");

                        }
                    }

                }
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
    }
}
