using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp2
{
    public abstract class SyllabusItem
    {
        public string Name { get; set; }
        public JToken JSONReference { get; set; }
        abstract public void ChangeName(string name);
    }
}
