using GestAgro.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestAgro.API.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar os pré-cadastros (registros antecipados).
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public partial class UserController : ControllerBase
    {
        /// <summary>
        /// Instância do logger para registrar eventos e erros.
        /// </summary>
        private readonly ILogger<UserController> _logger;

        /// <summary>
        /// Instância do serviço de usuário (usado para o pré-cadastro).
        /// </summary>
        private readonly IUserService _service;

        /// <summary>
        /// Construtor principal para injeção de dependência.
        /// </summary>
        /// <param name="service">A instância injetada do serviço de usuário.</param>
        /// <param name="logger">A instância injetada do logger.</param>
        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}