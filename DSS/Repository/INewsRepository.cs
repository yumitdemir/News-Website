using DSS.Models;

namespace DSS.Repository
{
    public interface INewsRepository
    {
        public void SaveNews(NewsModel news);
        public void RemoveNewsById(int id);
        public Task<NewsModel?> getNewsById(int newsId);
        public Task<IEnumerable<NewsModel?>> getAllNewsAsync();
        public void RemoveNewsByNewsModel(NewsModel news);
    }
}
