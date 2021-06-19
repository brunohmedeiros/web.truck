using Microsoft.AspNetCore.Mvc;
using Web.Truck.Domain.DTOs.Caminhao;
using Web.Truck.Domain.Interfaces.Services;
using Web.Truck.Domain.Interfaces.Utils;

namespace Web.Truck.API.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaminhaoController : BaseController
    {
        private readonly ICaminhaoService _caminhaoService;

        public CaminhaoController(ICaminhaoService caminhaoService, INotificationContext noficationContext) : base(noficationContext)
        {
            _caminhaoService = caminhaoService;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return ResponseOk(_caminhaoService.ObterTodos());
        }

        [HttpPost("salvar")]
        public IActionResult Salvar([FromBody] CaminhaoDTO CaminhaoDTO)
        {
            _caminhaoService.Adicionar(CaminhaoDTO);
            return ResponseOk();
        }

        [HttpPut("atualizar")]
        public IActionResult Atualizar([FromBody] CaminhaoUpdateDTO CaminhaoUpdateDTO)
        {
            return ResponseOk(_caminhaoService.Atualizar(CaminhaoUpdateDTO));
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _caminhaoService.Excluir(id);
            return ResponseOk();
        }

    }
}
