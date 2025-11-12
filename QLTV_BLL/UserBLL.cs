using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using QLTV_DAL; 
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QLTV_BLL
{
    /// <summary>
    /// Business Logic Layer cho User
    /// </summary>
    public class UserBLL
    {
        private UserDAO userDAO = new UserDAO();

        /// <summary>
        /// Xử lý đăng nhập - Kiểm tra validation và gọi DAL
        /// </summary>
        /// <param name="username">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>DataRow chứa thông tin user nếu đăng nhập thành công, null nếu thất bại</returns>
        public DataRow Login(string username, string password)
        {
            try
            {
                // BƯỚC 1: Validation đầu vào
                if (string.IsNullOrWhiteSpace(username))
                {
                    throw new Exception("Tên đăng nhập không được để trống!");
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    throw new Exception("Mật khẩu không được để trống!");
                }

                // Kiểm tra độ dài username
                if (username.Length < 3 || username.Length > 50)
                {
                    throw new Exception("Tên đăng nhập phải từ 3-50 ký tự!");
                }

                // Kiểm tra độ dài password
                if (password.Length < 6)
                {
                    throw new Exception("Mật khẩu phải có ít nhất 6 ký tự!");
                }

                // BƯỚC 2: Trim khoảng trắng thừa
                username = username.Trim();
                password = password.Trim();

                // BƯỚC 3: Gọi DAL để xác thực
                // NOTE: Nếu muốn mã hóa password (khuyến nghị), thêm dòng này:
                // password = HashPassword(password); // MD5/SHA256

                DataRow userInfo = userDAO.ValidateUser(username, password);

                // BƯỚC 4: Kiểm tra kết quả
                if (userInfo == null)
                {
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");
                }

                // BƯỚC 5: Kiểm tra trạng thái tài khoản
                if (userInfo["IsActive"] != DBNull.Value && !(bool)userInfo["IsActive"])
                {
                    throw new Exception("Tài khoản đã bị khóa. Vui lòng liên hệ Admin!");
                }

                return userInfo;
            }
            catch (Exception ex)
            {
                // Log lỗi (có thể ghi vào file log)
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Đổi mật khẩu - Validation và xử lý business logic
        /// </summary>
        /// <param name="userId">ID của user</param>
        /// <param name="oldPassword">Mật khẩu cũ</param>
        /// <param name="newPassword">Mật khẩu mới</param>
        /// <returns>True nếu đổi thành công</returns>
        public bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
                {
                    throw new Exception("Mật khẩu không được để trống!");
                }

                if (newPassword.Length < 6)
                {
                    throw new Exception("Mật khẩu mới phải có ít nhất 6 ký tự!");
                }

                if (oldPassword == newPassword)
                {
                    throw new Exception("Mật khẩu mới phải khác mật khẩu cũ!");
                }

                // Kiểm tra độ mạnh password (tùy chọn)
                if (!IsStrongPassword(newPassword))
                {
                    throw new Exception("Mật khẩu phải chứa ít nhất 1 chữ hoa, 1 chữ thường và 1 số!");
                }

                // Gọi DAO để đổi password
                // NOTE: Nếu có mã hóa, hash newPassword trước khi gọi
                bool result = userDAO.ChangePassword(userId, newPassword);

                if (!result)
                {
                    throw new Exception("Đổi mật khẩu thất bại!");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lấy danh sách users (chỉ Admin được phép)
        /// </summary>
        /// <param name="currentUserRole">Role của user hiện tại</param>
        /// <returns>DataTable chứa danh sách users</returns>
        public DataTable GetAllUsers(string currentUserRole)
        {
            try
            {
                // Kiểm tra quyền
                if (currentUserRole != "Admin")
                {
                    throw new Exception("Bạn không có quyền xem danh sách users!");
                }

                return userDAO.GetAllUsers();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Kiểm tra độ mạnh của password
        /// </summary>
        /// <param name="password">Mật khẩu cần kiểm tra</param>
        /// <returns>True nếu password đủ mạnh</returns>
        private bool IsStrongPassword(string password)
        {
            // Kiểm tra: ít nhất 1 chữ hoa, 1 chữ thường, 1 số
            bool hasUpper = Regex.IsMatch(password, @"[A-Z]");
            bool hasLower = Regex.IsMatch(password, @"[a-z]");
            bool hasDigit = Regex.IsMatch(password, @"[0-9]");

            return hasUpper && hasLower && hasDigit;
        }

        // NOTE: Nếu muốn mã hóa password, thêm method này
        /*
        private string HashPassword(string password)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        */
    }
}