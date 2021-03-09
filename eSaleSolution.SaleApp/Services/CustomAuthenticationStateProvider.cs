using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using eSaleSolution.SaleApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace eSaleSolution.SaleApp.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly HttpClient _httpClient;
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;
        private ILocalStorageService _localStorageService;
        public CustomAuthenticationStateProvider(HttpClient httpClient, IAuthenticationService authenticationService, IConfiguration configuration, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _authenticationService = authenticationService;
            _configuration = configuration;
            _localStorageService = localStorageService;
        }

        string UserName;
        string PassWord;
        bool RememberMe;

        public void LoadUser(string _userName, string _passWord, bool _rememberMe)
        {
            UserName = _userName;
            PassWord = _passWord;
            RememberMe = _rememberMe;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if( string.IsNullOrEmpty( UserName) &&  string.IsNullOrEmpty(PassWord)) return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

            var result = await _authenticationService.Login(UserName, PassWord, RememberMe);

            var userPrincipal = this.ValidateToken(result.Token);

            var authenticated = result.Token != null;

            
            if (!authenticated)
            {
                await _localStorageService.RemoveItem("user");
            }
            else
            {
                await _localStorageService.SetItem("user", result);
            }

            //create a claim
            var claim = new Claim(ClaimTypes.Name, result.UserName);
            //create claimsIdentity
            var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");

            var identity = authenticated
                ? claimsIdentity
                : new ClaimsIdentity();

            var auth = new AuthenticationState(new ClaimsPrincipal(identity));

            return auth;
        }


        private ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = _configuration["Tokens:Issuer"];
            validationParameters.ValidIssuer = _configuration["Tokens:Issuer"];
            validationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);

            return principal;
        }
    }
}