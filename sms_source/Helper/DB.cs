using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class DB
    {
        /// <summary>
        /// total page
        /// </summary>
        public static int page { get; set; }

        /// <summary>
        /// Khởi tạo lệnh select
        /// </summary>
        /// <returns>string</returns>
        public static string Select<T>(this T obj) where T : class
        {
            return "SELECT * FROM " + typeof(T).Name;
        }

        /// <summary>
        /// Khởi tạo lệnh select
        /// </summary>
        /// <typeparam name="T">đối tượng cần select</typeparam>
        /// <param name="column">cột cần lấy</param>
        /// <param name="obj">cột cần lấy</param>
        /// <returns>string</returns>

        public static string Select<T>(this T obj, string[] column) where T : class
        {
            StringBuilder str = new StringBuilder();
            foreach (var item in column)
            {
                str.Append(item + ",");
            }
            return "SELECT " + str.ToString().Substring(0, str.Length - 1) + " FROM " + typeof(T).Name;
        }

        /// <summary>
        /// Inner join các bảng
        /// </summary>
        /// <param name="col_1"></param>
        /// <param name="col_2"></param>
        /// <returns></returns>
        public static string Join<T>(this string sql, string col_1, string col_2)
        {
            if (sql == "" && !sql.Contains("SELECT"))
                return "";
            else
            {
                string table = typeof(T).Name;
                return sql + " INNER JOIN " + table + " ON " + table + "." + col_1 + " = " + table + "." + col_2;
            }
        }

        /// <summary>
        /// Điều kiện câu lệnh
        /// mệnh đề mặc định là  '='
        /// </summary>
        /// <param name="column">cột</param>
        /// <param name="param">giá trị</param>
        /// <returns>string</returns>
        public static string Where(this string sql, string column, string param)
        {
            if (sql == "" && !sql.Contains("SELECT"))
                return "";
            if (sql.Contains("WHERE"))
                sql = sql + " AND ";
            else
                sql = sql + " WHERE ";
            return sql + column + "='" + param.Replace("union", " ") + "'";
        }

        /// <summary>
        /// Điều kiện câu lệnh
        /// </summary>
        /// <param name="column">cột</param>
        /// <param name="where">Điều kiên</param>
        /// <param name="param">giá trị</param>
        /// <returns>string</returns>>
        public static string Where(this string sql, string column, string where, string param)
        {
            if (sql == "" && !sql.Contains("SELECT"))
                return "";
            if (sql.Contains("WHERE"))
                sql = sql + " AND ";
            else
                sql = sql + " WHERE ";
            return sql + column + where + "'" + param.Replace("union", " ") + "'";
        }

        /// <summary>
        /// Điều kiện câu lệnh
        /// mệnh đề mặc định là  '='
        /// </summary>
        /// <param name="column">cột</param>
        /// <param name="param">giá trị</param>
        /// <returns>string</returns>
        public static string OrWhere(this string sql, string column, string param)
        {
            if (sql == "" && !sql.Contains("SELECT"))
                return "";
            if (sql.Contains("WHERE"))
                sql = sql + " OR ";
            else
                sql = sql + " WHERE ";
            return sql + column + "='" + param.Replace("union", " ") + "'";
        }

        /// <summary>
        /// Điều kiện câu lệnh
        /// </summary>
        /// <param name="column">cột</param>
        /// <param name="where">Điều kiên</param>
        /// <param name="param">giá trị</param>
        /// <returns>string</returns>>
        public static string OrWhere(this string sql, string column, string where, string param)
        {
            if (sql == "" && !sql.Contains("SELECT"))
                return "";
            if (sql.Contains("WHERE"))
                sql = sql + " OR ";
            else
                sql = sql + " WHERE ";
            return sql + column + where + "'" + param.Replace("union", " ") + "'";
        }

        public static string Like(this string sql, string col, string val, string like)
        {
            if (sql.Contains("WHERE"))
                sql += " AND ";
            else
                sql += " WHERE ";
            return sql + "  " + col + " LIKE '" + like.Replace("{0}", val) + "'";
        }

        public static string OrLike(this string sql, string col, string val, string like)
        {
            if (sql.Contains("WHERE"))
                sql += " OR ";
            else
                sql += " WHERE ";
            return sql + "  " + col + " LIKE '" + like.Replace("{0}", val) + "'";
        }

        public static string OrderBy(this string sql, string col, string by)
        {
            return sql + " ORDER BY " + col + " " + by;
        }

        public static string OrderBy(this string sql, string col)
        {
            if (col.ToLower().Equals("desc"))
                return sql + " ORDER BY id DESC ";
            else
                return sql + " ORDER BY " + col + " ASC ";

        }

        public static string OrderBy(this string sql)
        {
            return sql + " ORDER BY id";
        }

        //public static List<T> Get(this string sql) {


        //    return T;
        //}



    }

}
