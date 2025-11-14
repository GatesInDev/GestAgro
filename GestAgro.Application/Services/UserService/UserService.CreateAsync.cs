using GestAgro.Domain.Entities;
using GestAgro.Domain.Enums;
using GestAgro.Domain.Exceptions;
using GestAgro.Domain.ValueObjects;
using GestAgro.Shared.DTOs.User;

namespace GestAgro.Application.Services.UserService;

public partial class UserService
{
    public async Task<UserDto> CreateAsync(CreateUserDto request, CancellationToken cancellationToken = default)
    {
        var dataByEmail = await repository.GetByEmailAsync(Email.Parse(request.Email), cancellationToken);
        if (dataByEmail is not null && dataByEmail.Status == UserStatus.Confirmed)
            throw new DuplicateEmailException(nameof(request.Email), "O e-mail já foi pré-cadastrado.");

        var entity = User.Create
        (
            request.Name,
            request.Email,
            request.Phone,
            request.Region
        );

        await repository.AddAsync(entity, cancellationToken);
        return ToDto(entity);
    }
}