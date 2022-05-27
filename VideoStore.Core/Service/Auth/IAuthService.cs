using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoStore.Application.Service.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role);

        string ComputeSha256Hash(string password);
    }
}
