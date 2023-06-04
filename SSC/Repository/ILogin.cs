using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSC.Repository
{
    public interface ILogin
    {
        Task<IEnumerable<UserLogin>> getuser();
        Task<UserLogin> AuthenticateUser(string username, string password);
    }
}
