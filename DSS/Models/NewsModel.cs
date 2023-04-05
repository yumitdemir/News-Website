using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSS.Models
{
    public class NewsModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }

        public string ThumbnailImgUrl { get; set; }

        [ForeignKey("TagId")]
        public int? TagId { get; set; }
        public virtual TagModel TagModel { get; set; } // navigation prop

        [ForeignKey("AuthorId")]
        public int? AuthorId { get; set; }
        public virtual UserModel UserModel { get; set; } // navigation prop
    }
    
}
