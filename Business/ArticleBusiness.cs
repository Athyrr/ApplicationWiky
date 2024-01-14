using Business.Contracts;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ArticleBusiness : IArticleBusiness
    {
        public IArticleRepository _articleRepository;

        public ArticleBusiness(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task CreateArticleAsync(Article article)
        {
            article.CreatedAt = DateTime.Now;
            article.EditedAt = DateTime.Now;

            await _articleRepository.CreateArticleAsync(article);
        }
        public async Task<List<Article>> GetArticleListAsync()
            => await _articleRepository.GetArticleListAsync();


        public async Task<Article?> GetArticleAsync(int id)
        {
            var article = await _articleRepository.GetArticleAsync(id);
            if (article is null)
            {
                throw new Exception("Aucun article à supprimer");
            }
            return article;
        }

        public async Task EditArticleAsync(Article article)
        {
            article.EditedAt = DateTime.Now;
            await _articleRepository.EditArticleAsync(article);
        }

        public async Task DeleteArticleAsync(int id)
        {
            await _articleRepository.DeleteArticleAsync(id);
        }

        public async Task<bool> IsThemeUnique(string theme)
           => await _articleRepository.IsThemeUnique(theme);



        public async Task<List<Article>> Search(string search)
            => await _articleRepository.Search(search);

        public async Task<List<Article>> SearchByAuthor(string search)
         => await _articleRepository.SearchByAuthor(search);
        public async Task<List<Article>> SearchByDate(DateTime search)
            => await _articleRepository.SearchByDate(search);
        public async Task<List<Article>> SearchById(int search)
            => await _articleRepository.SearchById(search);

        public async Task<Article> GetLastArticleAsync()
        {
            var articles = await _articleRepository.GetArticleListAsync();
            return articles.LastOrDefault();
        }
    }
}
