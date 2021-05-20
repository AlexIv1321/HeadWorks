using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HeadWorksDragonFight.Configuration
{
    public class AuthorizationSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int Lifetime { get; set; }

    }
}
