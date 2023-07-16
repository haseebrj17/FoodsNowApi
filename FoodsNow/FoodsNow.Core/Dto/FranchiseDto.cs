namespace FoodsNow.Core.Dto
{
    public class FranchiseDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public bool IsOpen { get; set; }
        public bool IsCoverageArea { get; set; }
    }
}
