using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using src.Web.Api.Core.Interface.UseCase;
using src.Web.Api.Model;

namespace src.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RebelController : ControllerBase
    {
        private readonly IRebelUseCase _rebelUseCase;
        private readonly ITradeResourcesUseCase _tradeResourcesUseCase;

        public RebelController(IRebelUseCase rebelUseCase, ITradeResourcesUseCase tradeResourcesUseCase)
        {
            _rebelUseCase = rebelUseCase;
            _tradeResourcesUseCase = tradeResourcesUseCase;
        }
        
        /// <summary>
        /// InsertRebel responsável por inserir novo rebelde com sua localização e inventário
        /// </summary>
        [HttpPost]
        public ActionResult InsertRebel([FromBody] RebelRequest request)
        {
            if (_rebelUseCase.InsertRebel(request))
            {
                return new JsonResult(request) { StatusCode = StatusCodes.Status201Created };
            }

            return new JsonResult(new { Error = "Unexpected error" }) { StatusCode = StatusCodes.Status500InternalServerError };
        }

        /// <summary>
        /// UpdateLocation responsável por atualizar a localização do rebelde
        /// </summary>
        [HttpPut("Location")]
        public ActionResult UpdateLocation(long id, [FromBody] LocationRequest location)
        {
            if (_rebelUseCase.UpdateLocation(id, location))
            {
                return new JsonResult(location) { StatusCode = StatusCodes.Status200OK };
            }

            return new JsonResult(new { Error = "Rebel not found" }) { StatusCode = StatusCodes.Status400BadRequest };
        }

        /// <summary>
        /// ReportRebelTraitor responsável por atualizar o status de traidor do rebelde
        /// </summary>
        [HttpPut("ReportTraitor")]
        public ActionResult ReportRebelTraitor(long id)
        {
            if (_rebelUseCase.ReportRebelTraitor(id, out string message))
            {
                return new JsonResult(new { IdTraitor = id }) { StatusCode = StatusCodes.Status200OK };
            }

            return new JsonResult(message) { StatusCode = StatusCodes.Status400BadRequest };
        }

        /// <summary>
        /// TradeResources responsável por fazer as negociações entre os rebeldes
        /// </summary>
        [HttpPut("TradeResources")]
        public ActionResult TradeResources([FromBody] TradeResourcesRequest request)
        {
            if (_tradeResourcesUseCase.TradeResources(request, out string message))
            {
                return new JsonResult(request) { StatusCode = StatusCodes.Status200OK };
            }

            return new JsonResult(message) { StatusCode = StatusCodes.Status400BadRequest };
        }
    }
}