using RedRainParks.Domain.Attributes;
using RedRainParks.Domain.Extensions;

namespace RedRainParks.Data
{
    public static class SqlGenerator
    {
        public static string Fetch(Type dto, string? whereOverride = null)
        {
            var propertyAttributes = dto.GetSqlProperties<FetchableAttribute>();

            var itemsToSelect = !propertyAttributes.Any() ? "*" :
                propertyAttributes.Select(p => $"{p.Attribute.SpecifiedColumnName ?? p.PropertyName} as {p.PropertyName}")
                    .AggregateWithCommas();

            if (Attribute.GetCustomAttribute(dto, typeof(FetchQuery)) is not FetchQuery queryDetails)
            {
                throw new ApplicationException($"{dto} Must Contain The FetchQuery Attribute For SQL Generation.");
            }

            var join = queryDetails.Joins?.Any() ?? false ? queryDetails.Joins.Aggregate((a, b) => $"{a} AND {b}") : string.Empty;

            var where = string.IsNullOrWhiteSpace(queryDetails.Where) ? string.Empty : "WHERE " + queryDetails.Where;

            where = whereOverride ?? where;

            return $"SELECT {itemsToSelect} FROM {queryDetails.Table} {join} {where}";
        }
    }
}
