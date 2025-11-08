namespace GestAgro.Domain.Enums
{
    /// <summary>
    /// Enumera os possíveis status de um Usuário no sistema.
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// O usuário está pendente, aguardando ativação ou confirmação.
        /// </summary>
        Pending,

        /// <summary>
        /// O usuário está ativo e pode usar o sistema.
        /// </summary>
        Active,

        /// <summary>
        /// O usuário foi cancelado ou desativado.
        /// </summary>
        Canceled,

        /// <summary>
        /// O usuário confirmou o e-mail, mas pode não estar ativo ainda.
        /// </summary>
        Confirmed 
    }
}