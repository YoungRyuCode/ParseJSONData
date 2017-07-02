using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Configuration;
using Okta.Core;
using Okta.Core.Clients;
using Okta.Core.Models;

namespace ParseJSONData
{
    public class Program
    {        
        static void Main(string[] args)
        {
            // Set Variables
            var appToken = ConfigurationManager.AppSettings["AppToken"].ToString();   // 002z0R5A_Yi6nNZTU8CTf8v0m_o3FnH7vZQSQJNhjh
            var subDomain = ConfigurationManager.AppSettings["Subdomain"].ToString(); // nutanix
            //var groupName = ConfigurationManager.AppSettings["GroupName"].ToString(); // App-Workplace
            var OutFilePath = ConfigurationManager.AppSettings["OutFilePath"].ToString(); // Output File Path for "Unimported User"
            var FileName = ConfigurationManager.AppSettings["FileName"].ToString(); // Input FileName for list of users
            var jsonFilePath = ConfigurationManager.AppSettings["jsonFilePath"].ToString(); // Input FileName for list of users

            // Read Input
            Console.Write("Please enter OKTA App Group Name: ");
            string groupName = Console.ReadLine();
            
            // OKTA Users Data
            var oktaClient = new OktaClient(appToken, subDomain);
            Util_Apps.OKTA oktaUtil = new Util_Apps.OKTA(appToken, subDomain, groupName);
            var oktaGroupClient = oktaUtil.GetGroupClient(oktaClient);
            var oktaAppGroupName = oktaUtil.GetAppGroupName(oktaGroupClient);
            var oktaGroupUsersClient = oktaUtil.GetGroupUsersClient();
            var usesClient = oktaUtil.GetUsersClient();
            var appUsers = oktaUtil.GetAppUsers(oktaClient, oktaAppGroupName);
            var allUsers = Util_Apps.Utilities.GetUsersToArray(appUsers);

            for(int i=0; i<allUsers.Length; i++)
            {
                var test = allUsers[i].Profile.Email;
            }
            
            // Workday Users Data (Parse Json data and convert it to List Array)
            var result = Util_Apps.JSONData.Get(jsonFilePath);



            // Export csv file with Workday Users
            //var export = new CsvExport();
            //for (int i = 0; i < result.Count; i++)
            //{
            //    export.AddRow();
            //    export["UPN"] = result[i].primaryWorkEmail;
            //    export["Employe ID"] = result[i].Employee_ID;
            //    export["Name"] = result[i].Preferred_Name;                
            //    export["Manager"] = result[i].Manager_Name;
            //    export["Manager Email"] = result[i].Managers_PrimaryWorkEmail;
            //    export["Work City"] = result[i].NTNX_WorkCity;               
            //    export["Division"] = result[i].NTNX_Division;
            //    export["Hire Date"] = result[i].Hire_Date;
            //    export["Status"] = result[i].NTNX_Status;
            //}
            ////Export CSV file
            //export.ExportToFile(@"D:\Development\Workday_Users.csv");


            // Read the contents of CSV file
            //var filename = @"C:\ImportUserList.txt";
            //var contents = File.ReadAllText(filename).Split('\n');

            //for(int i=0; i < contents.Length; i++)
            //{
            //    for (int j = 0; j < result.Count; j++)
            //    {
            //        if (result[j].primaryWorkEmail != null)
            //        {
            //            if (contents[i].ToLower() == result[j].primaryWorkEmail.ToLower())
            //            {
            //                export.AddRow();
            //                export["UPN"] = contents[i];
            //                export["Existing User?"] = "Yes";
            //            }
            //        }
            //    }
            //}
            //export.ExportToFile(@"C:\\Workday_Users_list.csv");

            Console.Write("\nPress any key to exit... ");
            Console.ReadLine();
        }
    }
}
