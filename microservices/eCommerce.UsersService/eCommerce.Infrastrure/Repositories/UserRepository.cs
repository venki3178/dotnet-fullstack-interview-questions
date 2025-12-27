using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.UserRepositoryContracts;

namespace eCommerce.Infrastrure.Repositories;

public class UserRepository : IUserRepository
{
    /// <summary>
    /// Method to add a user to data store and return the added user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<ApplicationUser> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        return user;
    }

        /// <summary>
    /// Mehtod to retrieve existing user by their email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public async Task<ApplicationUser> GetUserByEmailAndPassword(string? email, string? password)
    {
        return new ApplicationUser
        { 
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Person Name",
            Gender = GenderEnum.Male.ToString()
        };
    }
}
