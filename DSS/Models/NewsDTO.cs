namespace DSS.Models
{
    public class NewsDTO
    {
        public List<NewsCommentCountDTO> allNewsList { get; set; }

        public List<NewsCommentCountDTO> mainNewsList { get; set; }
        public List<NewsCommentCountDTO> latestNewsList { get; set; }
        public List<NewsCommentCountDTO> trendingNewsList { get; set; }

        public double newsCount { get; set; }


    }
}
