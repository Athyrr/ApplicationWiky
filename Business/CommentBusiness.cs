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
    public class CommentBusiness : ICommentBusiness
    {
        public ICommentRepository _commentRepository;

        public CommentBusiness(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            comment.CreatedAt = DateTime.Now;
            comment.EditedAt = DateTime.Now;

            await _commentRepository.CreateCommentAsync(comment);
        }

        public async Task<List<Comment>> GetCommentListAsync()
            => await _commentRepository.GetCommentListAsync();


        public async Task<Comment?> GetCommentAsync(int id)
        {
            var comment = await _commentRepository.GetCommentAsync(id);
            if (comment is null)
            {
                throw new Exception("Aucun commentaire à supprimer");
            }
            return comment;
        }

        public async Task EditCommentAsync(Comment comment)
        {
            comment.EditedAt = DateTime.Now;

            await _commentRepository.EditCommentAsync(comment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            await _commentRepository.DeleteCommentAsync(id);
        }
    }
}
