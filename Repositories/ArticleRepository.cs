﻿using Azure.Messaging;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public readonly WikyContext _context;

        public ArticleRepository(WikyContext context)
        {
            _context = context;
        }

        public async Task CreateArticleAsync(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Article>> GetArticleListAsync() 
            => await _context.Articles.ToListAsync();
        public async Task<Article?> GetArticleAsync(int id)
            => await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);

        public async Task EditArticleAsync(Article article)
        {
            Article? articleToModify = await _context.Articles.FirstOrDefaultAsync(a => a.Id == article.Id);
            articleToModify.Author = article.Author;
            articleToModify.Theme = article.Theme;
            articleToModify.CreatedAt = article.CreatedAt;
            articleToModify.EditedAt = article.EditedAt;
            articleToModify.Content = article.Content;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteArticleAsync(int id)
        {
            Article article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }


    }
}