﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteCommerce.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
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