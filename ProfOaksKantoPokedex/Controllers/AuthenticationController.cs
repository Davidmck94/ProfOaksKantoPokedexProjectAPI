using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProfOaksKantoPokedex.Controllers
{
    [Route("api/authentication")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        // This will not be used outside of this class, so it will be scoped to this namespace

        
        public class AuthenticationRequestBody
        {
            public string? UserName { get; set; }
            public string? Password { get; set; }
        }

        private class ProfOaksKantoPokedexUser
        {
            public int UserId { get; set; }
            public string UserName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }

            public ProfOaksKantoPokedexUser(
                int userId,
                string userName,
                string firstName,
                string lastName,
                string city)
            {
                UserId = userId;
                UserName = userName;
                FirstName = firstName;
                LastName = lastName;
                City = city;
            }

        }

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration ?? 
                throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// Authenticate user of the API
        /// </summary>
        /// <param name="authenticationRequestBody"></param>
        /// <returns>An ActionResult as a string</returns>
        [HttpPost("authenticate")]

        public ActionResult<string> Authenticate(
            AuthenticationRequestBody authenticationRequestBody)
        {
            // Step 1: username/password validation
            var user = ValidateUserCredentials(
                authenticationRequestBody.UserName,
                authenticationRequestBody.Password);

            if(user == null)
            {
                return Unauthorized();
            }

            // Step 2: Create a token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256 );


            // Step 3: Claims - Identity related information on the user
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
            claimsForToken.Add(new Claim("given_name", user.FirstName));
            claimsForToken.Add(new Claim("family_name", user.LastName));
            claimsForToken.Add(new Claim("city", user.City));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
               .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);

        }

        private ProfOaksKantoPokedexUser ValidateUserCredentials(string? userName, string? password)
        {
            // Currently don't have a user DB or table
            // When it is implemented I will check the passed-through username/password against what is stored
            // For now I will assume that the credentials are correct
            // Return a new ProfOaksKanotPokedexUser (the values would usually come form the DB/ table)

            return new ProfOaksKantoPokedexUser(
                1,
                "Prof Oak",
                "Samuel",
                "Oak",
                "Pallet Town");

        }
    }
}
