using FluentNHibernate.Mapping;

namespace FluentNHibernate.Conventions.Discovery
{
    /// <summary>
    /// Discovers any <see cref="IReferenceConvention"/> implementations and applies them to
    /// an <see cref="IManyToOnePart"/> instance.
    /// </summary>
    public class ReferenceDiscoveryConvention : IRelationshipConvention
    {
        private readonly IConventionFinder conventionFinder;

        public ReferenceDiscoveryConvention(IConventionFinder conventionFinder)
        {
            this.conventionFinder = conventionFinder;
        }

        public bool Accept(IRelationship relationship)
        {
            return (relationship is IManyToOnePart);
        }

        public void Apply(IRelationship relationship)
        {
            var conventions = conventionFinder.Find<IReferenceConvention>();
            var manyToOne = (IManyToOnePart)relationship;

            foreach (var convention in conventions)
            {
                if (convention.Accept(manyToOne))
                    convention.Apply(manyToOne);
            }
        }
    }
}