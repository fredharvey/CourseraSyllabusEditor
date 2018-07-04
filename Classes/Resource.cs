using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{
    public class Resource : SyllabusItem
    {
        public Resource(JToken resourceData)
        {
            JSONReference = resourceData;
            if (resourceData.Count<JToken>() != 2)
                System.Diagnostics.Debugger.Break();

            // lesson data is a tuple: name, childrenArray
            Name = resourceData[0].Value<string>();

            Assets = new List<Asset>();
            foreach(JProperty a in resourceData.Last.Children())
            {
                Assets.Add(new Asset(a));
            }
        }
        public override void ChangeName(string name)
        {
            //Do Nothing, name is not used
            JArray values = JSONReference.Value<JArray>();
            values[0] = name;
        }
        public List<Asset> Assets {get;set;}
    }
}
