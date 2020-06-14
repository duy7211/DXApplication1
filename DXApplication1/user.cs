using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DXApplication1
{
    class user
    {
        SqlCommand cmd;
        public string GetID(string username,string password)
        {
            string id = "";
            SqlConnection con = Connect.GetDBConnection();
          
            
            try
            {
                con.Open();
                //SqlConnection Conn = con.con;
                cmd = new SqlCommand("select * from taikhoan where username='" + username + "' and password='" + password + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        id = dr["idtk"].ToString();
                    }
                }
                
            }
            catch(Exception)
            {
                MessageBox.Show("Truy vấn dữ liệu hoặc kết nối server thất bại !");
                
            }
            finally
            {
                con.Close();
            } 
            return id;
        } 
        public Boolean UpdatePw(string pw)
        {
            SqlConnection con = Connect.GetDBConnection();

            Boolean b = false;
            //data = "ID: " + Session.Id + " pw: " + pw;
            con.Open();
            
            cmd = new SqlCommand("update taikhoan set password=@pw where idtk=@id", con);
            cmd.Parameters.AddWithValue("@id", Session.Id);
            cmd.Parameters.AddWithValue("@pw", pw);
            try
            {
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Thất bại!");
                b = false;
            }
            finally
            {
                con.Close();
            }
           
            return b;
            
        }
    }
}
