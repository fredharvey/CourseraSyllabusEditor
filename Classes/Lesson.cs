using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{
    public class Lesson : SyllabusItem
    {
        public Lesson(JToken lessonData)
        {
            JSONReference = lessonData;
            if (lessonData.Count<JToken>() != 2)
                System.Diagnostics.Debugger.Break();
            
            // lesson data is a tuple: name, childrenArray
            Name = lessonData[0].Value<string>();

            Resources = new List<Resource>();
            foreach (JToken r in lessonData.Last.Children())
            {
                Resources.Add(new Resource(r));
            }
        }
        
        public List<Resource> Resources { get; set; }

        public override void ChangeName(string name)
        {
            JArray values = JSONReference.Value<JArray>();
            values[0] = name;
        }
    }
}
