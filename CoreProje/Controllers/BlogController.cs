using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreProje.Controllers
{
	public class BlogController : Controller
	{
		BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        Context c = new Context();

        [AllowAnonymous]
        public IActionResult Index()
		{
			var values = bm.GetBlogListWithCategory();
			return View(values);
		}

        [AllowAnonymous]
        public IActionResult Details(int id)
		{
			ViewBag.i = id;
			var values = bm.GetBlogId(id);
			return View(values);
		}

		public IActionResult BlogListByWriter()
		{
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(userID);
			return View(values);
		}
		[HttpGet]
		public IActionResult BlogAdd()
		{
			List<SelectListItem> categoryValue = (from x in cm.GetList()
												  select new SelectListItem
												  {
													  Text = x.CategoryName,
													  Value = x.CategoryID.ToString()
												  }).ToList();
			ViewBag.cv = categoryValue;
			return View();
		}
        [HttpPost]
        public IActionResult BlogAdd(Blog blog)
        {
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            BlogValidator bv = new BlogValidator();
            ValidationResult result = bv.Validate(blog);
            if (result.IsValid)
            {
                blog.BlogStatus = true;
				blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				blog.WriterID = userID;
				bm.TAdd(blog);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
		public IActionResult Delete(int id)
		{
			var values = bm.GetId(id);
			bm.TDelete(values);
            return RedirectToAction("BlogListByWriter");
        }
		[HttpGet]
        public IActionResult Edit(int id)
        {
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            var blogvalue = bm.GetId(id);
            return View(blogvalue);
        }
        [HttpPost]
		public IActionResult Edit(Blog blog)
		{
            var username = User.Identity.Name;
            var userID = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            blog.WriterID = userID;
			blog.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blog.BlogStatus = true;
			bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
