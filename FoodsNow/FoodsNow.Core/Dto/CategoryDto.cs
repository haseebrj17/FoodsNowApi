﻿namespace FoodsNow.Core.Dto
{
    public class CategoryDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string AppLogo { get; set; }
    }
}