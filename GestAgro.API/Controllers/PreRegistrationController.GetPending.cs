using Microsoft.AspNetCore.Mvc;

namespace GestAgro.API.Controllers
{
    public partial class PreRegistrationController
    {
        [HttpGet("pending")]
        public async Task<IActionResult> GetPending(CancellationToken cancellationToken)
        {
            var list = await _service.GetPendingAsync(cancellationToken);
            return Ok(list);
        }
    }
}
