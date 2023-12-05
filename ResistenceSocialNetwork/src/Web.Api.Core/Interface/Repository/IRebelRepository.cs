
using System.Collections.Generic;
using src.Web.Api.Core.Dto;
using src.Web.Api.Infrastructure.EntityFramework.Entity;

namespace src.Web.Api.Core.Interface.Repository
{
    public interface IRebelRepository
    {
        bool InsertRebel(Rebel rebel);
        Rebel SelectRebel(long id);
        Rebel SelectRebelLocation(long id);
        Rebel SelectRebelInventory(long id);
        bool ReportRebelTraitor(Rebel rebel);
        bool UpdateRebelLocation(Rebel rebel, Location localtion);
        List<RebelCountDto> SelectCountRebel();
    }
}