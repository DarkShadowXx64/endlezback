using Core.Entities;
using System;

namespace Core.Specification
{
    public class UserSpecification : BaseSpecification<User>
    {
        public UserSpecification()
        {
            AddInclude(p => p.Profile!);
        }

    }
}
