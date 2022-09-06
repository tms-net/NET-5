using Medium;
using Medium.Authentication;
using Medium.Models;
using MediumEditor.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediumEditor.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediumServiceController : ControllerBase
    {
        private readonly Client _mediumClient;
        private readonly Token _mediumToken;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IFormFile _mediumfile;

        public MediumServiceController(IConfiguration configuration)
        {
            _mediumClient = new Client();
            _mediumToken = new Token
            {
                AccessToken = configuration.GetValue<string>("MediumAccessToken")
            };
        }

        public MediumServiceController(IFormFile mediumfile, IWebHostEnvironment appEnvironment)
        {
            _mediumfile = mediumfile;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public User Get()
        {
            return _mediumClient.GetCurrentUser(_mediumToken);
        }

        [HttpPost]
        public string Post(NewPostModel newPost)
        {
            // Get profile details of the user identified by the access token.
            var user = _mediumClient.GetCurrentUser(_mediumToken);

            // Create a draft post.
            var post = _mediumClient.CreatePost(
                user.Id,
                new CreatePostRequestBody
                {
                    Title = newPost.Title,
                    ContentFormat = Medium.Models.ContentFormat.Markdown,
                    Content = newPost.Text,
                    PublishStatus = Medium.Models.PublishStatus.Public,
                },
                _mediumToken);

            /*
             * {
                  "title": newPost.Title,
                  "contentFormat": "markdown",
                  "content": newPost.Text,
                  "publishStatus": "public"
                }
             */

            return post.Url;
        }

        public class FileModel
        {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        }
        
        public async Task<IActionResult> Upload(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel{Name = uploadedFile.Name, Path = path};
            }
            return RedirectToAction("Index");;
        }
    }
}
