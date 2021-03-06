﻿using System.Collections.Generic;

namespace VibbraTest.Domain.Categories.Dtos
{
    public class CategoryListDto
    {
        public CategoryListDto(List<CategoryDto> customers)
        {
            Categories = customers;
        }

        public int Count => Categories.Count;
        public List<CategoryDto> Categories { get; set; }
    }
}
