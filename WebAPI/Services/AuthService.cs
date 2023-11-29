using System.ComponentModel.DataAnnotations;
using Domain.Models;
using EfcDataAccess;
using Microsoft.EntityFrameworkCore;


namespace WebAPI.Services;

public class AuthService : IAuthService
{
    private readonly PostContext dbContext;

    public AuthService(PostContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<User> ValidateUser(string username, string password)
    {
        User? existingUser = await dbContext.Users.Where(u => u.Username == username && u.Password == password)
            .FirstOrDefaultAsync();
                
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }

    public async Task RegisterUser(User user)
    {

        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        //return Task.CompletedTask;
    }
}