using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Web.Api.Core.Interface.UseCase;

namespace src.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportUseCase _reportUseCase;

        public ReportsController(IReportUseCase reportUseCase)
        {
            _reportUseCase = reportUseCase;
        }

        /// <summary>
        /// GetTraitors responsável por extrair porcentagem de traidores
        /// </summary>
        [HttpGet("GetTraitors")]
        public IActionResult GetTraitors()
        {
            return new JsonResult(new { Report = _reportUseCase.TraitorsPercentage() }) { StatusCode = StatusCodes.Status200OK };
        }

        /// <summary>
        /// GetRebels responsável por extrair porcentagem de rebeldes
        /// </summary>
        [HttpGet("GetRebels")]
        public IActionResult GetRebels()
        {
            return new JsonResult(new { Report = _reportUseCase.RebelsPercentage() }) { StatusCode = StatusCodes.Status200OK };
        }

        /// <summary>
        /// GetLostPoints responsável por extrair quantidade de pontos perdidos pelos traidores
        /// </summary>
        [HttpGet("GetLostPoints")]
        public IActionResult GetLostPoints()
        {
            return new JsonResult(new { Report = _reportUseCase.LostPoints() }) { StatusCode = StatusCodes.Status200OK };
        }

        /// <summary>
        /// GetAverageResources responsável por extrair a média de recursos por rebelde
        /// </summary>
        [HttpGet("GetAverageResources")]
        public IActionResult GetAverageResources()
        {
            return new JsonResult(_reportUseCase.Average()) { StatusCode = StatusCodes.Status200OK };
        }
        
    }
}