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

        public void RemoveNews(NewsModel news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }

    }
}
