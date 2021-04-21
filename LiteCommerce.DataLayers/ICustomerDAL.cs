using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến khách hàng
    /// </summary>
    public interface ICustomerDAL
    {
        /// <summary>
        /// Bổ sung một nhà cung cấp mới. Hàm trả về mã của khách hàng 
        /// Nếu bổ sung thàng công
        /// </summary>
        /// <param name="data">Đối tượng lưu thông tin của khách hàng cần bổ sung </param>
        /// <returns></returns>
        int Add(Customer data);
        /// <summary>
        /// Lấy dnah sách các khách hàng(tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page">trang cần lấy dữ liệu</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang</param>
        /// <param name="searchValue">Giá trị cần tìm kiếm theo CustomerName, ContactName, Address, Email (chuỗi rỗng nếu không tìm thấy)</param>
        /// <returns></returns>
        List<Customer> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// Đếm số lượng nhà cung cấp thỏa điều kiện tìm kiếm 
        /// </summary>
        /// <param name="searchValue">Giá trị cần tìm (chuỗi rỗng nếu không tìm thấy)</param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy thông tin của một nhà cung cấp theo mã. Trong trường hợp khách hàng 
        /// không tồn tại, hàng trả về giá trị null
        /// </summary>
        /// <param name="customerID">mã của khách hàng cần lấy thông tin</param>
        /// <returns></returns>
        Customer Get(int customerID);
        /// <summary>
        /// cập nhật thông tin của một khách hàng. Hàm trả về giá trị boolean cho 
        /// biết việc cập nhật có thành công hay không
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Customer data);
        /// <summary>
        /// Xóa một khách hàng dựa vào mã. hàm trả về giá trị bool cho biết việc xóa 
        /// có thực hiện hay không (Lưu ý : không được xóa nhà cung cấp nếu đang có 
        /// mặt hàng tham chiếu đến nhà cung câos
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        bool Delete(int customerID);
    }
}
