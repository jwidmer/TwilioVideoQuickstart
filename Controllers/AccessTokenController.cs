using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twilio.Jwt.AccessToken;

namespace TwilioVideoQuickstart2.Controllers
{
    [ApiController]
    public class AccessTokenController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public AccessTokenController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [Route("api/accesstoken")]
        public IActionResult GetAccessToken()
        {
            // Load Twilio configuration from Web.config
            var accountSid = Configuration["Twilio:AccountSid"];
            var apiKey = Configuration["Twilio:ApiKey"];
            var apiSecret = Configuration["Twilio:ApiSecret"];

            // Create a random identity for the client
            //var identity = "jeff";
            var identity = Guid.NewGuid().ToString();

            // Create a video grant for the token
            var grant = new VideoGrant();
            grant.Room = "my-room";
            var grants = new HashSet<IGrant> { grant };

            // Create an Access Token generator
            var token = new Token(accountSid, apiKey, apiSecret, identity: identity, grants: grants);

            return Ok(new { accessToken = token.ToJwt() });

        }

    }
}