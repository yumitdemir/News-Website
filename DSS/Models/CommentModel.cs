using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSS.Models
{
    public class CommentModel
    {
        [Key] public int Id { get; set; }

        public string Content { get; set; }

       
        public virtual  UserModel UserModel { get; set; }

        
        public virtual  NewsModel NewsModel { get; set; }


    }
}
