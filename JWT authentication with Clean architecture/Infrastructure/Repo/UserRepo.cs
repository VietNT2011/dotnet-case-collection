using Application.Contracts;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo
{
    internal class UserRepo(AppDBContext context) : IUser
    {
        private readonly AppDBContext _context = context;

        public async Task<LoginResponse> LoginAsync(LoginDTO loginDTO)
        {
            var getUser = await FindUserVyEmailAsync(loginDTO.Email);
            if (getUser == null) return new LoginResponse(false, "User not found", null);
            
            bool checkPassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, getUser.Password);
            if(checkPassword)
                return new LoginResponse(true, "Login successful", GenerateJWTToken(getUser));
            else
                return new LoginResponse(false, "Invalid credentials", null);
        }

        private async Task<ApplicationUser> FindUserVyEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<RegistrationResponse> RegisterAsync(RegisterUserDTO registerUserDTO)
        {
            var getUser = await FindUserVyEmailAsync(registerUserDTO.Email);
            if (getUser != null) return new RegistrationResponse(false, "User already exists");
            _context.Users.Add(new ApplicationUser
            {
                Name = registerUserDTO.Name,
                Email = registerUserDTO.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerUserDTO.Password)
            });
            await _context.SaveChangesAsync();
            return new RegistrationResponse(true, "User registered successfully");
        }
    }
}
