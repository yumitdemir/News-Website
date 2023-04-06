using Azure;
using DSS.Data;
using DSS.Models;
using Microsoft.EntityFrameworkCore;

namespace DSS.Repository.TagsRepository
{
    public class TagRepository :ITagRepository
    {
        private readonly ApplicationDBContext _context;

        public TagRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TagModel> getTagByNameAsync(string tag)
        {
            TagModel? selectedTag = await _context.Tags.FirstOrDefaultAsync(x => x.Name == tag);

            return selectedTag;
        }

    }
}
