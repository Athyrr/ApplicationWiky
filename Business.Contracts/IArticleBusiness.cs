﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IArticleBusiness
    {
        //Pouvoir lister / détail / créer / modifier / supprimer les articles

        public Task CreateArticleAsync(Article article);

        public Task<List<Article>> GetArticleListAsync();

        public Task<Article> GetArticleAsync(int id);

        public Task EditArticleAsync(Article article);

        public Task DeleteArticleAsync(int id);
    }
}
