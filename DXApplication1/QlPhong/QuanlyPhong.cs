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

namespace DXApplication1.QlPhong
{
    public partial class QuanlyPhong : Form
    {
        public QuanlyPhong()
        {
            InitializeComponent();
            GetAllPhong();
        }
        private void clear()
        {
            tbtenPhong.Text = "";
            tbMaphong.Text = "";

            btnThem.Enabled = true;
        }
        public string createID()
        {
            string Id = "";
            SqlConnection con = Connect.GetDBConnection();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select MAX(SUBSTRING(MasoPhong,3,4)) from Phong", con);
            dataAdapter.Fill(dt);


            if (dt.Rows[0][0].ToString() == "")
            {
                Id = "PH0001";
            }
            else
            {
                string d = dt.Rows[0][0].ToString();
                int so = int.Parse(d);
                so += 1;
                if (so < 10)
                {
                    Id = "PH000" + so;
                }
                else if (so < 100)
                {
                    Id = "PH00" + so;
                }
                else
                {
                    Id = "PH" + so;
                }
            }
            return Id;
        }
        public void GetAllPhong()
        {
            SqlConnection con = Connect.GetDBConnection();
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Phong", con);
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
            if (tbtenPhong.Text != "")
            {
                con.Open();
                string id = createID();

                SqlCommand cmd = new SqlCommand("insert into Phong(MasoPhong,TenPhong) values(@ms,@tp)", con);
                cmd.Parameters.AddWithValue("@ms", id);
                cmd.Parameters.AddWithValue("@tp", tbtenPhong.Text);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành Công !" /*+ masoP.ToString()*/);
                    clear();


                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();
                    GetAllPhong();
                }
                try
                {
                    con.Open();

                    for (int i = 2; i <= 7; i++)
                    {
                        for (int j = 1; j <= 4; j++)
                        {
                            SqlCommand command = new SqlCommand("insert into ThoiGianLamviec(MasoPhong,MasoCa,Thu) values(@ms,@mc,@thu)", con);
                            command.Parameters.AddWithValue("@ms", id);
                            command.Parameters.AddWithValue("@mc", j);
                            command.Parameters.AddWithValue("@thu", i);
                            command.ExecuteNonQuery();
                        }
                    }
                    //MessageBox.Show("Thêm thời gian lamfv việc thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể thêm vào thời gian làm việc!");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Không được bỏ trống ô dữ liệu!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbtenPhong.Text != "")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from ThoiGianLamviec where MasoPhong=@id", con);
                cmd.Parameters.AddWithValue("@id", tbMaphong.Text);

                try
                {
                    cmd.ExecuteNonQuery();



                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();

                }
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("delete from Phong where MasoPhong=@p", con);
                    command.Parameters.AddWithValue("@p", tbMaphong.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa phòng thành công!");
                    clear();
                }
                catch
                {
                    MessageBox.Show("Không thể xóa Phòng!");
                }
                finally
                {
                    con.Close();
                    GetAllPhong();
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
                    tbMaphong.Text = row.Cells[0].Value.ToString();
                    tbtenPhong.Text = row.Cells[1].Value.ToString();


                }
            }
            btnThem.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = Connect.GetDBConnection();
            if (tbtenPhong.Text != "")
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("update Phong set TenPhong=@tp where MasoPhong=@mp", con);
                cmd.Parameters.AddWithValue("@tp", tbtenPhong.Text);
                cmd.Parameters.AddWithValue("@mp", tbMaphong.Text);
                try
                {

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành Công !" /*+ masoP.ToString()*/);
                    clear();


                }
                catch (Exception)
                {
                    MessageBox.Show("Lỗi!");
                }
                finally
                {
                    con.Close();
                    GetAllPhong();
                }
            }
        }
    }
}