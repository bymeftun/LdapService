# LdapService
is a .net Core project. Connect to directory service using Novell.

 ```c#
 LdapSetting activeDirectorySetting = new LdapSetting()
 {
    ServerAddress = "192.168.240.27",
    BaseDn = "dc=testdomain,dc=com",
    ServerPort = 389,
    RootUserDn = "serviceUser",
    RootUserBaseDn = "OU=SystemAccounts",
    RootUserPassword = "password"
 };           
            
 var activeDirectoryService = ldapService.GetLdapService(LdapType.ActiveDirectory, activeDirectorySetting, "CN=Persons");
 
 var user = activeDirectoryService.GetUser("test.user");
 
 ``` 
