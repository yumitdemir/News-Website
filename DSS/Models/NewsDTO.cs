namespace DSS.Models
{
    public class NewsDTO
    {
        public List<NewsModel> allNewsList { get; set; }

        public List<NewsModel?> mainNewsList { get; set; }
        public List<NewsModel> latestNewsList { get; set; }
        public List<NewsModel> trendingNewsList { get; set; }

        public double newsCount { get; set; }


    }
}
