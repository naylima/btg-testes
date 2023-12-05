using System.Collections.Generic;
using src.Web.Api.Core.Dto;

namespace src.Web.Api.Core.Interface.UseCase
{
    public interface IReportUseCase
    {
        string TraitorsPercentage();
        string RebelsPercentage();
        string LostPoints();
        List<ResourceAverageDto> Average();

    }
}