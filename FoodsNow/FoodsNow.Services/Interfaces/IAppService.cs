using FoodsNow.Core.Dto;

namespace FoodsNow.Services.Interfaces
{
    public interface IAppService
    {
        Task<HomeDataDto> GetAppHomeData(decimal latitude, decimal longitude);
    }
}
