using RedRainParks.Domain.Attributes.ClassAttributes;
using RedRainParks.Domain.Attributes.PropertyAttributes;
using RedRainParks.Domain.Extensions;

namespace RedRainParks.Data.SQL
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

            var where = !string.IsNullOrWhiteSpace(whereOverride) ? "WHERE " +  whereOverride :
                        !string.IsNullOrWhiteSpace(queryDetails.Where) ? "WHERE " + queryDetails.Where :
                        string.Empty;

            var orderBy = !string.IsNullOrWhiteSpace(queryDetails.OrderBy) ? "ORDER BY " + queryDetails.OrderBy : string.Empty;

            return $"SELECT {itemsToSelect} FROM {queryDetails.Table} {queryDetails.Joins} {where} {orderBy}";
        }

        public static string Insert(Type requestObject)
        {
            var propertyAttributes = requestObject.GetSqlProperties<InsertableAttribute>();

            if (!propertyAttributes.Any())
            {
                throw new ApplicationException($"Request Object {requestObject} Must contain properties with the Insertable attribute.");
            }

            if (Attribute.GetCustomAttributes(requestObject, typeof(InsertQuery)) is not InsertQuery[] requests || !requests.Any())
            {
                throw new ApplicationException($"{requestObject} Must Contain The InsertQuery Attribute For SQL Generation.");
            }

            IEnumerable<(string TableName, string DatabaseName, string PropertyName)> properties = propertyAttributes
                .Select(p => (p.Attribute.TableName, 
                        p.Attribute.SpecifiedColumnName ?? p.PropertyName, 
                        p.Attribute.FromNameOrParameterName(p.PropertyName)));

            var query = requests.Select(r =>
            {
                var where = string.IsNullOrWhiteSpace(r.Where) ? string.Empty : "WHERE " + r.Where;
                
                var declareAndSetScopedIdentity = string.Empty;                

                if(propertyAttributes.Any(x => x.Attribute.TableName == r.Table && x.Attribute.UseScopedIdentity))
                {
                    var scopedProperty = propertyAttributes.FirstOrDefault(x => x.Attribute.UseScopedIdentity);

                    declareAndSetScopedIdentity = $"DECLARE @{scopedProperty.PropertyName} {scopedProperty.Attribute.SqlTypeName} = SCOPE_IDENTITY() ";
                }

                IEnumerable<(string DatabaseName, string PropertyName)> values = properties.Where(p => p.TableName == r.Table).Select(x => (x.DatabaseName, x.PropertyName));

                var insertIntoTableColumns = @$"INSERT INTO {r.Table} ( {values.Select(x => x.DatabaseName).AggregateWithCommas()} ) ";

                var valuesToInsert = r.IsInsertSelectRequest ? 
                    $"SELECT {values.Select(x => x.PropertyName).AggregateWithCommas()} FROM {r.From} {r.Join} {where} "
                    : $"VALUES ( {values.Select(x => x.PropertyName).AggregateWithCommas()} )";

                return $"{declareAndSetScopedIdentity} {insertIntoTableColumns} {valuesToInsert}";

            }).Aggregate((a, b) => $"{a} {b}");

            return propertyAttributes.Any(x => x.Attribute.UseScopedIdentity) ? $"BEGIN TRANSACTION {query} COMMIT TRANSACTION" : query;
        }
    }
}
