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
            => View(await _commentBusiness.GetCommentListAsync());


        [HttpGet]
        public async Task<IActionResult> AddComment(int articleId)
            => View();


        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return View(comment);
            }
            else
            {
                await _commentBusiness.CreateCommentAsync(comment);

                return RedirectToAction("Index");
            }


        }

        [HttpGet]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _commentBusiness.DeleteCommentAsync(id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> RemoveCommentWithAjax(int id)
        {
            await _commentBusiness.DeleteCommentAsync(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> AddCommentWithAjax(Comment comment)
        {
            await _commentBusiness.CreateCommentAsync(comment);

            return RedirectToAction("Index");
        }



    }
}
