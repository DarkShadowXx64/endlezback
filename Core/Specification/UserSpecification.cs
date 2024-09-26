using Core.Entities;
using System;

namespace Core.Specification
{
    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification() : base(u => !u.IsDeleted)
        {
            AddInclude(p => p.Profile!);
        }

    }
}
