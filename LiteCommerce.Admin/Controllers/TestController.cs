using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiteCommerce.DataLayers;
using LiteCommerce.DomainModels;

namespace LiteCommerce.Admin.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: Test
        public ActionResult Index()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LiteCommerceDB"].ConnectionString;
            /*ICountryDAL dal = new DataLayers.SQLServer.CountryDAL(connectionString);
            var data = dal.List();*/

            /*ICityDAL dal = new DataLayers.SQLServer.CityDAL(connectionString);
            var data = dal.List();*/

            ISupplierDAL dal = new DataLayers.SQLServer.SupplierDAL(connectionString);
            /*var data = dal.Count("Big");*/
            /*var data = dal.Get(1);*/
            
            Supplier s = new Supplier()
            {
                SupplierName = "Nguyen Thai Duong",
                ContactName = "123",
                Address= "QT",
                City = "aa",
                PostalCode = "",
                Country = "vn",
                Phone = "0123",
            };
            var data = dal.Update(s);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Pagination(int page, int pageSize, string searchValue)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LiteCommerceDB"].ConnectionString;
            IEmployeeDAL dal = new DataLayers.SQLServer.EmployeeDAL(connectionString);
            var data = dal.List(page, pageSize, searchValue);

            /*IShipperDAL dal = new DataLayers.SQLServer.ShipperDAL(connectionString);
            var data = dal.List(page, pageSize, searchValue);*/

            /*ICustomerDAL dal = new DataLayers.SQLServer.CustomerDAL(connectionString);
            var data = dal.List(page, pageSize, searchValue);*/

            /*ISupplierDAL dal = new DataLayers.SQLServer.SupplierDAL(connectionString);
            var data = dal.List(page, pageSize, searchValue);*/

            /*ICategoryDAL dal = new DataLayers.SQLServer.CategoryDAL(connectionString);
            var data = dal.List(page, pageSize, searchValue);*/

            return Json(data, JsonRequestBehavior.AllowGet);
        }
       
    }
}