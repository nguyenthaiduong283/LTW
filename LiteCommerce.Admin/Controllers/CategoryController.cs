using LiteCommerce.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index(int page = 1, string searchValue = "")
        {
            int rowCount = 0;
            int pageSize = 5;
            var listOfCategory = DataService.ListCategorys(page, pageSize, searchValue, out rowCount);

            var model = new Models.CategoryPaginationQueryResult()
            {
                Page = page,
                PageSize = pageSize,
                SearchValue = searchValue,
                RowCount = rowCount,
                Data = listOfCategory
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
            ViewBag.Title = "Thay đổi thông tin loại hàng";
            return View("Edit");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            ViewBag.Title = "Bổ sung loại hàng";
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