using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.Tweet.CreateTweet;
using Communication.Requests.Tweet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TweetController : ControllerBase
    {

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateTweet([FromBody] CreateTweetRequest request, [FromServices] ICreateTweetUseCase createTweetUseCase)
        {
            var bearer = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            await createTweetUseCase.Execute(request, bearer);

            return Ok("tweet created successfully");
        }
    }
}