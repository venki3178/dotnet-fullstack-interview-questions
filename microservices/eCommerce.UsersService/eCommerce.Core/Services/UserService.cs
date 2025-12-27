using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.UserRepositoryContracts;

namespace eCommerce.Core.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser user = await this.userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null) return null;

        return new AuthenticationResponse(
           user.UserId,  user.Email, user.Password, user.PersonName, user.Gender, "token", Success: true  );
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest registerRequest)
    {
        ApplicationUser applicationUser = new ApplicationUser();
        await this.userRepository.AddUser(registerRequest);
    }
}
