﻿using MovieProject.Model.Dtos.Categories;
using MovieProject.Model.Entities;

namespace MovieProject.Service.Mappers.Categories;

public sealed class ManuelCategoryMapper : ICategoryMapper
{
    public Category ConvertToEntity(CategoryAddRequestDto dto)
    {
        return new Category
        {
            Name = dto.Name
        };
    }

    public Category ConvertToEntity(CategoryUpdateRequestDto dto)
    {
        return new Category
        {
            Id = dto.Id,
            Name = dto.Name
        };
    }

    public CategoryResponseDto ConvertToResponse(Category category)
    {
        return new CategoryResponseDto(category.Id, category.Name);
    }

    public List<CategoryResponseDto> ConvertToResponseList(List<Category> categories)
    {
        //List<CategoryResponseDto> responseDtos = new();
        //foreach (var category in categories)
        //{
        //    responseDtos.Add(ConvertToResponse(category));
        //}
        //return responseDtos;

        return categories.Select(x => ConvertToResponse(x)).ToList();
    }
}
