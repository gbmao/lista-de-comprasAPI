using System;
using lista_de_comprasAPI.Dtos;
using lista_de_comprasAPI.Entities;

namespace lista_de_comprasAPI.Mapping;

public static class CategoryMapping
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto(category.Id, category.Name);
    }
}
