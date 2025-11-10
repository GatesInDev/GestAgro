using GestAgro.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GestAgro.API.Controllers
{
    public partial class UserController
    {
        /// <summary>
        /// Confirma um pré-cadastro usando o ID e o token fornecidos.
        /// </summary>
        /// <param name="id">O identificador único do pré-cadastro.</param>
        /// <param name="token">O token de validação enviado ao usuário.</param>
        /// <param name="cancellationToken">Um token para monitorar solicitações de cancelamento.</param>
        /// <response code="200">Confirmação bem-sucedida.</response>
        /// <response code="400">O token é inválido, expirou ou o usuário já está confirmado.</response>
        /// <response code="404">Nenhum pré-cadastro foi encontrado com o ID fornecido.</response>
        /// <response code="500">Ocorreu um erro interno inesperado no servidor.</response>
        [HttpPost("confirm")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Confirm([FromQuery] Guid id, [FromQuery] string token, CancellationToken cancellationToken)
        {
            try
            {
                await _service.ConfirmAsync(id, token, cancellationToken);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (DomainException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro inesperado ao tentar confirmar o pré-cadastro.");
                return StatusCode(500, new { error = "Ocorreu um erro inesperado." });
            }
        }
    }
}