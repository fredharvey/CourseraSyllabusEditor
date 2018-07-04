using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{
    public class Module : SyllabusItem
    {
        public Module(JToken moduleData)
        {
            this.JSONReference = moduleData;

            if (moduleData.Count<JToken>() != 2)
                System.Diagnostics.Debugger.Break();
            // module data is a tuple: name, childrenArray
            Name = moduleData[0].Value<string>();

            Lessons = new List<Lesson>();

            foreach(JToken l in moduleData.Last.Children())
                {
                Lessons.Add(new Lesson(l));
            }
        }
        public override void ChangeName(string name)
        {
            //Do Nothing, name is not used
            JArray values = JSONReference.Value<JArray>();
            values[0] = name;
        }
        public List<Lesson> Lessons { get; set; }
    }
}
