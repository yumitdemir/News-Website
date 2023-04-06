using DSS.Models;

namespace DSS.Repository.TagsRepository
{
    public interface ITagRepository
    {
        public Task<TagModel> getTagByNameAsync(string tag);
    }
}
