namespace FoodsNow.Core.Dto
{
    public class DishOfDayDto
    {
        public required string ImageUrl { get; set; }
        public Guid? ProductId { get; set; }
    }
}
