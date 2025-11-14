namespace GestAgro.Domain.Interfaces;

/// <summary>
///     Define um contrato genérico de repositório para operações CRUD básicas.
/// </summary>
/// <typeparam name="TR">O tipo da entidade (classe) que este repositório manipula.</typeparam>
public interface IRepository<TR> where TR : class
{
    /// <summary>
    ///     Adiciona uma nova entidade de forma assíncrona ao banco de dados.
    /// </summary>
    /// <param name="entity">A entidade a ser adicionada.</param>
    /// <param name="cancellationToken">O token para monitorar solicitações de cancelamento.</param>
    Task AddAsync(TR entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Atualiza uma entidade existente de forma assíncrona no banco de dados.
    /// </summary>
    /// <param name="entity">A entidade a ser atualizada.</param>
    /// <param name="cancellationToken">O token para monitorar solicitações de cancelamento.</param>
    Task UpdateAsync(TR entity, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Obtém uma entidade de forma assíncrona pelo seu identificador (ID).
    /// </summary>
    /// <param name="id">O ID (Guid) da entidade a ser recuperada.</param>
    /// <param name="cancellationToken">O token para monitorar solicitações de cancelamento.</param>
    /// <returns>A tarefa que representa a operação assíncrona. O resultado contém a entidade encontrada, ou null.</returns>
    Task<TR?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Obtém todas as entidades de forma assíncrona.
    /// </summary>
    /// <param name="cancellationToken">O token para monitorar solicitações de cancelamento.</param>
    /// <returns>A tarefa que representa a operação assíncrona. O resultado contém uma coleção de todas as entidades, ou null.</returns>
    Task<IEnumerable<TR>?> GetAllAsync(CancellationToken cancellationToken = default);
}