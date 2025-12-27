using eCommerce.Core.DTO;

namespace eCommerce.Core.ServiceContracts;

public interface IUserService
{
    /// <summary>
    /// Method to handle user login and returns Authentication response.
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse> Login(LoginRequest loginRequest);

    /// <summary>
    /// Mehtod to handle User Registration and returns Authentication Response.
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse> Register(RegisterRequest registerRequest);
}
