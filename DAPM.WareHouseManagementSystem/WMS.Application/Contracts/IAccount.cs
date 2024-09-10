using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Application.DTOs.Requests.Account;
using WMS.Application.DTOs.Responses;
using WMS.Application.DTOs.Responses.Account;

namespace WMS.Application.Contracts
{
    public interface IAccount
    {
        Task CreateAdminAsync();
        Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model);
        Task<LoginResponse> LoginAsync(LoginDTO model);
        Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model);
        Task<IEnumerable<GetRoleDTO>> GetRolesAsync();
        Task<IEnumerable<GetUsersWithRoleDTO>> GetUsersWithRolesAsync();
        Task<GeneralResponse> ChangeUserRoleAsync(ChangeUserRoleDTO model);
        Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model);
    }
}
