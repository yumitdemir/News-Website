using System.ComponentModel.DataAnnotations;

namespace DSS.Models
{
    public class TagModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
