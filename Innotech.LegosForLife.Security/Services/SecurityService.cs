using InnoTech.LegosForLife.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoTech.LegosForLife.Security.Services
{
    public class SecurityService : ISecurityService
    {
        public JwtToken GenerateJwtToken(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
