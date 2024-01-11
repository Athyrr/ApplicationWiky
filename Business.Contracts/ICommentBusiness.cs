using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface ICommentBusiness
    {
        //Pouvoir lister / détail / créer / modifier / supprimer les articles

        public Task CreateCommentAsync(Comment comment);

        public Task<List<Comment>> GetCommentListAsync();

        public Task<Comment> GetCommentAsync(int id);

        public Task EditCommentAsync(Comment comment);

        public Task DeleteCommentAsync(int id);
    }
}
