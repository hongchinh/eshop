
using eSaleSolution.Data.Entities;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.SaleApp.Services
{
    public interface IAuthenticationService
    {
        AppUser AppUser { get; }
        Task Initialize();
        Task Login(string username, string password);
        Task Logout();
    }

    public class AuthenticationService : IAuthenticationService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public AppUser AppUser { get; private set; }

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
            AppUser = await _localStorageService.GetItem<AppUser>("user");
        }

        public async Task Login(string username, string password)
        {
            AppUser = await _httpService.Post<AppUser>("/api/users/authenticate", new { username, password });
            await _localStorageService.SetItem("user", AppUser);
        }

        public async Task Logout()
        {
            AppUser = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }
    }
}