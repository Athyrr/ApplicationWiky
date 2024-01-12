using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationWiky.Controllers
{
    public class ArticleController : Controller
    {
        IArticleBusiness _articleBusiness;

        public ArticleController(IArticleBusiness articleBusiness)
        {
            _articleBusiness = articleBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
            => View(await _articleBusiness.GetArticleListAsync());


        [HttpGet]
        public async Task<IActionResult> Details(int id)
            => View(await _articleBusiness.GetArticleAsync(id));


        [HttpGet]
        public IActionResult AddArticle()
            => View();


        [HttpPost]
        public async Task<IActionResult> AddArticle(Article article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }
            else
            {
                await _articleBusiness.CreateArticleAsync(article);

                return RedirectToAction("Details", new { id = article.Id });
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveArticle(int id)
        {
            await _articleBusiness.DeleteArticleAsync(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditArticle(int id)
        {
            Article article = await _articleBusiness.GetArticleAsync(id);
            return View(article);

        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(Article article)
        {

            Article articleToEdit = await _articleBusiness.GetArticleAsync(article.Id);

            articleToEdit.Author = article.Author;
            articleToEdit.CreatedAt = article.CreatedAt;
            articleToEdit.Content = article.Content;
            articleToEdit.Theme = article.Theme;

            await _articleBusiness.EditArticleAsync(articleToEdit);

            return RedirectToAction("Details", new { id = articleToEdit.Id });

        }

        [HttpGet]
        public async Task<IActionResult> Search(List<Article> articlesFinded)
        {
            return View("Index", articlesFinded);

        }

        [HttpPost]
        public async Task<IActionResult> Search(string search)
        {
            var articlesFinded = await _articleBusiness.Search(search);
            return RedirectToAction("Search", articlesFinded);
        }


        [HttpGet]
        public async Task<IActionResult> SearchForm(List<Article> articlesFinded)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchByAuthor(string search)
        {
            var articlesFinded = await _articleBusiness.SearchByAuthor(search);
            return View("Index", articlesFinded);
        }

        [HttpPost]
        public async Task<IActionResult> SearchByDate(DateTime search)
        {
            var articlesFinded = await _articleBusiness.SearchByDate(search);
            return View("Index", articlesFinded);
        }

        [HttpPost]
        public async Task<IActionResult> SearchById(int search)
        {
            var articlesFinded = await _articleBusiness.SearchById(search);
            return View("Index", articlesFinded);
        }
      
    }
}
