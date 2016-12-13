using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LdapService.Models
{
    public class User
    {
        public string AccountName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
        public string MobilePhone { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string Office { get; set; }
        public Guid UniqueIdentifier { get; set; }      
    }
}
