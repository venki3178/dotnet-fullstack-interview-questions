using eCommerce.Core.Entities;

namespace eCommerce.Core.UserRepositoryContracts;

/// <summary>
/// Contract to implementd by UserRepository
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Method to add a user to data store and return the added user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser> AddUser(ApplicationUser user);

    /// <summary>
    /// Mehtod to retrieve existing user by their email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser> GetUserByEmailAndPassword(string? email, string? password);
}
