using GestAgro.Domain.Entities;
using GestAgro.Domain.ValueObjects;

namespace GestAgro.Domain.Interfaces
{
    /// <summary>
    /// Define o contrato para gerenciar os dados do Usuário.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Adiciona assincronamente um novo usuário ao repositório de dados.
        /// </summary>
        /// <param name="userData">A entidade do usuário a ser adicionada.</param>
        /// <param name="cancellationToken">Um token para solicitações de cancelamento.</param>
        /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
        Task AddAsync(User userData, CancellationToken cancellationToken = default);

        /// <summary>
        /// Recupera assincronamente um usuário pelo seu identificador único.
        /// </summary>
        /// <param name="id">O identificador único do usuário.</param>
        /// <param name="cancellationToken">Um token para solicitações de cancelamento.</param>
        /// <returns>
        /// Uma <see cref="Task"/> que representa a operação assíncrona.
        /// O resultado da tarefa contém o <see cref="User"/> se encontrado; caso contrário, <c>null</c>.
        /// </returns>
        Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

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

        /// <summary>
        /// Atualiza assincronamente as informações de um usuário existente.
        /// </summary>
        /// <param name="userData">A entidade do usuário com as informações atualizadas.</param>
        /// <param name="cancellationToken">Um token para solicitações de cancelamento.</param>
        /// <returns>Uma <see cref="Task"/> que representa a operação assíncrona.</returns>
        Task UpdateAsync(User userData, CancellationToken cancellationToken = default);
    }
}