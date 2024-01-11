﻿using Business.Contracts;
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
        {
            return View(await _articleBusiness.GetArticleListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _articleBusiness.GetArticleAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> AddArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle(Article article)
        {
            await _articleBusiness.CreateArticleAsync(article);

            return RedirectToAction("Details", new {id = article.Id});
        }

        [HttpGet]
        public async Task<IActionResult> RemoveArticle(int id)
        {
            await _articleBusiness.DeleteArticleAsync(id);

            return RedirectToAction("Index");
        }

    }
}