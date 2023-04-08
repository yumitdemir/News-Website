using DSS.Models;

namespace DSS.Service.HomeService
{
    public interface IHomeService
    {
        public Task<List<NewsCommentCountDTO>> getMainNewsListWithCountAsync(List<NewsCommentCountDTO> allNews);
    }
}
