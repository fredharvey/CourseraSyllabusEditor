using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{
    public class Asset : SyllabusItem
    {
        public Asset(JProperty s)
        {

            if (s.Count<JToken>() != 1)
                System.Diagnostics.Debugger.Break();

            // lesson data is a tuple: name, childrenArray
            Item = s.Value;            
        }

        public JToken Item { get; set; }
        public override void ChangeName(string name)
        {
            //Do Nothing, name is not used
        }
    }
}
