using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến nhà cung cấp
    /// </summary>
    public interface ISupplierDAL
    {
        /// <summary>
        /// Bổ sung một nhà cung cấp mới. Hàm trả về mã của nhà cung cấp 
        /// Nếu bổ sung thàng công
        /// </summary>
        /// <param name="data">Đối tượng lưu thông tin của nhà cung cấp cần bổ sung </param>
        /// <returns></returns>
        int Add(Supplier data);
        /// <summary>
        /// Lấy dnah sách các nhàn cung cấp (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page">trang cần lấy dữ liệu</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang</param>
        /// <param name="searchValue">Giá trị cần tìm kiếm theo SupplierName, ContactName, Address, Phone (chuỗi rỗng nếu không tìm thấy)</param>
        /// <returns></returns>
        List<Supplier> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// Đếm số lượng nhà cung cấp thỏa điều kiện tìm kiếm 
        /// </summary>
        /// <param name="searchValue">Giá trị cần tìm (chuỗi rỗng nếu không tìm thấy)</param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy thông tin của một nhà cung cấp theo mã. Trong trường hợp nhà cung cấp 
        /// không tồn tại, hàng trả về giá trih null
        /// </summary>
        /// <param name="supplierID">mã của nhà cung cấp cần lấy thông tin</param>
        /// <returns></returns>
        Supplier Get(int supplierID);
        /// <summary>
        /// cập nhật thông tin của một nhà cung cấp. Hàm trả về giá trị boolean cho 
        /// biết việc cập nhật có thành công hay không
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Supplier data);
        /// <summary>
        /// Xóa một nhà cung cấp dựa vào mã. hàm trả về giá trị bool cho biết việc xóa 
        /// có thực hiện hay không (Lưu ý : không được xóa nhà cung cấp nếu đang có 
        /// mặt hàng tham chiếu đến nhà cung câos
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        bool Delete(int supplierID);
    }
}