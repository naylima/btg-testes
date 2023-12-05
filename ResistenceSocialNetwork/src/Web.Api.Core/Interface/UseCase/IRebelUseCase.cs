using src.Web.Api.Model;

namespace src.Web.Api.Core.Interface.UseCase
{
    public interface IRebelUseCase
    {
        bool InsertRebel(RebelRequest request);
        bool ReportRebelTraitor(long id, out string message);
        bool UpdateLocation(long id, LocationRequest location);
    }
}