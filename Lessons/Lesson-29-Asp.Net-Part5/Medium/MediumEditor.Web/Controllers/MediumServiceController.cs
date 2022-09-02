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

        public MediumServiceController(IConfiguration configuration)
        {
            _mediumClient = new Client();
            _mediumToken = new Token
            {
                AccessToken = configuration.GetValue<string>("MediumAccessToken")
            };
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
    }
}
