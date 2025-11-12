using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using QLTV_DAL; 
using System.Text;
using System.Threading.Tasks;

namespace QLTV_BLL

{

    /// <summary>

    /// Business Logic Layer cho Mượn/Trả sách

    /// </summary>

    public class BorrowBLL

    {

        private BorrowDAO borrowDAO = new BorrowDAO();

        private BookDAO bookDAO = new BookDAO();



        // TODO: Thêm logic nghiệp vụ mượn/trả

        // PLACEHOLDER - Các method cần có:

        // public bool BorrowBook(int memberId, int bookId)

        // {

        // // Kiểm tra sách còn không

        // // Kiểm tra độc giả có quá hạn không

        // // Cập nhật số lượng sách available

        // }

        // public bool ReturnBook(int borrowId)

        // {

        // // Cập nhật return date

        // // Tăng số lượng sách available

        // // Tính phí phạt nếu trễ hạn

        // }

        // public DataTable GetOverdueBooks() { }

    }

}