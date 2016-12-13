using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdapService.Models
{
    public class UserAttributeNames
    {
        public static string AccountName { get { return "sAMAccountName"; } }
        public static string Name { get { return "givenName"; } }
        public static string Surname { get { return "sn"; } }
        public static string DisplayName { get { return "displayName"; } }
        public static string Mail { get { return "mail"; } }
        public static string MobilePhone { get { return "mobile"; } }
        public static string Company { get { return "company"; } }
        public static string Department { get { return "department"; } }
        public static string Title { get { return "title"; } }
        public static string Office { get { return "physicalDeliveryOfficeName"; } }
        public static string UniqueIdentifier { get { return "objectGUID"; } }
    }
}
