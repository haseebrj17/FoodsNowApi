using static FoodsNow.Core.Enum.Enums;

namespace FoodsNow.Core.RequestModels
{
    public class CommonRequest
    {
        public Guid? Id { get; set; }
        public bool? AddSides { get; set; }
        public List<Guid>? Ids { get; set; }
        public Guid? OrderId { get; set; }
        public OrderStatus? OrderStatus { get; set; }
        public Status? Status { get; set; }
    }
}
