using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV_DAL
{
    public class DatabaseConnection
    {
        private static string connectionString =
        ConfigurationManager.ConnectionStrings["QLTV_DB"].ConnectionString;
        /// <summary>
        /// Lấy connection đến SQL Server
        /// </summary>

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        /// <summary>
        /// Test kết nối database
        /// </summary>
       
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Lấy thông tin chi tiết về kết nối (để debug)
        /// </summary>
        public static string GetConnectionInfo()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return $"Connected to: {conn.Database} on {conn.DataSource}";
                }
            }
            catch (Exception ex)
            {
                return $"Connection failed: {ex.Message}";
            }
        }
    }
}