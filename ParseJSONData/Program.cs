using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
//using CSVFile;

namespace ParseJSONData
{
    class Program
    {        
        static void Main(string[] args)
        {
            // Parse json data from workday json data
            JArray jsonData = JArray.Parse(File.ReadAllText(@"C:\INT_Okta_Worker_Import.json"));

            // Deserialize Json Data
            List<WorkdayAttributes> result = JsonConvert.DeserializeObject<List<WorkdayAttributes>>(jsonData.ToString());

            var export = new CsvExport();

            // Export csv file with Workday Users
            for (int i = 0; i < result.Count; i++)
            {
                export.AddRow();
                export["UPN"] = result[i].primaryWorkEmail;
                export["Name"] = result[i].Preferred_Name;
                export["Employe ID"] = result[i].Employee_ID;
                export["Manager"] = result[i].Manager_Name;
                export["Manager Email"] = result[i].Managers_PrimaryWorkEmail;
                export["Work City"] = result[i].NTNX_WorkCity;
            }
            export.ExportToFile(@"C:\\Workday_Users.csv");


            //JObject match = jsonData["young.ryu@nutanix.com"].Values<JObject>()
            //    .Where(m => m["wvw_match_id"].Value<string>() == matchIdToFind)
            //    .FirstOrDefault();


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
        }
    }
}
