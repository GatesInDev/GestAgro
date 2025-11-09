using GestAgro.Application.DTOs.EarlyRegister;

namespace GestAgro.Application.Services.UserService
{
    public partial class UserService
    {
        public async Task<IEnumerable<UserDto>> GetPendingAsync(CancellationToken cancellationToken = default)
        {
            var entities = await repository.GetPendingAsync(cancellationToken);
            return entities.Select(ToDto);
        }
    }
}
