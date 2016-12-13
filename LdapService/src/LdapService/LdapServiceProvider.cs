using LdapService.Ldap;
using LdapService.Models;
using LdapService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdapService
{
    public class LdapServiceProvider
    {
        public ILdapService GetLdapService(LdapType ldapType, LdapSetting ldapSetting, string baseDnOrganizationalUnit)
        {
            if (ldapType == LdapType.ActiveDirectory)
                return new ActiveDirectoryService(ldapSetting, baseDnOrganizationalUnit);
            else
                return new SambaService(ldapSetting, baseDnOrganizationalUnit);
        }
    }
}
