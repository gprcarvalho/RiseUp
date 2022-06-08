using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokécheck.Model
{
    public class Type
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        public Type(string name)
        {
            Name = name;
        }

    }
}
