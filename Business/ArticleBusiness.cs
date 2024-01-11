using Business.Contracts;
using Entities;
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
            await _articleRepository.CreateArticleAsync(article);
        }
        public async Task<List<Article>> GetArticleListAsync()
            => await _articleRepository.GetArticleListAsync();


        public async Task<Article?> GetArticleAsync(int id)
        {
            var article = await _articleRepository.GetArticleAsync(id);
            if (article is null)
            {
                throw new Exception("Aucun message à supprimer");
            }
            return article;
        }

        public async Task EditArticleAsync(Article article)
            =>await _articleRepository.EditArticleAsync(article); 


        public async Task DeleteArticleAsync(int id)
        {
            await _articleRepository.DeleteArticleAsync(id);
        }
    }
}
