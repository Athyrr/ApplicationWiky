using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IArticleRepository
    {
        //Pouvoir lister / détail / créer / modifier / supprimer les articles

        public Task CreateArticleAsync(Article article);

        public Task<List<Article>> GetArticleListAsync();

        public Task<Article> GetArticleAsync(int id);

        public Task EditArticleAsync(Article article);

        public Task DeleteArticleAsync(int id);

        public Task<List<Article>> Search(string search);

        public  Task<List<Article>> SearchByAuthor(string search);
        public Task<List<Article>> SearchByDate(DateTime search);
        public Task<List<Article>> SearchById(int search);

    }
}
