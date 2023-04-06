using DSS.Models;

namespace DSS.Service.HomeService;

public class HomeService : IHomeService
{
    public List<NewsModel> getMainNewsList(List<NewsModel>? allNews)
    {
        List<NewsModel> mainNewsList = new();
        var random = new Random();

        // Generate 4 unique random integers within the range of the newsList length
        if (allNews.Count() < 5)
            mainNewsList = allNews;
        else
            for (var i = 0; i < 5; i++)
            {
                var randomNumber = random.Next(0, allNews.Count());
                mainNewsList.Add(allNews[randomNumber]);
            }


        return mainNewsList;
    }
}