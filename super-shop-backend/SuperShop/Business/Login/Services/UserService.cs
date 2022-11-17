using SuperShop.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace SuperShop.Business.Login.Services
{
    public class UserService
    {
        private readonly FakeDexContext _fakeDexContext;

        public UserService(FakeDexContext fakeDexContext)
        {
            _fakeDexContext = fakeDexContext;
        }

        public async Task<Models.Data.User> AddLogin(string email)
        {
            var user = await _fakeDexContext.User.FindAsync(email);
            if (user == null)
            {
                user = new Models.Data.User
                {
                    Email = email
                };
                await _fakeDexContext.User.AddAsync(user);
                await _fakeDexContext.SaveChangesAsync();
            }
            return user;
        }


        public async Task<List<Models.Data.User>> GetUsers()
        {
            return await _fakeDexContext.User.ToListAsync();
        }
    }
}
