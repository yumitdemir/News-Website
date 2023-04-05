namespace DSS.Models
{
    public  class DetailDTO
    {
     
        public NewsModel news { get; set; }

        public IEnumerable<CommentModel> comments { get; set; }

    }
}
