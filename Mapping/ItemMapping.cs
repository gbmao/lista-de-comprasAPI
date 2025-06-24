using System;
using lista_de_comprasAPI.Dtos;
using lista_de_comprasAPI.Entities;

namespace lista_de_comprasAPI.Mapping;

public static class ItemMapping
{
    public static Item ToEntity(this CreateItemDto item)
    {
        return new Item()
        {
            Name = item.Name,
            CategoryId = item.CategoryId,
            Quantities = item.Quantities,
            ExpirationDate = item.ExpirationDate,
        };
    }

    public static Item ToEntity(this UpdateItemDto item, int id)
    {
        return new Item()
        {
            Id = id,
            Name = item.Name,
            CategoryId = item.CategoryId,
            Quantities = item.Quantities,
            ExpirationDate = item.ExpirationDate,

        };
    }

    public static ItemSummaryDto ToItemSummaryDto(this Item item)
    {
        return new(
            item.Id,
            item.Name,
            item.Category!.Name,
            item.Quantities,
            item.ExpirationDate
        );

    }

    public static ItemDetailsDto ToItemDetailsDto(this Item item)
    {
        return new(
            item.Id,
            item.Name,
            item.CategoryId,
            item.Quantities,
            item.ExpirationDate
        );
    }
}
