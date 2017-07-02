using System;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Okta.Core;
using Okta.Core.Clients;
using Okta.Core.Models;

namespace ParseJSONData.Util_Apps
{
    public class OKTA
    {
        private static string _appToken = "";
        private static string _subDomain = "";
        private static string _groupName = "";
        private static Group _appGroupName = null;

        public OKTA (string appToken, string subDomain, string groupName)
        {
            _appToken = appToken;
            _subDomain = subDomain;
            _groupName = groupName;
        }

        //public OktaClient SetOKTAClient()
        //{
        //    OktaClient oktaClient = null;
        //    return oktaClient = new OktaClient(_appToken, _subDomain);
        //    //return oktaClient;
        //}
        
        public GroupsClient GetGroupClient(OktaClient myOktaClient)
        {
            var groupClient = myOktaClient.GetGroupsClient();
            return groupClient;
        }

        public Group GetAppGroupName(GroupsClient myGroupClient)
        {
            _appGroupName = myGroupClient.GetByName(_groupName);
            return _appGroupName;
        }

        public GroupUsersClient GetGroupUsersClient()
        {
            var groupUsersClient = new GroupUsersClient(_appGroupName, _appToken, _subDomain);
            return groupUsersClient;
        }

        public UsersClient GetUsersClient()
        {
            var usersClient = new UsersClient(_appToken, _subDomain);
            return usersClient;
        }

        public GroupUsersClient GetAppUsers(OktaClient myOktaClient, Group appGroupName)
        {
            var appUsers = myOktaClient.GetGroupUsersClient(appGroupName);
            return appUsers;
        }
    }
}

// Get all the users from OKTA app-group
//var appUsers = oktaClient.GetGroupUsersClient(appGroupName);

//User appUser = null;



//int importedUserCount = 0;
//int unimportedUserCount = 0;

//var export = new CsvExport();
//for (int i = 0; i < upn.Length; i++)
//{
//    try
//    {
//        bool currentAppUser = false;
//        currentAppUser = Utilities.IsCurrnetAppMemberLINQ(oktaClient, appGroupName, upn[i]);

//        if (currentAppUser == false)
//        {
//            appUser = userClient.GetByUsername(upn[i]);
//            groupUsersClient.Add(appUser);
//            importedUserCount++;
//            Console.WriteLine("Imported User: " + upn[i]);
//        }
//    }
//    catch (Exception e)
//    {
//        export.AddRow();
//        export["Not Imported User"] = upn[i];
//        unimportedUserCount++;
//        Console.WriteLine("Non-Imported User: " + upn[i]);
//    }
//}
//export.ExportToFile(OutFilePath + appGroupName.Profile.Name + "-OMG-Not Imported-Users.csv");

