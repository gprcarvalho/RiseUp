using Microsoft.Data.Sqlite;
using Pokécheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokécheck.LocalBD
{
    public class AbilityDB
    {

        public static string PathDatabase { get; set; }

        public static void InsertPokemonAbility(int pokemonID, string ability)
        {
            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();

                SqliteCommand insertCommand = new SqliteCommand("INSERT INTO habilidades (pokemon_id, ability) VALUES (@pokemon_id, @ability)", connection);
                insertCommand.Parameters.AddWithValue("@pokemon_id", pokemonID);
                insertCommand.Parameters.AddWithValue("@ability", ability);
                insertCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static List<Abilitys> FindPokemonAbilityByID(int ID)
        {
            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT ability FROM habilidades WHERE pokemon_id = @value", connection);
                selectCommand.Parameters.AddWithValue("@value", ID);
                SqliteDataReader queryResponse = selectCommand.ExecuteReader();

                List<Abilitys> pokemonAbilities = new List<Abilitys>();

                while (queryResponse.Read())
                {
                    pokemonAbilities.Add(new Abilitys { Ability = new Ability(queryResponse.GetString(0)) });
                }

                queryResponse.Close();
                return pokemonAbilities;
            }
        }



    }
}
