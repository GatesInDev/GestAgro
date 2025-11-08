using GestAgro.Application.DTOs.EarlyRegister;
using GestAgro.Application.Interfaces;
using GestAgro.Domain.Entities;
using GestAgro.Domain.Exceptions;
using GestAgro.Domain.Interfaces;
using GestAgro.Domain.ValueObjects;

namespace GestAgro.Application.Services;

public class UserService(IUserRepository repository) : IUserService
{

    public async Task<EarlyRegisterDto> CreateAsync(CreateEarlyRegisterRequestDto request, CancellationToken cancellationToken = default)
    {
        if (request is null) 
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Name)) 
            throw new ArgumentNullException(nameof(request.Name), "Name is required.");

        var exists = await repository.GetByEmailAsync(Email.Parse(request.Email), cancellationToken);
        if (exists is not null)
            throw new InvalidOperationException("E-mail already registered.");

        var region = CountryCode.Parse(request.Region);
        if (region is null)
            throw new ArgumentException("Region isn't valid.", nameof(request.Region));

        try
        {
            var entity = User.Create(request.Name.Trim(), request.Email.Trim().ToLowerInvariant(), request.Phone, request.Region);
            await repository.AddAsync(entity, cancellationToken);
            return ToDto(entity);
        }
        catch (Exception ex) when (ex is ArgumentException or DomainException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new Exception("Não foi possível completar o pré-cadastro.", ex);
        }

    }

    public async Task<bool> ConfirmAsync(Guid id, string token, CancellationToken cancellationToken = default)
    {
        var entity = await repository.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;

        try
        {
            entity.Confirm(token);
            await repository.UpdateAsync(entity, cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<EarlyRegisterDto>> GetPendingAsync(CancellationToken cancellationToken = default)
    {
        var entities = await repository.GetPendingAsync(cancellationToken);
        return entities.Select(ToDto);
    }

    private static EarlyRegisterDto ToDto(User e) =>
        new EarlyRegisterDto()
        {
            Id = e.Id,
            Name = e.Name,
            PhoneNumber = e.PhoneNumber,
            Email = e.Email,
            Status = e.Status,
            CreatedAt = e.CreatedAt,
            ConfirmedAt = e.ConfirmedAt
        };
}