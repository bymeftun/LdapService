using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdapService.Exceptions
{
    public class CredentialNotFoundException : Exception
    {
        public CredentialNotFoundException(string message) : base(message)
        {

        }
    }
}
