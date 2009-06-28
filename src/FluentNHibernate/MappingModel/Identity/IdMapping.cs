using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentNHibernate.MappingModel.Identity
{
    public class IdMapping : MappingBase, IIdentityMapping, IHasColumnMappings
    {
        private readonly AttributeStore<IdMapping> attributes = new AttributeStore<IdMapping>();
        private readonly IDefaultableList<ColumnMapping> columns = new DefaultableList<ColumnMapping>();

        public GeneratorMapping Generator { get; set; }

        public void AddColumn(ColumnMapping column)
        {
            columns.Add(column);
        }

        public void AddDefaultColumn(ColumnMapping column)
        {
            columns.AddDefault(column);
        }

        public void ClearColumns()
        {
            columns.Clear();
        }

        public IDefaultableEnumerable<ColumnMapping> Columns
        {
            get { return columns; }
        }

        public PropertyInfo PropertyInfo { get; set; }

        public override void AcceptVisitor(IMappingModelVisitor visitor)
        {
            visitor.ProcessId(this);

            foreach (var column in Columns)
                visitor.Visit(column);

            if (Generator != null)
                visitor.Visit(Generator);
        }

        public string Name
        {
            get { return attributes.Get(x => x.Name); }
            set { attributes.Set(x => x.Name, value); }
        }

        public string Access
        {
            get { return attributes.Get(x => x.Access); }
            set { attributes.Set(x => x.Access, value); }
        }

        public TypeReference Type
        {
            get { return attributes.Get(x => x.Type); }
            set { attributes.Set(x => x.Type, value); }
        }

        public string UnsavedValue
        {
            get { return attributes.Get(x => x.UnsavedValue); }
            set { attributes.Set(x => x.UnsavedValue, value); }
        }

        public AttributeStore<IdMapping> Attributes
        {
            get { return attributes; }
        }

        public Type ContainingEntityType { get; set; }
    }
}