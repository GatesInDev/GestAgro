using GestAgro.Domain.Entities;
using GestAgro.Domain.ValueObjects;

namespace GestAgro.Domain.Interfaces
{
    /// <summary>
    /// Define o contrato para gerenciar os dados do Usuário.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Recupera assincronamente um usuário pelo seu endereço de e-mail.
        /// </summary>
        /// <param name="email">O endereço de e-mail do usuário.</param>
        /// <param name="cancellationToken">Um token para solicitações de cancelamento.</param>
        /// <returns>
        /// Uma <see cref="Task"/> que representa a operação assíncrona.
        /// O resultado da tarefa contém o <see cref="User"/> se encontrado; caso contrário, <c>null</c>.
        /// </returns>
        Task<User?> GetByEmailAsync(Email email, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recupera assincronamente todos os usuários em estado pendente.
        /// </summary>
        /// <param name="cancellationToken">Um token para solicitações de cancelamento.</param>
        /// <returns>
        /// Uma <see cref="Task"/> que representa a operação assíncrona.
        /// O resultado da tarefa contém um <see cref="IEnumerable{T}"/> de <see cref="User"/> pendentes.
        /// </returns>
        Task<IEnumerable<User>> GetPendingAsync(CancellationToken cancellationToken = default);
    }
}