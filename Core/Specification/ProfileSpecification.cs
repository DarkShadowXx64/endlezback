using Core.Entities;
using System.Linq.Expressions;


namespace Core.Specification
{
    public class ProfileSpecification : BaseSpecification<Profiles>
    {
        public Expression<Func<Profiles, bool>> Criteria { get; }
        public List<Expression<Func<Profiles, object>>> Includes { get; } = new();

        public ProfileSpecification()
        {
            // Criterio por defecto, si es necesario
            Criteria = profile => true;
        }
        public ProfileSpecification(Guid id)
        {
            Criteria = profile => profile.Id == id;
        }
    }
}
