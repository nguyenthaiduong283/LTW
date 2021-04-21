using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;
namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến nhân viên
    /// </summary>
    public interface IEmployeeDAL
    {
        /// <summary>
        /// Bổ sung một nhà cung cấp mới. Hàm trả về mã của nhân viên
        /// Nếu bổ sung thàng công
        /// </summary>
        /// <param name="data">Đối tượng lưu thông tin của nhân viên cần bổ sung </param>
        /// <returns></returns>
        int Add(Employee data);
        /// <summary>
        /// Lấy dnah sách các nhân viên (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page">trang cần lấy dữ liệu</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang</param>
        /// <param name="searchValue">Giá trị cần tìm kiếm theo LastName, FirstName, Email (chuỗi rỗng nếu không tìm thấy)</param>
        /// <returns></returns>
        List<Employee> List();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        List<Employee> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// Đếm số lượng nhân viên thỏa điều kiện tìm kiếm 
        /// </summary>
        /// <param name="searchValue">Giá trị cần tìm (chuỗi rỗng nếu không tìm thấy)</param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy thông tin của một nhân viên theo mã. Trong trường hợp nhân viên 
        /// không tồn tại, hàng trả về giá trị null
        /// </summary>
        /// <param name="employeeID">mã của nhân viên cần lấy thông tin</param>
        /// <returns></returns>
        Employee Get(int employeeID);
        /// <summary>
        /// cập nhật thông tin của một nhân viên. Hàm trả về giá trị boolean cho 
        /// biết việc cập nhật có thành công hay không
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Employee data);
        /// <summary>
        /// Xóa một nhân viên dựa vào mã. hàm trả về giá trị bool cho biết việc xóa 
        /// có thực hiện hay không (Lưu ý : không được xóa nhân viên nếu đang có 
        /// mặt hàng tham chiếu đến nhân viên
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        bool Delete(int employeeID);
    }
}
