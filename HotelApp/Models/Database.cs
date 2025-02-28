using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models
{
    public class Database
    {
        private SqlConnection sql = new SqlConnection(@"Data Source=510EC3;Initial Catalog=Rooms_db;Integrated Security=True;Trust Server Certificate=True"
            );

        public void OpenConnection()
        {
            if (sql.State == System.Data.ConnectionState.Closed)
            {
                sql.Open();
            }
        }
        public void CloseConnection()
        {
            if (sql.State == System.Data.ConnectionState.Open)
            {
                sql.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sql;
        }
    }
}
