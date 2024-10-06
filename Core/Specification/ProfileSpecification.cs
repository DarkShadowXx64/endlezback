using Core.Entities;


namespace Core.Specification
{
    public class ProfileSpecification : BaseSpecification<Profile>
    {
        public ProfileSpecification()
        {
           
        }

        public ProfileSpecification(Guid id) : base(x => x.Id == id)
        {
        }
    }
}
