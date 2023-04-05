using DSS.Data;
using DSS.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS.Repository.Detail
{
    public class DetailRepository : IDetailRepository
    {
        private readonly ApplicationDBContext _cotext;

        public DetailRepository(ApplicationDBContext context)
        {
            _cotext = context;
        }

        public async Task<NewsModel> GetByIdAsync(int id)
        {
            return await _cotext.News.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
