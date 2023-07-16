using FoodsNow.Core.Dto;

namespace FoodsNow.Services.Interfaces
{
    public interface IFranchiseService
    {
        List<FranchiseDto> GetFranhisesByArea(decimal latitude, decimal longitude);
    }
}
