using GestAgro.Application.DTOs.EarlyRegister;
using GestAgro.Application.Extensions.EnumExtensions;
using GestAgro.Application.Interfaces;
using GestAgro.Domain.Entities.EarlyRegister;
using GestAgro.Domain.Exceptions;

namespace GestAgro.Application.Services.EarlyRegister;

public class EarlyRegisterService : IEarlyRegisterService
{
    private readonly IEarlyRegisterRepository _repository;

    public EarlyRegisterService(IEarlyRegisterRepository repository)
    {
        _repository = repository;
    }

    public async Task<EarlyRegisterDTO> CreateAsync(CreateEarlyRegisterRequestDTO request, CancellationToken cancellationToken = default)
    {
        if (request is null) 
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Name)) 
            throw new ArgumentNullException(nameof(request.Name), "Name is required.");

        var exists = await _repository.GetByEmailAsync(request.Email, cancellationToken);
        if (exists is not null)
            throw new InvalidOperationException("E-mail already registered.");

        var region = request.Region.GetDescription();
        if (region is null)
            throw new ArgumentException("Region isn't valid.", nameof(request.Region));

        try
        {
            var entity = User.Create(request.Name.Trim(), request.Email.Trim().ToLowerInvariant(), request.Phone, region);
            await _repository.AddAsync(entity, cancellationToken);
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
        var entity = await _repository.GetByIdAsync(id, cancellationToken);
        if (entity == null) return false;

        try
        {
            entity.Confirm(token);
            await _repository.UpdateAsync(entity, cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<EarlyRegisterDTO>> GetPendingAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _repository.GetPendingAsync(cancellationToken);
        return entities.Select(ToDto);
    }

    private static EarlyRegisterDTO ToDto(User e) =>
        new EarlyRegisterDTO()
        {
            Id = e.Id,
            Name = e.Name,
            Email = e.Email,
            Status = e.Status,
            CreatedAt = e.CreatedAt,
            ConfirmedAt = e.ConfirmedAt
        };
}