using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace sms_source.Areas.admin.Models
{
    public class Bussiness_Statistics
    {
        SqlConnection con = new SqlConnection(@"Data Source=NGUYENTRUONG-PC\SQLEXPRESS;Initial Catalog=sms_gateway;Integrated Security=true;Trusted_Connection=True");

        public DataTable SearchMOMT(DateTime from, DateTime to, int telID, int serviceID)
        {
            con.Open();
            var cmd = new SqlCommand("PhanTichDateTime", con) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = to;
            cmd.Parameters.Add("@telcos_id", SqlDbType.Int).Value = telID;
            cmd.Parameters.Add("@service_id", SqlDbType.Int).Value = serviceID;
            var dt = new DataTable();
            dt.Columns.Add("telcos_id", typeof(int));
            dt.Columns.Add("service_number_id", typeof(int));
            dt.Columns.Add("total_mt", typeof(int));
            dt.Columns.Add("total_mo", typeof(int));
            dt.Columns.Add("total_cdr", typeof(int));


            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var dr = dt.NewRow();

                dr["telcos_id"] = row["telcos_id"].ToString();
                dr["service_number_id"] = row["service_number_id"].ToString();
                dr["total_mt"] = row["total_mt"].ToString();
                dr["total_mo"] = row["total_mo"].ToString();
                dr["total_cdr"] = row["total_cdr"].ToString();

                dt.Rows.Add(dr);
            }
            con.Close();

            return dt;
        }

        public DataTable getOverView(DateTime from, DateTime to)
        {

            con.Open();
            var cmd = new SqlCommand("getOverView", con) { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add("@fromDate", SqlDbType.DateTime).Value = from;
            cmd.Parameters.Add("@toDate", SqlDbType.DateTime).Value = to;
            var dt = new DataTable();

            dt.Columns.Add("telcos_id", typeof(int));
            dt.Columns.Add("total_mt", typeof(int));
            dt.Columns.Add("total_mo", typeof(int));
            dt.Columns.Add("total_cdr", typeof(int));

            var da = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var dr = dt.NewRow();


                dr["telcos_id"] = row["telcos_id"].ToString();

                dr["total_mt"] = row["total_mt"].ToString();
                dr["total_mo"] = row["total_mo"].ToString();
                dr["total_cdr"] = row["total_cdr"].ToString();

                dt.Rows.Add(dr);
            }
            con.Close();

            return dt;
        }

        public int PhanTichTyLeGia(string service)
        {
            var i = 1;
            switch (service)
            {
                case "0":
                    i = 1;
                    break;
                case "1":
                    i = 1;
                    break;
                case "2":
                    i = 1;
                    break;
                case "3":
                    i = 3;
                    break;
                case "4":
                    i = 3;
                    break;
                case "5":
                    i = 5;
                    break;
                case "6":
                    i = 5;
                    break;
                case "7":
                    i = 5;
                    break;
            }
            return i;
        }


    }
}