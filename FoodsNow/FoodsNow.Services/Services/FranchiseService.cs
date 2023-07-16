using FoodsNow.Core.Dto;
using FoodsNow.Services.Interfaces;

namespace FoodsNow.Services.Services
{
    public class FranchiseService : IFranchiseService
    {
        public List<FranchiseDto> GetFranhisesByArea(decimal latitude, decimal longitude)
        {
            throw new NotImplementedException();
        }
    }
}
