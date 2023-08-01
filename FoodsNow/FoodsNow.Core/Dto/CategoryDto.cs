namespace FoodsNow.Core.Dto
{
    public class CategoryDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string AppLogo { get; set; }
        public required string Cover { get; set; }
        public required string Thumbnail { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
    }
}
