using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1
{
    class Giangvien
    {
        SqlConnection con = Connect.GetDBConnection();
        public void GetAllGV()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from GiangVien", con);
                dataAdapter.Fill(dt);
                
            }catch (Exception)
            {

            }
        }
    }
}
