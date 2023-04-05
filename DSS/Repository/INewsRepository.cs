using DSS.Models;

namespace DSS.Repository
{
    public interface INewsRepository
    {
        public void SaveNews(NewsModel news);
        public void RemoveNews(NewsModel news);
        public Task<NewsModel> getNewsById(int newsId);

    }
}
