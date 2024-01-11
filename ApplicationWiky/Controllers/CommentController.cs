using Business;
using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationWiky.Controllers
{
    public class CommentController : Controller
    {
        ICommentBusiness _commentBusiness;

        public CommentController(ICommentBusiness commentBusiness)
        {
            _commentBusiness = commentBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
            =>  View(await _commentBusiness.GetCommentListAsync());


        [HttpGet]
        public async Task<IActionResult> AddComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            await _commentBusiness.CreateCommentAsync(comment);  

            return RedirectToAction("Details","Article", new { id = comment.Id });
        }

    }
}
