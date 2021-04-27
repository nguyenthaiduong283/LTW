using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteCommerce.BusinessLayers
{
    /// <summary>
    /// Các chức năng nghiệp vụ liên quan đến quản lý dữ liệu chung
    /// </summary>
    public static class DataService
    {
        private static ICountryDAL CountryDB;
        private static ICityDAL CityDB;
        private static ISupplierDAL SupplierDB;

        private static IEmployeeDAL EmployeeDB;
        private static IShipperDAL ShipperDB;
        private static ICustomerDAL CustomerDB;
        private static ICategoryDAL CategoryDB;
        /// <summary>
        /// Khởi tạo tính năng tác nghiệp ( hàm này phải được gọi nếu muốn sử dụng các tính năng của lớp)
        /// </summary>
        /// <param name="dbtypes"></param>
        /// <param name="connectionString"></param>
        public static void Init(DatabaseTypes dbType, string connectionString)
        {
            switch (dbType)
            {
                case DatabaseTypes.SQLServer:
                    CountryDB = new DataLayers.SQLServer.CountryDAL(connectionString);
                    CityDB = new DataLayers.SQLServer.CityDAL(connectionString);
                    SupplierDB = new DataLayers.SQLServer.SupplierDAL(connectionString);

                    ShipperDB = new DataLayers.SQLServer.ShipperDAL(connectionString);
                    EmployeeDB = new DataLayers.SQLServer.EmployeeDAL(connectionString);
                    CustomerDB = new DataLayers.SQLServer.CustomerDAL(connectionString);
                    CategoryDB = new DataLayers.SQLServer.CategoryDAL(connectionString);
                    break;
                default:
                    throw new Exception("Database Type is not Supported");
            }
        }
        /// <summary>
        /// Danh sách quốc gia 
        /// </summary>
        /// <returns></returns>
        public static List<Country> ListCountries()
        {
            return CountryDB.List();
        }

        /// <summary>
        /// Danh sách các thành phố
        /// </summary>
        /// <returns></returns>
        public static List<City> ListCities()
        {
            return CityDB.List();
        }
        /// <summary>
        /// Danh sách thành phố thuộc quốc gia
        /// </summary>
        /// <param name="countyName"></param>
        /// <returns></returns>
        public static List<City> ListCities(string countyName)
        {
            return CityDB.List(countyName);
        }

        public static List<Supplier> ListSuppliers(int page, int pageSize, String searchValue, out int rowCount)
        {
            rowCount = SupplierDB.Count(searchValue);
            return SupplierDB.List(page, pageSize, searchValue);
        }
        /// <summary>
        /// bổ sung nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int AddSupplier(Supplier data)
        {
            return SupplierDB.Add(data);
        }
        /// <summary>
        /// cập nhật nhà cung cấp
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool UpdateSupplier(Supplier data)
        {
            return SupplierDB.Update(data);
        }
        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static bool DeleteSupplier(int supplierID)
        {
            return SupplierDB.Delete(supplierID);
        }
        /// <summary>
        /// Lấy thông tin nhà cung cấp
        /// </summary>
        /// <param name="supplierID"></param>
        /// <returns></returns>
        public static Supplier GetSupplier(int supplierID)
        {
            return SupplierDB.Get(supplierID);
        }




        public static List<Shipper> ListShippers(int page, int pageSize, String searchValue, out int rowCount)
        {
            rowCount = ShipperDB.Count(searchValue);
            return ShipperDB.List(page, pageSize, searchValue);
        }

        public static List<Employee> ListEmployees(int page, int pageSize, String searchValue, out int rowCount)
        {
            rowCount = EmployeeDB.Count(searchValue);
            return EmployeeDB.List(page, pageSize, searchValue);
        }


        public static List<Customer> ListCustomers(int page, int pageSize, String searchValue, out int rowCount)
        {
            rowCount = CustomerDB.Count(searchValue);
            return CustomerDB.List(page, pageSize, searchValue);
        }

        public static List<Category> ListCategorys(int page, int pageSize, String searchValue, out int rowCount)
        {
            rowCount = CategoryDB.Count(searchValue);
            return CategoryDB.List(page, pageSize, searchValue);
        }

    }
}
