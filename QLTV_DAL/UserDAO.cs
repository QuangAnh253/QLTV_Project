using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV_DAL
{
    /// <summary>
    /// Data Access Object cho bảng Users (Admin/Staff)
    /// </summary>
    public class UserDAO
    {
        /// <summary>
        /// Xác thực thông tin đăng nhập của user
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>DataRow chứa thông tin user nếu hợp lệ, null nếu không tìm thấy</returns>
        public DataRow ValidateUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    // Câu lệnh SQL với tham số hóa để chống SQL Injection
                    string query = @"SELECT UserID, Username, FullName, Role, IsActive 
                                   FROM Users 
                                   WHERE Username = @Username 
                                   AND Password = @Password 
                                   AND IsActive = 1";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số - QUAN TRỌNG: Chống SQL Injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Thực thi và lấy kết quả
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Trả về dòng đầu tiên nếu tìm thấy, null nếu không
                            if (dt.Rows.Count > 0)
                            {
                                return dt.Rows[0];
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log lỗi database
                throw new Exception("Lỗi kết nối database: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Log lỗi chung
                throw new Exception("Lỗi xác thực user: " + ex.Message);
            }
        }

        /// <summary>
        /// Đổi mật khẩu cho user
        /// </summary>
        /// <param name="userId">ID của user</param>
        /// <param name="newPassword">Mật khẩu mới</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool ChangePassword(int userId, string newPassword)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"UPDATE Users 
                                   SET Password = @NewPassword 
                                   WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đổi mật khẩu: " + ex.Message);
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả users (dành cho Admin)
        /// </summary>
        /// <returns>DataTable chứa danh sách users</returns>
        public DataTable GetAllUsers()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"SELECT UserID, Username, FullName, Role, 
                                   CreatedDate, IsActive 
                                   FROM Users 
                                   ORDER BY CreatedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách users: " + ex.Message);
            }
        }
    }
}