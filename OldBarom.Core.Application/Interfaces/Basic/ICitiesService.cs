using OldBarom.Core.Domain.Entities.Basic;
namespace OldBarom.Core.Application.Interfaces.Basic;
public interface ICitiesService
{
    IEnumerable<Cities> GetCities();
}