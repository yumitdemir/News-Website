using DSS.Models;

namespace DSS.Repository.Detail
{
    public interface IDetailRepository
    {
        public Task<NewsModel> GetByIdAsync(int id);
    }
}
