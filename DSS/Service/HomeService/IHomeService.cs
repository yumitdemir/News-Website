using DSS.Models;

namespace DSS.Service.HomeService
{
    public interface IHomeService
    {
        public List<NewsModel>? getMainNewsList(List<NewsModel> allNews);
    }
}
