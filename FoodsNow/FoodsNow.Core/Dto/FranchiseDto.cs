namespace FoodsNow.Core.Dto
{
    public class FranchiseDto
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Address { get; set; }
        public required string ZipCode { get; set; }
        public required string ContactNumber { get; set; }
        public required string OpeningTime { get; set; }
        public required string ClosingTime { get; set; }
        public required decimal Latitude { get; set; }
        public required decimal Longitude { get; set; }
        public required float CoverageAreaInMeters { get; set; }
    }
}
