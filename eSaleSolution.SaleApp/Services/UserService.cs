using eSaleSolution.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eSaleSolution.SaleApp.Services
{
    public interface IUserService
    {
        Task<IEnumerable<AppUser>> GetAll();
    }

    public class UserService : IUserService
    {
        private IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<AppUser>> GetAll()
        {
            return await _httpService.Get<IEnumerable<AppUser>>("/users");
        }
    }
}