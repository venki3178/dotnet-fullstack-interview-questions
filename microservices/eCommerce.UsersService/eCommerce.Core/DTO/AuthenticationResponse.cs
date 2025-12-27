namespace eCommerce.Core.DTO;

public record AuthenticationResponse(
    string? UserId,
    string? Email,
    string? Password,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success);
