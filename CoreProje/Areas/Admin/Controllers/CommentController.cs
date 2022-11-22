using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            var values = cm.GetComments();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var values = cm.GetId(id);
            cm.CommentDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = cm.GetId(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Comment comment)
        {
            comment.CommentStatus = true;
            cm.CommentUpdate(comment);
            return RedirectToAction("Index");
        }
    }
}
