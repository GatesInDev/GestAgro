using GestAgro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestAgro.API.Controllers
{
    /// <summary>
    /// Controller for managing pre-registrations (early registrations).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public partial class PreRegistrationController : ControllerBase
    {
        /// <summary>
        /// Instance of the early registration service.
        /// </summary>
        private readonly IUserService _service;

        /// <summary>
        /// Dependency injection constructor.
        /// </summary>
        /// <param name="service"></param>
        public PreRegistrationController(IUserService service)
        {
            _service = service;
        }
    }
}