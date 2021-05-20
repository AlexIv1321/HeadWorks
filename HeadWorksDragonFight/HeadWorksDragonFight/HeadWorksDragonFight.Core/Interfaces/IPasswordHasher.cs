using System;
using System.Collections.Generic;
using System.Text;

namespace HeadWorksDragonFight.Core.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string rawPassword);
        bool VerifyHashedPassword(string hashedPassword, string password);
    }
}
