
using eSaleSolution.Data.Entities;
using eSaleSolution.ViewModels.Common;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.SaleApp.Services
{
    public interface IAuthenticationService
    {
        LoginApiResult AppUser { get; }
        Task Initialize();
        Task<LoginApiResult> Login(string username, string password, bool rememberme);
        Task Logout();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public LoginApiResult AppUser { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        ) {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            AppUser = await _localStorageService.GetItem<LoginApiResult>("user");
        }

        public async Task<LoginApiResult> Login(string username, string password, bool rememberme)
        {
            AppUser = await _httpService.Post<LoginApiResult>("/api/users/authenticate", new { username, password , rememberme });
            await _localStorageService.SetItem("user", AppUser);
            return AppUser;
        }

        public async Task Logout()
        {
            AppUser = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }
    }
}