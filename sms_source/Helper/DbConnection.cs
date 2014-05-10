using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    /// <summary>
    /// Lớp kết nối
    /// </summary>
    public class DbConnection
    {

        private string server { get; set; }
        private string database { get; set; }
        private string username { get; set; }
        private string password { get; set; }

        /// <summary>
        /// Khởi tạo giá trị mặc định
        /// <param name="server">Tên máy chủ</param>
        /// <param name="database">Tên database</param>
        /// <param name="username">Tài khoản đăng nhập máy chủ</param>
        /// <param name="password">Mật khẩu đăng nhập máy chủ</param>
        /// </summary>
        /// <returns value="Return">Trả về chuỗi kết nối </returns>
        public DbConnection(string server, string database, string username, string password)
        {
            this.server = server;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Khởi tạo giá trị mặc định với quyền cao nhât
        /// <param name="server">Tên máy chủ</param>
        /// <param name="database">Tên database</param>
        /// </summary>
        /// <returns value="Return">Trả về chuỗi kết nối </returns>

        public DbConnection(string server, string database)
        {
            this.server = server;
            this.database = database;
            getConnection();
        }

        /// <summary>
        /// Khởi tạo chuỗi kết nối tới cơ sở dữ liệu
        /// </summary>
        /// <returns value="Return">Trả về chuỗi kết nối </returns>

        public SqlConnection getConnection()
        {
            SqlConnection sql = new SqlConnection();
            if(username == null && password == null)
                sql.ConnectionString = @"server=" + server + ";dataBase=" + database + ";integrated security=true";
            else
                sql.ConnectionString = @"server=" + server + ";dataBase=" + database + ";uid="+username+";pwd="+password;
            try
            {
                //sql.Open();
                return sql;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            
        }

    }
}
