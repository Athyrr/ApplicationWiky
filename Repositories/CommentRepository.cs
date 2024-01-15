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
    public class CommentRepository : ICommentRepository
    {
        private readonly WikyContext _context;

        public CommentRepository(WikyContext context)
        {
            _context = context;
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Comment>> GetCommentListAsync()
             => await _context.Comments.ToListAsync();

        public async Task<Comment?> GetCommentAsync(int id)
             => await _context.Comments.FirstOrDefaultAsync(a => a.Id == id);

        public async Task EditCommentAsync(Comment comment)
        {
            Comment? commentToModify = await _context.Comments.FirstOrDefaultAsync(c => c.Id == comment.Id);
            commentToModify.Author = comment.Author;
            commentToModify.CreatedAt = comment.CreatedAt;
            commentToModify.EditedAt = comment.EditedAt;
            commentToModify.Content = comment.Content;
            commentToModify.Article = comment.Article;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int id)
        {
            Comment? comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }



    }
}
