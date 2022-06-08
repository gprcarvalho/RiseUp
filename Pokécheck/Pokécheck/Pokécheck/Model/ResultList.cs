using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokécheck.Model
{
    public class ResultList
    {

        [JsonProperty("pokemon")]
        public List<ResultList> PokemonList { get; set; }

    }
}
