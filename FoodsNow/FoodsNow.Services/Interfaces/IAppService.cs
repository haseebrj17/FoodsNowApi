using FoodsNow.Core.Dto;

namespace FoodsNow.Services.Interfaces
{
    public interface IAppService
    {
        Task<HomeDataDto> GetHomeData(decimal latitude, decimal longitude);
    }
}
