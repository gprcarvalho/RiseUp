using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokécheck.Model
{
    internal class Ability
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        public Ability(string name)
        {
            Name = name;
        }

    }
}
