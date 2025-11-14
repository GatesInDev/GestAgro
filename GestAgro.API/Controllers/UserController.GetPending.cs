using GestAgro.Shared.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace GestAgro.API.Controllers;

public partial class UserController
{
    /// <summary>
    ///     Busca todos os pré-cadastros que ainda estão com status pendente.
    /// </summary>
    /// <param name="cancellationToken">Um token para monitorar solicitações de cancelamento.</param>
    /// <response code="200">Retorna a lista de pré-cadastros pendentes.</response>
    /// <response code="500">Ocorre se um erro inesperado acontecer no servidor.</response>
    [HttpGet("pending")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetPending(CancellationToken cancellationToken)
    {
        try
        {
            var list = await _service.GetPendingAsync(cancellationToken);
            return Ok(list);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocorreu um erro inesperado ao tentar ler os cadastros pendentes.");
            return StatusCode(500, new { error = "Ocorreu um erro inesperado ao processar a solicitação." });
        }
    }
}