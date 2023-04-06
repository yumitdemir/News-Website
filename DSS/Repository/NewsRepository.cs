using DSS.Data;
using DSS.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS.Repository
{
    public class NewsRepository :INewsRepository
    {
        ApplicationDBContext _context;

        public NewsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void SaveNews(NewsModel news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }

        public void RemoveNewsById(int id)
        {
            var news = getNewsById(id).Result;
            _context.News.Remove(news);
            _context.SaveChanges();
        }

        public async Task<NewsModel?> getNewsById(int newsId)
        {
           var news = await  _context.News.FirstOrDefaultAsync(x => x.Id == newsId);
           return news;
        }

        public async Task<IEnumerable<NewsModel?>> getAllNewsAsync()
        {
            var newsList = await _context.News.ToListAsync();
            return newsList;
        }

    }
}
