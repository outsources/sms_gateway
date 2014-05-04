using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace Helper
{

    /// <summary>
    /// tạo lệnh thực thi vs csdl
    /// </summary>
    public class DbContext<T> where T : class
    {
        public int pageding { get; set; }
        public int id { get; set; }
        private Type type { get; set; }
        private int display { get; set; }
        private string[] unicode { get; set; }
        private StringBuilder getIdQuery { get; set; }
        private StringBuilder queryString { get; set; }
        private StringBuilder column { get; set; }
        private StringBuilder where { get; set; }
        private StringBuilder Joinin { get; set; }
        private StringBuilder orderby { get; set; }
        private StringBuilder limit { get; set; }


        public DbContext()
        {
            this.unicode = new string[]{};
            this.type = typeof(T);
        }

        public DbContext(string[] unicode)
        {
            this.unicode = unicode;
            this.type = typeof(T);
        }

        public void Select()
        {
            this.queryString = new StringBuilder();
            this.column = new StringBuilder();
            this.Joinin = new StringBuilder();
            this.orderby = new StringBuilder();
            this.limit = new StringBuilder();

            this.queryString.Append("SELECT {0} , ROW_NUMBER() OVER (ORDER BY id) AS [indexs]  FROM {1} {2} WHERE 1=1 {3}");
        }

        public void Select(string[] column)
        {
            this.queryString = new StringBuilder();
            this.column = new StringBuilder();
            this.Joinin = new StringBuilder();
            this.orderby = new StringBuilder();
            this.limit = new StringBuilder();
            foreach (var item in column)
            {
                this.column.Append(item + ",");
            }
            queryString.Append("SELECT {0} ROW_NUMBER() OVER (ORDER BY id) AS [indexs]  FROM {1} {2} WHERE 1=1 {3}");
        }

        public void Join<T>(string col_1, string col_2) where T : class
        {
            this.Joinin.Append(" INNER JOIN ");
            this.Joinin.Append(typeof(T).Name);
            this.Joinin.Append(" ON ");
            this.Joinin.Append(col_1);
            this.Joinin.Append(" = ");
            this.Joinin.Append(col_2);

        }

        public void Where(string col, string where, string value)
        {
            if (this.where == null)
                this.where = new StringBuilder();
            this.where.Append(" AND ");
            this.where.Append(col);
            this.where.Append(where);
            this.where.Append("'" + value + "'");
        }

        public void Where(string col, string value)
        {
            if (this.where == null)
                this.where = new StringBuilder();
            this.where.Append(" AND  ");
            this.where.Append(col);
            this.where.Append("='" + value + "'");
        }

        public void OrWhere(string col, string where, string value)
        {
            if (this.where == null)
                this.where = new StringBuilder();
            this.where.Append(" OR  ").Append(col)
                .Append(where).Append("'" + value + "'");
        }

        public void OrWhere(string col, string value)
        {
            if (this.where == null)
                this.where = new StringBuilder();
            this.where.Append(" OR  ").Append(col)
                      .Append("='" + value + "'");
        }

        public void Like(string col, string val, string like)
        {
            this.where.Append(" AND  ").Append(col).Append("LIKE")
                      .Append("'" + like.Replace("{0}", val) + "'");
        }

        public void OrLike(string col, string val, string like)
        {
            this.where.Append(" OR ").Append(col).Append("LIKE")
                      .Append("'" + like.Replace("{0}", val) + "'");
        }

        public void OrderBy(string col, string by)
        {
            this.orderby.Append(" OR DER BY")
                        .Append(col).Append(by);
        }

        public void OrderBy(string col)
        {
            if (col.ToLower().Equals("desc"))
                this.orderby.Append(" OR DER BY id DESC");
            else
                this.orderby.Append(" ORDER BY " + col + " ASC ");
        }

        public void OrderBy()
        {
            this.orderby.Append(" OR DER BY id");
        }

        public void take(int page)
        {
            int skip = (page - 1) * 10;
            int take = page * 10;

            if (page > 0)
                this.limit.Append("SELECT {0} FROM ( {1} ) x WHERE indexs > ")
                          .Append(skip).Append(" AND ").Append("indexs <=").Append(take);
        }

        public void take(int page, int display)
        {
            this.display = display;
            int skip = (page - 1) * display;
            int take = page * display;

            if (page > 0)
                this.limit.Append("SELECT {0} FROM ( {1} ) WHERE indexs > ")
                          .Append(skip).Append(" AND ").Append("indexs <=").Append(take);
        }

        private int totalpage(int total)
        {
            float odd = 0.0f;
            if (total > 0)
            {
                int page = (int)(total / this.display);
                odd = (total / this.display) - page;
                if (odd < 0.5)
                    return page + 1;
                else
                    return page;
            }
            else
                return 0;
        }

        /// <summary>
        /// Method FetchTable();
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable FetchTable()
        {
            string sql = "";
            if (this.column.Length == 0)
                this.queryString.Replace("{0}", "*");
            else
                this.queryString.Replace("{0}", column.ToString());

            if (this.Joinin.Length == 0)
                this.queryString.Replace("{2}", "");
            else
                this.queryString.Replace("{2}", Joinin.ToString());
            this.queryString.Replace("{1}", type.Name);
            if (this.limit.Length > 0)
            {
                if (this.column.Length == 0)
                    this.limit.Replace("{0}", "*");
                else
                    this.limit.Replace("{0}", column.ToString());
                this.queryString.Replace("{3}", where.ToString());
                sql = this.limit.Replace("{1}", queryString.ToString()).Append(orderby).ToString();
            }
            else
                if(this.where != null)
                    sql = this.queryString.Replace("{3}", where.ToString()).Append(orderby).ToString();
                else
                    sql = this.queryString.Replace("{3}"," ").Append(orderby).ToString();
            this.queryString.Clear();
            this.limit.Clear();
            this.where.Clear();
            this.orderby.Clear();
            this.Joinin.Clear();
            this.column.Clear();
            var dt = database.getData(sql);
                if(dt.Rows.Count > 0)
                    return dt;
                else
                    return new DataTable();
        }

        /// <summary>
        /// Method về kiểu Json
        /// </summary>
        /// <returns>string Json</returns>

        public string FetchJson()
        {
            var data = FetchTable();
            if (data.Rows.Count > 0)
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer =
                    new System.Web.Script.Serialization.JavaScriptSerializer();
                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row = null;
                foreach (DataRow dr in data.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in data.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }
                return serializer.Serialize(rows);
            }
            else
                return "";
        }


        /// <summary>
        /// Method List Object
        /// </summary>
        /// <returns>List<obj> dsa</returns>

        public List<T> FetchObject()
        {
            var datajson = FetchJson();
            if (datajson != "")
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer =
                new System.Web.Script.Serialization.JavaScriptSerializer();
                return serializer.Deserialize<List<T>>(datajson);
            }
            else
                return new List<T>();
        }

        public void Create(T obj)
        {
            Type type = typeof(T);
            string table = type.Name;
            this.queryString = new StringBuilder();
            this.getIdQuery = new StringBuilder();
            this.queryString.Append("INSERT " + table);
            this.getIdQuery.Append("SELECT id FROM " + table + " WHERE 1=1");            
            PropertyInfo[] properties = type.GetProperties();
            StringBuilder col = new StringBuilder();
            StringBuilder val = new StringBuilder();
            int mtdt = properties.Length;
            for (int i = 1; i < mtdt; i++)
            {
                PropertyInfo property = properties[i];
                this.getIdQuery.Append(" AND  " + property.Name);
                this.getIdQuery.Append("='" + property.GetValue(obj, null) + "'");
                col.Append(property.Name+",");
                if (this.unicode.Length > 0 && unicode.Contains(property.Name))
                   val.Append("N'").Append(property.GetValue(obj, null)).Append("',");
                else
                    val.Append("'").Append(property.GetValue(obj, null)).Append("',");

            }
            this.queryString.Append("(").Append(col.ToString().Substring(0, col.Length - 1))
                            .Append(")").Append(" VALUES(")
                            .Append(val.ToString().Substring(0, val.Length - 1))
                            .Append(")");
        }

        public void Update(T obj)
        {
            this.queryString = new StringBuilder();
            Type type = typeof(T);
            this.queryString.Append("UPDATE " + type.Name + " SET ");

            PropertyInfo[] properties = type.GetProperties();
            int mtdt = properties.Length;
            for (int i = 1; i < mtdt; i++)
            {
                PropertyInfo property = properties[i];
                if (property.GetValue(obj, null) != null && !property.Name.Equals("create_date"))
                this.queryString.Append(property.Name).Append("='")
                                .Append(property.GetValue(obj, null)).Append("',");

            }
            string s = this.queryString.ToString().Substring(0, this.queryString.Length - 1);
            this.queryString.Clear().Append(s).Append(" where 1=1 ").Append(where);
        }

        /// TAO SỬA Ở Đây.
        public void Delete()
        {
            if (this.queryString == null)
                this.queryString = new StringBuilder();
            string table = type.Name;
            this.queryString.Append("DELETE FROM ").Append(table)
                            .Append(" WHERE 1 = 1 ").Append(this.where);

        }

        public string getColumnValue(string table,string col,Dictionary<string,string> obj )
        {

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ").Append(col).Append(" from ").Append(table).Append(" where ");
            foreach (var item in obj)
            {
                sql.Append(item.Key).Append(" = '").Append(item.Value).Append("' and ");
            }

            string query = sql.ToString().Substring(0, sql.Length - 4);
            var dt = database.getData(query);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][col].ToString();
            else
                return "";

        }

        public string test()
        {
            return this.queryString.ToString();
        }

        public bool Save()
        {
            int i = database.ExecuteQuery(this.queryString.ToString());
            queryString.Clear();
            if (i > 0)
            {
                if (getIdQuery != null)
                {
                    this.id = int.Parse(database.getData(getIdQuery.ToString()).Rows[0]["id"].ToString());
                    getIdQuery.Clear();
                }
                return true;
            }
            else
                return false;
        }

    }
}
