using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customers
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int rowCount = 0;
            int pageSize = 10;
            var listOfCustomer = DataService.ListCustomers(page, pageSize, searchValue, out rowCount);

            var model = new Models.CustomerPaginationQueryResult()
            {
                Page = page,
                PageSize = pageSize,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listOfCustomer
            };
            return View(model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(String id)
        {
            ViewBag.Title = "Thay đổi thông tin khách hàng";
            return View("Edit");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.Title = "Bổ sung khách hàng";
            return View("Edit");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Save()
        {

            return RedirectToAction("index");
        }
    }
}