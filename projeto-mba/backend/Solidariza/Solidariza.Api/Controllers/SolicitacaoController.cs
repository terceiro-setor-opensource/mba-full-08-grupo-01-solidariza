using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solidariza.Application.Interfaces;
using Solidariza.Domain.DTO;
using Solidariza.Domain.Interfaces;

namespace Solidariza.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoService _solicitacaoService;

        public SolicitacaoController(ISolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }

        [HttpGet("list/solicitacoes")]
        public async Task<IActionResult> GetSolitacoes([FromQuery] FilterKeywordDTO filter)
        {
            var result = await _solicitacaoService.GetListFiltered(filter);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}