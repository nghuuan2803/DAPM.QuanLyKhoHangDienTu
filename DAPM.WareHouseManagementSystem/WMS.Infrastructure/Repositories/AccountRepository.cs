using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WMS.Application.Contracts;
using WMS.Application.DTOs.Requests.Account;
using WMS.Application.DTOs.Responses;
using WMS.Application.DTOs.Responses.Account;
using WMS.Application.Extensions;
using WMS.Domain;
using WMS.Domain.Entities.Authentication;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories
{
    public class AccountRepository
        (RoleManager<IdentityRole> roleManager,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IConfiguration config,
        AppDbContext context) : IAccount
    {

        private async Task<User> FindUserByEmailAsync(string email)
            => await userManager.FindByEmailAsync(email);

        private async Task<IdentityRole> FindRoleByNameAsync(string roleName)
            => await roleManager.FindByNameAsync(roleName);

        private static string GenerateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        private async Task<string> GenerateTokenAsync(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var userClaim = new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, (await userManager.GetRolesAsync(user)).FirstOrDefault().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: config["JWT:Issuer"]!,
                    audience: config["JWT:Audience"]!,
                    claims: userClaim,
                    expires: DateTime.Now.AddMinutes(int.Parse(config["JWT:Expire"]!)),
                    signingCredentials: credentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {
                return null!;
            }
        }

        private async Task<GeneralResponse> AssignUserToRole(User user, IdentityRole role)
        {
            if (user is null || role is null)
                return new GeneralResponse(false, "Model state cannot be empty!");
            if (await FindRoleByNameAsync(role.Name) == null)
                await CreateRoleAsync(role.Adapt(new CreateRoleDTO()));

            IdentityResult result = await userManager.AddToRoleAsync(user, role.Name);
            string error = CheckResponse(result);
            if (!string.IsNullOrEmpty(error))
                return new GeneralResponse(false, error);
            else
                return new GeneralResponse(true, $"{user.UserName} assigned to {role.Name} role ");
        }

        private string CheckResponse(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return string.Join(Environment.NewLine, errors);
            }
            return null!;
        }

        public async Task<GeneralResponse> ChangeUserRoleAsync(ChangeUserRoleDTO model)
        {
            //var user = await FindUserByEmailAsync(model.UserMail);
            //if (user is null) return new GeneralResponse(false, "Không tìm thấy tài khoản!");
            //if (await FindRoleByNameAsync(model.RoleName) is null) return new GeneralResponse(false, "Không tìm thấy role!");
            throw new NotImplementedException();
            //thiet ke sai model: thieu role cu
        }

        public async Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model)
        {
            try
            {
                if (await FindUserByEmailAsync(model.Email) != null)
                    return new GeneralResponse(false, "Tên đăng nhập đã được sử dụng!");

                var user = new User
                {
                    UserName = model.UserName,
                    NormalizedUserName = model.UserName.ToUpper(),
                    Email = model.Email,
                    NormalizedEmail = model.Email.ToUpper(),
                    CreatedOn = DateTime.Now
                };
                var result = await userManager.CreateAsync(user, model.Password);
                string error = CheckResponse(result);
                if (!string.IsNullOrEmpty(error))
                    return new GeneralResponse(false, error);
                var (succeeded, message) = await AssignUserToRole(user, new IdentityRole() { Name = model.Role });
                return new GeneralResponse(succeeded, message);
            }
            catch (Exception ex)
            {
                return new GeneralResponse(false, ex.Message);
            }
        }
        public async Task<LoginResponse> LoginAsync(LoginDTO model)
        {
            try
            {
                var user =await FindUserByEmailAsync(model.Email);
                if (user is null)
                    return new LoginResponse(false, "Tên đăng nhập không tồn tại!");
                SignInResult result;
                try
                {
                    result = await signInManager.CheckPasswordSignInAsync(user,model.Password,false);
                }
                catch (Exception)
                {
                    return new LoginResponse(false, "Mật khẩu không chính xác");
                }
                if(!result.Succeeded)
                    return new LoginResponse(false, "Mật khẩu không chính xác");

                string jwtToken = await GenerateTokenAsync(user);
                string refreshToken = GenerateRefreshToken();
                if (string.IsNullOrEmpty(jwtToken) || string.IsNullOrEmpty(refreshToken))
                    return new LoginResponse(false, "Đã xảy ra lỗi, vui lòng liên hệ quản trị hệ thống!");
                else
                {
                    var saveResult = await SaveRefreshToken(user.Id, refreshToken);
                    if (saveResult.Succeeded)
                        return new LoginResponse(true, $"{user.UserName} đã đăng nhập thành công", jwtToken, refreshToken);
                    else
                        return new LoginResponse();
                }
            }
            catch (Exception ex)
            {
                return new LoginResponse(false, ex.Message);
            }
        }

        public async Task CreateAdminAsync()
        {
            try
            {
                if ((await FindRoleByNameAsync(Constant.Role.Admin)) != null) return;
                var admin = new CreateAccountDTO
                {
                    UserName = "Admin",
                    Password = "Admin@123",
                    Email = "admin@admin.com",
                    Role = Constant.Role.Admin
                };
                await CreateAccountAsync(admin);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GeneralResponse> CreateRoleAsync(CreateRoleDTO model)
        {
            var result = await roleManager.CreateAsync(model.Adapt<IdentityRole>());
            if (result.Succeeded)
                return new GeneralResponse(true, "Create role successfuly!");
            return new GeneralResponse();
        }

        public async Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
            => (await roleManager.Roles.ToListAsync()).Adapt<IEnumerable<GetRoleDTO>>();

        public async Task<IEnumerable<GetUsersWithRoleDTO>> GetUsersWithRolesAsync()
        {
            var allUsers = await userManager.Users.ToListAsync();
            if (allUsers is null) return null!;
            var list = new List<GetUsersWithRoleDTO>();
            foreach (var user in allUsers)
            {
                var getUserRole = (await userManager.GetRolesAsync(user)).FirstOrDefault();
                var getRoleInfo = await roleManager.Roles.FirstOrDefaultAsync(r => r.Name.ToLower() == getUserRole.ToLower());
                list.Add(new GetUsersWithRoleDTO
                {
                    Name = user.UserName,
                    Email = user.Email,
                    RoleId = getRoleInfo.Id,
                    RoleName = getRoleInfo.Name
                });
            }
            return list;
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {
            var token = await context.RefreshTokens.FirstOrDefaultAsync(t=>t.Token==model.Token);
            if(token == null) return new LoginResponse();
            var user = await userManager.FindByIdAsync(token.UserId);
            string newToken = await GenerateTokenAsync(user);
            string newRefreshToken = GenerateRefreshToken();
            var saveResult = await SaveRefreshToken(user.Id, newRefreshToken);
            if(saveResult.Succeeded)
                return new LoginResponse(true, $"{user.UserName} đã đăng nhập thành công", newToken, newRefreshToken);
            return new LoginResponse();
        }
        private async Task<GeneralResponse> SaveRefreshToken(string userId, string token)
        {
            try
            {
                var user = await context.RefreshTokens.FirstOrDefaultAsync(t=> t.UserId == userId);
                if(user == null)
                    context.RefreshTokens.Add(new RefreshToken { UserId = userId, Token = token });
                else
                    user.Token = token;
                await context.SaveChangesAsync();
                return new GeneralResponse(true, null!);
            }
            catch (Exception ex)
            {
                return new GeneralResponse(false, ex.Message);
            }
        }
    }
}
