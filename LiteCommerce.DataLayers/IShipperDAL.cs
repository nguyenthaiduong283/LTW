using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteCommerce.DomainModels;

namespace LiteCommerce.DataLayers
{
    /// <summary>
    /// Định nghĩa các phép xử lý dữ liệu liên quan đến nhà vận chuyển
    /// </summary>
    public interface IShipperDAL
    {
        /// <summary>
        /// Bổ sung một nhà cung cấp mới. Hàm trả về mã của nhà vận chuyển 
        /// Nếu bổ sung thàng công
        /// </summary>
        /// <param name="data">Đối tượng lưu thông tin của nhà vận chuyển cần bổ sung </param>
        /// <returns></returns>
        int Add(Shipper data);
        /// <summary>
        /// Lấy dnah sách các nhàn vận chuyển (tìm kiếm, phân trang)
        /// </summary>
        /// <param name="page">trang cần lấy dữ liệu</param>
        /// <param name="pageSize">Số dòng hiển thị trên mỗi trang</param>
        /// <param name="searchValue">Giá trị cần tìm kiếm theo ShipperName, Phone (chuỗi rỗng nếu không tìm thấy)</param>
        /// <returns></returns>
        List<Shipper> List(int page, int pageSize, string searchValue);
        /// <summary>
        /// Đếm số lượng nhà vận chuyển thỏa điều kiện tìm kiếm 
        /// </summary>
        /// <param name="searchValue">Giá trị cần tìm (chuỗi rỗng nếu không tìm thấy)</param>
        /// <returns></returns>
        int Count(string searchValue);
        /// <summary>
        /// Lấy thông tin của một nhà vận chuyển theo mã. Trong trường hợp nhà vận chuyển
        /// không tồn tại, hàng trả về giá trị null
        /// </summary>
        /// <param name="shipperID">mã của nhà cung cấp cần lấy thông tin</param>
        /// <returns></returns>
        Shipper Get(int shipperID);
        /// <summary>
        /// cập nhật thông tin của một nhà cung cấp. Hàm trả về giá trị boolean cho 
        /// biết việc cập nhật có thành công hay không
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Update(Shipper data);
        /// <summary>
        /// Xóa một nhà cung cấp dựa vào mã. hàm trả về giá trị bool cho biết việc xóa 
        /// có thực hiện hay không (Lưu ý : không được xóa nhà cung cấp nếu đang có 
        /// mặt hàng tham chiếu đến nhà cung câos
        /// </summary>
        /// <param name="shipperID"></param>
        /// <returns></returns>
        bool Delete(int shipperID);
    }


}
