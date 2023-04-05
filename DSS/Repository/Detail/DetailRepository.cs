using DSS.Data;
using DSS.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS.Repository.Detail
{
    public class DetailRepository : IDetailRepository
    {
        private readonly ApplicationDBContext _context;

        public DetailRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<NewsModel?> GetByIdAsync(int id)
        {
            return await _context?.News?.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}
