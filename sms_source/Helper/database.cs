using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    /// <summary>
    /// lớp tương tác vs csdl
    /// </summary>
    public class database
    {
        /// <summary>
        /// kết nối với sql
        /// </summary>
        public static DbConnection SqlConnection { get; set; }

        /// <summary>
        /// Thực hiện select dữ liệu từ database 
        /// <param name="sql">Câu lệnh sql</param>
        /// <returns>Datatable</returns>
        /// </summary>
        public static DataTable getData(string sql)
        {
            var con = database.SqlConnection.getConnection();
            DataSet ds = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter adt = new SqlDataAdapter(sql, con);
                adt.Fill(ds);
                con.Close();
                return ds.Tables[0];
            }
            catch (Exception)
            {
                con.Close();
                return new DataTable();
            }
            
        }
        /// <summary>
        /// Thực hiện IUD dữ liệu từ database 
        /// <param name="sql">Câu lệnh sql</param>
        /// <returns>int</returns>
        /// </summary>
        public static int ExecuteQuery(string sql)
        {
            var con = database.SqlConnection.getConnection();
            int test = 0;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);                
                test = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return 0;
            }

            return test;
        }
    }
}
