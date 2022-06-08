using Microsoft.Data.Sqlite;
using Pokécheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Pokécheck.Model.Type;

namespace Pokécheck.LocalBD
{
    public class TypeDB
    {

        public static string PathDatabase { get; set; }

        public static void InsertPokemonType(int PokemonID, string Type)
        {
            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();

                SqliteCommand insertCommand = new SqliteCommand("INSERT INTO tipos (pokemon_id, type) VALUES (@pokemon_id, @type)", connection);
                insertCommand.Parameters.AddWithValue("@pokemon_id", PokemonID);
                insertCommand.Parameters.AddWithValue("@type", Type);
                insertCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        public static List<Types> FindPokemonTypeByID(int ID)
        {
            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT type FROM tipos WHERE pokemon_id = @value", connection);
                selectCommand.Parameters.AddWithValue("@value", ID);
                SqliteDataReader queryResponse = selectCommand.ExecuteReader();

                List<Types> pokemonTypes = new List<Types>();

                while (queryResponse.Read())
                {
                    pokemonTypes.Add(new Types { Type = new Type(queryResponse.GetString(0)) });
                }

                queryResponse.Close();
                return pokemonTypes;
            }
        }


    }
}
