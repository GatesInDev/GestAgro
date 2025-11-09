using GestAgro.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAgro.Application.Services.UserService
{
    public partial class UserService
    {
        public async Task ConfirmAsync(Guid id, string token, CancellationToken cancellationToken = default)
        {
            var entity = await repository.GetByIdAsync(id, cancellationToken);
            if (entity is null)
                throw new NotFoundException($"Registro com ID {id} não encontrado.");

            entity.Confirm(token);
            await repository.UpdateAsync(entity, cancellationToken);
        }
    }
}
