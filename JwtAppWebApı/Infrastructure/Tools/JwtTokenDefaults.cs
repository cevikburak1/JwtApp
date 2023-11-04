using System.Text;
using static System.Net.WebRequestMethods;

namespace JwtAppWebApı.Infrastructure.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string Key = "burakburakburak1.";
        public const int Expire = 5;

    }
}
