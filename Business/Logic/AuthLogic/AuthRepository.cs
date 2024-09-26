using Business.Data;
using Core.Entities;
using Core.Interface;
using Microsoft.EntityFrameworkCore;


namespace Business.Logic.AuthLogic
{
    public class AuthRepository : IAuthRepository
    {
        private readonly EcomerceDbContext _dbContext;

        public AuthRepository(EcomerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<User> ChangePassword(string Email, string Password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User?> GetByUsernameAndPassword(string Email, string Password)
        {

            return await _dbContext.User
                .Where(u => u.Email == Email && u.Password == Password)
                .Select(u => new User
                {
                    Email = Email,
                    Password = Password,
                    Id = u.Id,
                    Name = u.Name,
                    LastName = u.LastName,
                    EmailConfirmed = u.EmailConfirmed,
                    Enabled = u.Enabled,
                    IsDeleted = u.IsDeleted,
                    ProfileId = u.ProfileId,
                    //Company = new Company
                    //{
                    //    Id = u.Company.Id,
                    //    Name = u.Company.Name
                    //},
                    //Profile = new Profile
                    //{
                    //    Id = u.Profile.Id,
                    //    Title = u.Profile.Title
                    //}
                })
                //.Include(u => u.Company)
                //.Include(u => u.Profile)
                .FirstOrDefaultAsync() ?? null;

        }

        public Task<User> RecoveryPassword(string Email)
        {
            throw new System.NotImplementedException();
        }
    }
}
