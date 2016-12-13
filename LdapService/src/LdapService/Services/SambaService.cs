using System;
using LdapService.Models;
using LdapService.Ldap;
using Novell.Directory.Ldap;
using LdapService.Exceptions;
using System.Text.RegularExpressions;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LdapService.Services
{
    public class SambaService : ILdapService
    {
        private readonly LdapSetting ldapSetting;
        private readonly string organizationalUnit;

        public SambaService(LdapSetting _ldapSetting, string _organizationalUnit)
        {
            ldapSetting = _ldapSetting;
            organizationalUnit = _organizationalUnit;
        }

        public LdapEntry GetLdapEntry(string accountName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            LdapEntry ldapEntry = null;

            using (var ldapConn = NewConnection())
            {
                LdapSearchResults lsc = ldapConn.Search(BuildDn(accountName, organizationalUnit), LdapConnection.SCOPE_SUB, "sAMAccountName=" + accountName, null, false);

                while (lsc.hasMore())
                {
                    try
                    {
                        ldapEntry = lsc.next();
                    }
                    catch
                    {
                        continue;
                    }
                }

                return ldapEntry;
            }
        }

        public User GetUser(string accountName)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            string lastAttribute = string.Empty;

            var user = new User();

            var ldapEntry = GetLdapEntry(accountName);

            if (ldapEntry != null)
            {
                LdapAttributeSet attributeSet = ldapEntry.getAttributeSet();            

                lastAttribute = UserAttributeNames.AccountName;
                user.AccountName = attributeSet.getAttribute(UserAttributeNames.AccountName)?.StringValue;
                lastAttribute = UserAttributeNames.Company;
                user.Company = attributeSet.getAttribute(UserAttributeNames.Company)?.StringValue;
                lastAttribute = UserAttributeNames.Department;
                user.Department = attributeSet.getAttribute(UserAttributeNames.Department)?.StringValue;
                lastAttribute = UserAttributeNames.Company;
                user.DisplayName = attributeSet.getAttribute(UserAttributeNames.Company)?.StringValue;
                lastAttribute = UserAttributeNames.Mail;
                user.Mail = attributeSet.getAttribute(UserAttributeNames.Mail)?.StringValue;
                lastAttribute = UserAttributeNames.MobilePhone;
                user.MobilePhone = attributeSet.getAttribute(UserAttributeNames.MobilePhone)?.StringValue;
                lastAttribute = UserAttributeNames.Name;
                user.Name = attributeSet.getAttribute(UserAttributeNames.Name)?.StringValue;
                lastAttribute = UserAttributeNames.Office;
                user.Office = attributeSet.getAttribute(UserAttributeNames.Office)?.StringValue;
                lastAttribute = UserAttributeNames.Surname;
                user.Surname = attributeSet.getAttribute(UserAttributeNames.Surname)?.StringValue;
                lastAttribute = UserAttributeNames.Title;
                user.Title = attributeSet.getAttribute(UserAttributeNames.Title)?.StringValue;
                lastAttribute = UserAttributeNames.UniqueIdentifier;
                user.UniqueIdentifier = new Guid((Byte[])(Array)attributeSet.getAttribute("objectGUID")?.ByteValue);
            }

            return user;
        }

        public bool ValidateUser(string accountName, string password)
        {
            if (string.IsNullOrEmpty(accountName))
            {
                throw new ArgumentNullException(nameof(accountName));
            }

            try
            {
                var ldapConnection = new LdapConnection();
                ldapConnection.Connect(ldapSetting.ServerAddress, 389);
                ldapConnection.Bind(BuildDn(accountName, organizationalUnit), password);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private LdapConnection NewConnection()
        {
            try
            {
                var ldapConnection = new LdapConnection();

                ldapConnection.Connect(ldapSetting.ServerAddress, 389);
                ldapConnection.Bind(BuildDn(ldapSetting.RootUserDn, ldapSetting.RootUserBaseDn), ldapSetting.RootUserPassword);

                return ldapConnection;
            }
            catch (Exception ex)
            {
                throw new CredentialNotFoundException(ex.Message);
            }
        }

        private string BuildDn(string accountName, string baseDn)
        {
            if (string.IsNullOrEmpty(baseDn))
                return string.Format("CN={0},{1}", accountName, ldapSetting.BaseDn);
            else
                return string.Format("CN={0},{1},{2}", accountName, baseDn, ldapSetting.BaseDn);
        }
    }
}
