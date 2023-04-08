using DSS.Models;
using DSS.Repository.CommentRepository;

namespace DSS.Service.HomeService;

public class HomeService : IHomeService
{
    private readonly ICommentRepository _commentRepository;

    public HomeService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<NewsCommentCountDTO>> getMainNewsListWithCountAsync(List<NewsCommentCountDTO> allNews)
    {

        List<NewsCommentCountDTO> mainNewsList = new List<NewsCommentCountDTO>() ;
        var random = new Random();

        // Generate 4 unique random integers within the range of the newsList length
        if (allNews.Count() < 5)
            mainNewsList = allNews;
        else
            for (var i = 0; i < 5; i++)
            {
                var randomNumber = random.Next(0, allNews.Count());
                NewsCommentCountDTO tempDTO  = new NewsCommentCountDTO();
                tempDTO.news = allNews[randomNumber].news;
                IEnumerable<CommentModel>? Commnets = await _commentRepository.getCommentsByNewsIdAsync(allNews[randomNumber].news.Id);
                int count = (Commnets != null) ? Commnets.Count() : 0;

                mainNewsList.Add(tempDTO);
            }


        return mainNewsList;
    }
}