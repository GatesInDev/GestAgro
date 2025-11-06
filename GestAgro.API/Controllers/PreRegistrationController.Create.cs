using GestAgro.Application.DTOs.EarlyRegister;
using Microsoft.AspNetCore.Mvc;

namespace GestAgro.API.Controllers
{
    public partial class PreRegistrationController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEarlyRegisterRequestDTO request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = await _service.CreateAsync(request, cancellationToken);
                // Retorna 201 com id e token não exposto — token fica na entidade (para enviar por e-mail, implementar envio)
                return CreatedAtAction(nameof(GetPending), new { id = dto.Id }, dto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
        }
    }
}
