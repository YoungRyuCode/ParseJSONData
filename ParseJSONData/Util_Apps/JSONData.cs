using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ParseJSONData.Util_Apps
{
    public class JSONData
    {
        public static List<WorkdayAttributes> Get(string jsonFilePath)
        {
            // Parse json data from workday json data
            //JArray jsonData = JArray.Parse(File.ReadAllText(@"C:\INT_Okta_Worker_Import.json"));
            JArray jsonData = JArray.Parse(File.ReadAllText(jsonFilePath));

            // Deserialize Json Data
            List<WorkdayAttributes> result = JsonConvert.DeserializeObject<List<WorkdayAttributes>>(jsonData.ToString());

            return result;
        }
    }
}
