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
        public int max = 0;
        public int min = 0;
        public FrXepTKB()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }
        public int findmax(DataTable dt)
        {
            int max = 0;
           foreach(DataRow r in dt.Rows)
            {
                int tg = r.Field<int>("MasoTG");
                max = Math.Max(max, tg);
            }

            return max;
        }
        public int findmin(DataTable dt)
        {
            int min = 0;
            foreach(DataRow r in dt.Rows)
            {
                int tg = r.Field<int>("MasoTG");
                min = Math.Max(min, tg);
            }

            return min;
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


                foreach (DataRow row in dt.Rows)
                {
                    //lấy mã số pc
                    string msl = row["MasoLop"].ToString();
                    DataTable dtPC = new DataTable();
                    SqlDataAdapter adp = new SqlDataAdapter("select MasoPC from PhancongCV where MasoLop = '" + msl + "'", con);
                    adp.Fill(dtPC);
                    //lấy mã tg làm việc
                    DataTable tg = DataTgLamviec();
                    int[,] arr = new int[dtPC.Rows.Count, dt.Rows.Count];
                    int[] a = new int[tg.Rows.Count];
                    dataGridView1.DataSource = dtPC;
                    /*
                    for (int i = 0; i < tg.Rows.Count; i++)
                    {
                        max = (int)tg.Rows[i][0];
                        if (int.Parse(tg.Rows[i][0].ToString()) < int.Parse(tg.Rows[i + 1][0].ToString()))
                        {
                            max = int.Parse(tg.Rows[++i][0].ToString());
                        }

                    }
                    for (int i = 0; i < tg.Rows.Count; i++)
                    {
                        min = (int)tg.Rows[i][0];
                        if (int.Parse(tg.Rows[i][0].ToString()) > int.Parse(tg.Rows[i + 1][0].ToString()))
                        {
                            min = int.Parse(tg.Rows[++i][0].ToString());
                        }

                    }*/
                    max = int.MinValue;
                    min = int.MaxValue;
                    foreach(DataRow dr in tg.Rows)
                    {
                        int t = dr.Field<int>("MasoTG");
                        max = Math.Max(max, t);
                        min = Math.Min(min, t);
                    }
                    //MessageBox.Show(min + "-" + max);
                    Random rd = new Random();
                    List<int> num = new List<int>();
                    for (int i = 0; i < dtPC.Rows.Count; i++)
                    {
                        int index = rd.Next(min, max);
                        if (num.Contains(index))
                        {
                            i--;
                            continue;
                        }
                        num.Add(index);

                    }

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
                            MessageBox.Show("Tạo thời khóa biểu thành công");
                        }
                        catch
                        {
                            MessageBox.Show("Tạo thời khóa biểu thất bại");

                        }
                    }

                    //cmdo.Parameters.AddWithValue("@tg", tgcv);
                    //MessageBox.Show(arr[i, 0].ToString() + " - " + arr[i, 1].ToString());

                    //} */
                    /* for(int i = 0; i< dtPC.Rows.Count; i++)
                      {
                          MessageBox.Show(dtPC.Rows[i][0].ToString());
                      }
                         */
                    /*int test = 0;
                    for(int i = 0; i< tg.Rows.Count; i++)
                    {
                        test = (int)tg.Rows[i][0];
                        if(int.Parse(tg.Rows[i][0].ToString()) < int.Parse(tg.Rows[i+1][0].ToString()))
                        {
                            test = int.Parse(tg.Rows[++i][0].ToString());
                        }
                        
                    }
                    MessageBox.Show(test.ToString());
                    //MessageBox.Show(msl);
                } //end foreach  */
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
            DataTable dtTG = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter("select MasoTG from ThoiGianLamviec", con);
            ad.Fill(dtTG);

            return dtTG;
        }
    }
}
