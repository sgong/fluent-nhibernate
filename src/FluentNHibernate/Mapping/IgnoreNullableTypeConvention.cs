using System;

namespace FluentNHibernate.Mapping
{
    public class IgnoreNullableTypeConvention : ITypeConvention
    {
        public bool CanHandle(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        public void AlterMap(IProperty propertyMapping)
        {
            // no-op;
        }
    }
}