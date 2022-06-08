using Newtonsoft.Json;
using Pokécheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pokécheck.ControllerAPI
{
    public class PokeCheckAPI
    {

        private const string pokeAPI = "https://pokeapi.co/api/v2/";

        public static async Task<Pokemon> GetPokemonsByIdAsync(int pokemonID)
        {
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(pokeAPI) })
            {
                HttpResponseMessage response = await client.GetAsync($"pokemon/{pokemonID}");
                string responseBody = await response.Content.ReadAsStringAsync();
                Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(responseBody); 
                
                return pokemon;
            }
        }
        public static async Task<Pokemon> GetPokemonsByNameAsync(string pokemonName)
        {
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(pokeAPI) })
            {
                HttpResponseMessage response = await client.GetAsync($"pokemon/{pokemonName}");
                string responseBody = await response.Content.ReadAsStringAsync();
                Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(responseBody);

                return pokemon;
            }
        }

        public static async Task<ResultList> GetPokemonsByType(string pokemonType)
        {
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(pokeAPI) })
            {
                HttpResponseMessage response = await client.GetAsync($"type/{pokemonType}");
                string responseBody = await response.Content.ReadAsStringAsync();
                ResultList pokemonList = JsonConvert.DeserializeObject<ResultList>(responseBody);

                return pokemonList;
            }
        }
        
    }
}
