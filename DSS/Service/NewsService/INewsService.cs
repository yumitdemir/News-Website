using DSS.Models;

namespace DSS.Service.NewsService
{
    public interface INewsService
    {
        public List<ErrorDTO> ValidateNewsModel(string title, string content, string tag, IFormFile thumbnailImg);
    }
}
