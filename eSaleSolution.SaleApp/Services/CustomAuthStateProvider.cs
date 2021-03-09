using eSaleSolution.ApiIntegration;
using eSaleSolution.ViewModels.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.SaleApp.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IUserApiClient _userApiClient;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public CustomAuthStateProvider(ILocalStorageService localStorage, IUserApiClient userApiClient, 
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _localStorage = localStorage;
            _userApiClient = userApiClient;
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public  override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {

            LoginApiResult currentUser = await _httpClient.GetFromJsonAsync<LoginApiResult>("api/Users/authenticate");
             
            var userPrincipal = this.ValidateToken(currentUser.Token);
 
            if (userPrincipal.Identity.IsAuthenticated)
            {
                //create a claim
                var claim = new Claim( ClaimTypes.Name, currentUser.Email);
                //create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");
                //create claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                return new AuthenticationState(claimsPrincipal);
            }
            else
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

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
