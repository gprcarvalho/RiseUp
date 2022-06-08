using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokécheck.Model
{
    public class Types
    {

        [JsonProperty("type")]
        public Type Type { get; set; }

    }
}
