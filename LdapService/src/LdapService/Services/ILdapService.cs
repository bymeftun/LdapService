using LdapService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdapService.Services
{
    public interface ILdapService
    {     
        User GetUser(string accountName);

        bool ValidateUser(string accountName, string password);    
    }
}
