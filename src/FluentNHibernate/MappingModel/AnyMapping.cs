using System;
using System.Collections.Generic;

namespace FluentNHibernate.MappingModel
{
    public class AnyMapping : MappingBase
    {
        private readonly AttributeStore<AnyMapping> attributes = new AttributeStore<AnyMapping>();
        private readonly IDefaultableList<ColumnMapping> columns = new DefaultableList<ColumnMapping>();
        private readonly IList<MetaValueMapping> metaValues = new List<MetaValueMapping>();

        public override void AcceptVisitor(IMappingModelVisitor visitor)
        {
            visitor.ProcessAny(this);

            foreach (var column in columns)
                visitor.Visit(column);

            foreach (var metaValue in metaValues)
                visitor.Visit(metaValue);
        }

        public string Name
        {
            get { return attributes.Get(x => x.Name); }
            set { attributes.Set(x => x.Name, value); }
        }

        public string IdType
        {
            get { return attributes.Get(x => x.IdType); }
            set { attributes.Set(x => x.IdType, value); }
        }

        public TypeReference MetaType
        {
            get { return attributes.Get(x => x.MetaType); }
            set { attributes.Set(x => x.MetaType, value); }
        }

        public string Access
        {
            get { return attributes.Get(x => x.Access); }
            set { attributes.Set(x => x.Access, value); }
        }

        public bool Insert
        {
            get { return attributes.Get(x => x.Insert); }
            set { attributes.Set(x => x.Insert, value); }
        }

        public bool Update
        {
            get { return attributes.Get(x => x.Update); }
            set { attributes.Set(x => x.Update, value); }
        }

        public string Cascade
        {
            get { return attributes.Get(x => x.Cascade); }
            set { attributes.Set(x => x.Cascade, value); }
        }

        public IDefaultableEnumerable<ColumnMapping> Columns
        {
            get { return columns; }
        }

        public AttributeStore<AnyMapping> Attributes
        {
            get { return attributes; }
        }

        public IEnumerable<MetaValueMapping> MetaValues
        {
            get { return metaValues; }
        }

        public void AddDefaultColumn(ColumnMapping column)
        {
            columns.AddDefault(column);
        }

        public void AddColumn(ColumnMapping column)
        {
            columns.Add(column);
        }

        public void AddMetaValue(MetaValueMapping metaValue)
        {
            metaValues.Add(metaValue);
        }
    }
}