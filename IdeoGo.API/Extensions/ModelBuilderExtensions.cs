using Microsoft.EntityFrameworkCore;

namespace IdeoGo.API.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplySnakeCaseNamingConvention(this ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                ///model builder tiene una propiedad modelo con el metodo getentitytypes. el cual me da todos los entity types del modelos (category, tag, etc)
                entity.SetTableName(entity.GetTableName().ToSnakeCase());//si dice get table name, retornara el por ejemplo categories del appdbcontext
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());// to snake case de ese categories del titulo y del column name y les hace set
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());
            }
        }

    }
}
