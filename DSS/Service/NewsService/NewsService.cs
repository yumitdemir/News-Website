using DSS.Models;

namespace DSS.Service.NewsService;

public class NewsService : INewsService
{
    public List<ErrorDTO> ValidateNewsModel(string title, string content, string tag, IFormFile thumbnailImg)
    {
        var errors = new List<ErrorDTO>();

        if (string.IsNullOrWhiteSpace(title))
        {
            var tempErr = new ErrorDTO();
            tempErr.key = "Title";
            tempErr.errorMessage = "Please provide a title";
            errors.Add(tempErr);
        }

        if (string.IsNullOrWhiteSpace(content))
        {
            var tempErr = new ErrorDTO();
            tempErr.key = "Content";
            tempErr.errorMessage = "Please provide a content";
            errors.Add(tempErr);
        }

        if (string.IsNullOrWhiteSpace(tag))
        {
            var tempErr = new ErrorDTO();
            tempErr.key = "TagModel";
            tempErr.errorMessage = "Please provide a tag";
            errors.Add(tempErr);
        }

        if (thumbnailImg != null && thumbnailImg.Length > 0)
            if (thumbnailImg.ContentType != "image/png" && thumbnailImg.ContentType != "image/jpeg" && thumbnailImg.ContentType != "image/jpg")
            {
                var tempErr = new ErrorDTO();
                tempErr.key = "ThumbnailImgUrl";
                tempErr.errorMessage = "Please only upload a jpg or png file";
                errors.Add(tempErr);
            }


        return errors;
    }

   

}