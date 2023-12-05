using src.Web.Api.Model;

namespace src.Web.Api.Core.Interface.UseCase
{
    public interface ITradeResourcesUseCase
    {
        bool TradeResources(TradeResourcesRequest request, out string message);
    }
}