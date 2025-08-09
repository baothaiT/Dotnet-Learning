using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS004_SwaggerUI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CS004_SwaggerUI.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<UserEntity>> GetAllUsersAsync();
    Task<UserEntity?> GetUserByIdAsync(string id);
    Task<UserEntity?> GetUserByUsernameAsync(string username);
    Task<UserEntity?> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserEntity>> GetUsersByStatusAsync(Status status);
    Task<UserEntity> CreateUserAsync(UserEntity user);
    Task<UserEntity?> UpdateUserAsync(UserEntity user);
    Task<bool> DeleteUserAsync(string id);
    Task<bool> UserExistsAsync(string id);
    Task<bool> UsernameExistsAsync(string username);
    Task<bool> EmailExistsAsync(string email);
    Task<int> GetUserCountAsync();
    Task<IEnumerable<UserEntity>> GetActiveUsersAsync();
}

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
    {
        return await _context.Users
            .OrderBy(u => u.CreatedAt)
            .ToListAsync();
    }

    public async Task<UserEntity?> GetUserByIdAsync(string id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<UserEntity?> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<UserEntity?> GetUserByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IEnumerable<UserEntity>> GetUsersByStatusAsync(Status status)
    {
        return await _context.Users
            .Where(u => u.Status == status)
            .OrderBy(u => u.CreatedAt)
            .ToListAsync();
    }

    public async Task<UserEntity> CreateUserAsync(UserEntity user)
    {
        if (user.Id == null)
        {
            user.Id = Guid.NewGuid().ToString();
        }
        
        if (user.CreatedAt == default)
        {
            user.CreatedAt = DateTime.UtcNow;
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<UserEntity?> UpdateUserAsync(UserEntity user)
    {
        var existingUser = await _context.Users.FindAsync(user.Id);
        if (existingUser == null)
        {
            return null;
        }

        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.PasswordHash = user.PasswordHash;
        existingUser.Status = user.Status;

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task<bool> DeleteUserAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }

        // Soft delete by setting status to Deleted
        user.Status = Status.Deleted;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UserExistsAsync(string id)
    {
        return await _context.Users.AnyAsync(u => u.Id == id);
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<int> GetUserCountAsync()
    {
        return await _context.Users.CountAsync();
    }

    public async Task<IEnumerable<UserEntity>> GetActiveUsersAsync()
    {
        return await _context.Users
            .Where(u => u.Status == Status.Active)
            .OrderBy(u => u.Username)
            .ToListAsync();
    }
}
