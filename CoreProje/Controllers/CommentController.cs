using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreProje.Controllers
{
    [AllowAnonymous]
	public class CommentController : Controller
	{
		CommentManager cm = new CommentManager(new EfCommentRepository());
		[HttpGet]
		public PartialViewResult AddComment()
		{
			return PartialView();
		}
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogID = 2;
            cm.CommentAdd(comment);
            return RedirectToAction("Details","Blog");
        }

        public PartialViewResult Comments(int id)
        {
            var values = cm.GetAll(id);
            return PartialView(values);
        }
    }
}
