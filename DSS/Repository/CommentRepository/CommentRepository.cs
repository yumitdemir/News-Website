using DSS.Data;
using DSS.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS.Repository.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;

        public CommentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void addComment(CommentModel comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void removeCommentById(int id)
        {
            var comment = getCommentByIdAsync(id).Result;
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<CommentModel>> getAllCommentsAsync()
        {
            
            var allComments = await _context.Comments.Include("UserModel").Include("NewsModel").ToListAsync();

            return allComments;
        }

        public async Task<CommentModel> getCommentByIdAsync(int commentId)
        {
            var comment = await _context.Comments.Include("UserModel").Include("NewsModel").FirstOrDefaultAsync(x=> x.Id == commentId);

            return comment;
        }

        public async Task<IEnumerable<CommentModel>> getCommentsByNewsIdAsync(int newsId)
        {
            var commentList = await _context.Comments.Include("UserModel").Include("NewsModel").Where(x => x.NewsModel.Id == newsId).ToListAsync();

            return commentList;

        }

    }
}
