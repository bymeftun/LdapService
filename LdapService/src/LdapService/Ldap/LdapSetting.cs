using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdapService.Ldap
{
    public class LdapSetting
    {
        public string ServerAddress { get; set; }        

        public int ServerPort { get; set; }

        public string BaseDn { get; set; }

        public string RootUserDn { get; set; }

        public string RootUserBaseDn { get; set; }

        public string RootUserPassword { get; set; }
    }
}
