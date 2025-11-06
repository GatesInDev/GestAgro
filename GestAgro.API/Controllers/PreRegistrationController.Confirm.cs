using Microsoft.AspNetCore.Mvc;

namespace GestAgro.API.Controllers
{
    public partial class PreRegistrationController
    {
        /// <summary>
        /// Method to confirm a pre-registration using the provided ID and token.
        /// </summary>
        /// <param name="id">Unique identifier of user.</param>
        /// <param name="token">User token for validation.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("confirm")]
        public async Task<IActionResult> Confirm([FromQuery] Guid id, [FromQuery] string token, CancellationToken cancellationToken)
        {
            var ok = await _service.ConfirmAsync(id, token, cancellationToken);
            if (!ok) return BadRequest(new { error = "Unable to confirm." });
            return Ok();
        }
    }
}
