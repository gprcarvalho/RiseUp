using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokécheck.Model
{
    public class Pokemon
    {

        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("types")]
        public List<Types> Types { get; set; }

        [JsonProperty("abilitys")]
        public List<Abilitys> Abilitys { get; set; }

        [JsonProperty("attack")]
        public int Attack { get; set; }

        [JsonProperty("defense")]
        public int Defense { get; set; }

        [JsonProperty("hp")]
        public int HP { get; set; }

        public List<Type> StringTypes { get { return ListType(); } }
        private List<Type> ListType()
        {
            List<Type> typeList = new List<Type>();
            foreach (var type in Types)
            {
                typeList.Add(type.Type);
            }
            return typeList;
        }

        public Pokemon()
        {
        }

        public Pokemon(int id, string name,int hp, int attack, int defense)
        {
            ID = id;
            Name = name;
            HP = hp;
            Attack = attack;
            Defense = defense;
        
        }

        public override string ToString()
        {
            return $"{ID}";
        }

    }
}
