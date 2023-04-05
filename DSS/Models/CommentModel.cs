using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSS.Models
{
    public class CommentModel
    {
        [Key] public int Id { get; set; }

        public string Content { get; set; }

        [ForeignKey("AuthorId")]
        public int? AuthorId { get; set; }
        public virtual  UserModel UserModel { get; set; }

        [ForeignKey("NewsId")]
        public int? NewsId { get; set; }
        public virtual  NewsModel NewsModel { get; set; }


    }
}
