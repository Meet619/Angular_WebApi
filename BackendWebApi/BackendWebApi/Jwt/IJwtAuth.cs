using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebApi.Jwt
{
    public interface IJwtAuth
    {
        string Authentication(string username);
    }
}
