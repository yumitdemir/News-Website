using DSS.Models;

namespace DSS.Repository.CommentRepository
{
    public interface ICommentRepository
    {
        public void addComment(CommentModel comment);

        public void removeCommentById(int id);

        public Task<IEnumerable<CommentModel>> getAllCommentsAsync();

        public Task<CommentModel> getCommentByIdAsync(int commentId);

        public Task<IEnumerable<CommentModel>> getCommentsByNewsIdAsync(int newsId);

    }
}
