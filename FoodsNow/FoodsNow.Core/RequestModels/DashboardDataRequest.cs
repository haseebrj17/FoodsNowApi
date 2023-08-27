namespace FoodsNow.Core.RequestModels
{
    public class CommonRequest
    {
        public Guid? Id { get; set; }
        public List<Guid>? Ids { get; set; }
    }
}
