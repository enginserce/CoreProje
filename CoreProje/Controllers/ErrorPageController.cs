using Microsoft.AspNetCore.Mvc;

namespace CoreProje.Controllers
{
    public class ErrorPageController : Controller
    {
        [Route("errorpage/404")]
        public IActionResult NotFound(int code)
        {
            return View();
        }
        [Route("errorpage/403")]
        public IActionResult Forbidden(int code)
        {
            return View();
        }
    }
}
