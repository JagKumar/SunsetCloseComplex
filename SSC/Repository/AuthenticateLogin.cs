using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SSC.Repository
{
    public class AuthenticateLogin : ILogin
    {
        //private readonly LoginDbcontext _context;
        private readonly SscContext _context;

        public AuthenticateLogin(SscContext context)
        {
            _context = context;
        }
        public async Task<UserLogin> AuthenticateUser(string username, string password)
        {
            var succeeded = await _context.UserLogin.FirstOrDefaultAsync(authUser => authUser.UserName == username && authUser.password == password);
            return succeeded;
        }

        public async Task<IEnumerable<UserLogin>> getuser()
        {
            return await _context.UserLogin.ToListAsync();
        }
    }
}
