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

            var itemsToSelect = !propertyAttributes.Any() ? "*" : propertyAttributes.Select(p => 
                    $"{p.Attribute.SpecifiedDatabaseNameOr(p.PropertyName)} as {p.PropertyName}").AggregateWithCommas();

            if (Attribute.GetCustomAttribute(dto, typeof(FetchQuery)) is not FetchQuery queryDetails)
            {
                throw new ApplicationException($"{dto} Must Contain The FetchQuery Attribute For SQL Generation.");
            }

            var where = !string.IsNullOrWhiteSpace(whereOverride) ? "WHERE " + whereOverride : queryDetails.Where;

            return $"SELECT {itemsToSelect} FROM {queryDetails.Table} {queryDetails.Joins} {where} {queryDetails.OrderBy}";
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

            var inserts = requests.Select(r =>
            {
                IEnumerable<(string ColumnName, string ValueName)> items = propertyAttributes.Where(p => p.Attribute.TableName == r.Table)
                    .Select(x => (x.Attribute.SpecifiedDatabaseNameOr(x.PropertyName), x.Attribute.ColumnNameToFetchOr(x.PropertyName)));

                var declareAndSetScopedIdentity = string.Empty;
                
                if(propertyAttributes.Any(x => x.Attribute.TableName == r.Table && x.Attribute.UseScopedIdentity))
                {
                    var scopedProperty = propertyAttributes.FirstOrDefault(x => x.Attribute.TableName == r.Table && x.Attribute.UseScopedIdentity);

                    declareAndSetScopedIdentity = $"DECLARE @{scopedProperty.PropertyName} {scopedProperty.Attribute.SqlTypeName} = SCOPE_IDENTITY() ";
                }

                var insertIntoTableColumns = @$"INSERT INTO {r.Table} ( {items.Select(x => x.ColumnName).AggregateWithCommas()} ) ";

                var valuesToInsert = r.GetValuesToInsert(items.Select(v => v.ValueName).AggregateWithCommas());

                return @$"{declareAndSetScopedIdentity} {insertIntoTableColumns} {valuesToInsert}";

            }).Aggregate((a, b) => $"{a} {b}");

            return propertyAttributes.Any(x => x.Attribute.UseScopedIdentity) ? $"BEGIN TRANSACTION {inserts} COMMIT TRANSACTION" : inserts;
        }
    }
}
