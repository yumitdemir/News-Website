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

        public async void RemoveNewsById(int id)
        {
            var news = await getNewsById(id);
            _context.News.Remove(news);
            _context.SaveChanges();
        }

        public async Task<NewsModel?> getNewsById(int newsId)
        {
           var news = await  _context.News.Include(x=> x.TagModel).Include(x=>x.UserModel).FirstOrDefaultAsync(x => x.Id == newsId);
           return news;
        }

        public async Task<IEnumerable<NewsModel?>> getAllNewsAsync()
        {
            var newsList = await _context.News.Include(x => x.TagModel).Include(x => x.UserModel).ToListAsync();
            return newsList;
        }

    }
}
