using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{
    public class Class : SyllabusItem
    {
        public Class (JToken classData)
        {
            this.JSONReference = classData; //store a reference to the jtoken

            Modules = new List<Module>();

            foreach(JToken m in classData.Children())
            {
                Modules.Add(new Module(m));
            }
        }
        public List<Module> Modules { get; set; }

        public override void ChangeName(string name)
        {
           //write the name back into the object
        }


    }
}
