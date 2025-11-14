using GestAgro.Domain.Exceptions;
using GestAgro.Shared.DTOs.User;
using Microsoft.AspNetCore.Mvc;

namespace GestAgro.API.Controllers
{
    public partial class UserController
    {
        /// <summary>
        /// Cria um novo pré-cadastro no sistema.
        /// </summary>
        /// <param name="request">Os dados para a criação do pré-cadastro.</param>
        /// <param name="cancellationToken">Um token para monitorar solicitações de cancelamento.</param>
        /// <response code="201">Retorna o pré-cadastro recém-criado.</response>
        /// <response code="400">Ocorre se houver um erro de validação nos dados fornecidos (ex: nome, e-mail, telefone).</response>
        /// <response code="409">Ocorre se houver um conflito de negócio (ex: e-mail já existente).</response>
        /// <response code="500">Ocorre se um erro inesperado acontecer no servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateUserDto request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = await _service.CreateAsync(request, cancellationToken);
                // TODO: Adicionar o envio de e-mail de confirmação aqui.
                return CreatedAtAction(nameof(GetPending), new { id = dto.Id }, dto);
            }
            catch (DomainException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (DuplicateEmailException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocorreu um erro inesperado ao tentar criar o pré-cadastro.");
                return StatusCode(500, new { error = "Ocorreu um erro inesperado." });
            }
        }
    }
}