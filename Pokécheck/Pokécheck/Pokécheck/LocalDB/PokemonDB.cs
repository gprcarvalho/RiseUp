using Microsoft.Data.Sqlite;
using Pokécheck.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokécheck.LocalBD
{
    internal class PokemonDB
    {


        public static string PathDatabase { get; set; }

        public static bool InsertPokemon(Pokemon pokemon)
        {
            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();

                SqliteCommand insertCommand = new SqliteCommand("INSERT OR IGNORE INTO pokemon VALUES (@id, @name, @hp, @attack, @defense)", connection);

                insertCommand.Parameters.AddWithValue("@id", pokemon.ID);
                insertCommand.Parameters.AddWithValue("@name", pokemon.Name);
                insertCommand.Parameters.AddWithValue("@hp", pokemon.HP);
                insertCommand.Parameters.AddWithValue("@attack", pokemon.Attack);
                insertCommand.Parameters.AddWithValue("@defense", pokemon.Defense);

                bool isPokemonInserted = insertCommand.ExecuteNonQuery() != 0;
                connection.Close();

                return isPokemonInserted;
            }
        }

        public static Pokemon FindPokemonByID(int ID)
        {
            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * FROM pokemon WHERE id = @value", connection);
                selectCommand.Parameters.AddWithValue("@value", ID);
                SqliteDataReader queryResponse = selectCommand.ExecuteReader();

                if (queryResponse.HasRows)
                {
                    queryResponse.Read();

                    Pokemon pokemon = new Pokemon
                    {
                        ID = queryResponse.GetInt32(0),
                        Name = queryResponse.GetString(1),
                        HP = queryResponse.GetInt32(2),
                        Attack = queryResponse.GetInt32(3),
                        Defense = queryResponse.GetInt32(4)
                    };

                    queryResponse.Close();

                    pokemon.Types = TypeDB.FindPokemonTypeByID(ID);
                    pokemon.Abilitys = AbilityDB.FindPokemonAbilityByID(ID);

                    return pokemon;
                }
            }
            return null;
        }

        public static List<Pokemon> FindPokemonByName(string pokemonName)
        {
            List<Pokemon> pokemonsList = new List<Pokemon>();
            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();
                SqliteCommand selectCommand = new SqliteCommand($"SELECT * FROM pokemon WHERE name LIKE '{pokemonName}%'", connection);
                SqliteDataReader queryResponse = selectCommand.ExecuteReader();

                while (queryResponse.Read())
                {
                    Pokemon wantedPokemon = new Pokemon
                    {
                        ID = queryResponse.GetInt32(0),
                        Name = queryResponse.GetString(1),
                        HP = queryResponse.GetInt32(2),
                        Attack = queryResponse.GetInt32(3),
                        Defense = queryResponse.GetInt32(4),

                    
                    };
                wantedPokemon.Types = TypeDB.FindPokemonTypeByID(wantedPokemon.ID);
                wantedPokemon.Abilitys = AbilityDB.FindPokemonAbilityByID(wantedPokemon.ID);
                pokemonsList.Add(wantedPokemon);
            }
            queryResponse.Close();

       } 
            return pokemonsList;
        }


        public static List<Pokemon> FindPokemonByType(string pokemonType)
        {
            List<Pokemon> pokemonListWithTheSameType = new List<Pokemon>();

        using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();
                SqliteCommand selectComand = new SqliteCommand("SELECT pokemon_id FROM type_tb WHERE type = @value ", connection);

                selectComand.Parameters.AddWithValue("@value", pokemonType);
                SqliteDataReader queryResponse = selectComand.ExecuteReader();

                while (queryResponse.Read())
                {
                    int pokemonId = queryResponse.GetInt32(0);

                    SqliteCommand selectComandID = new SqliteCommand("SELECT * FROM pokemon WHERE id = @valueId", connection);
                    selectComandID.Parameters.AddWithValue("@valueId", pokemonId);
                    SqliteDataReader queryResponseID = selectComandID.ExecuteReader();

                    queryResponseID.Read();

                    Pokemon wantedPokemon = new Pokemon
                    {
                        ID = queryResponse.GetInt32(0),
                        Name = queryResponse.GetString(1),
                        HP = queryResponse.GetInt32(2),
                        Attack = queryResponse.GetInt32(3),
                        Defense = queryResponse.GetInt32(4)
                            
                        
                    };

                    wantedPokemon.Types = TypeDB.FindPokemonTypeByID(wantedPokemon.ID);
                    wantedPokemon.Abilitys = AbilityDB.FindPokemonAbilityByID(wantedPokemon.ID);

                    pokemonListWithTheSameType.Add(wantedPokemon);

                    queryResponseID.Close();
                }
                queryResponse.Close();
                return pokemonListWithTheSameType;
            }
        }

        public static List<Pokemon> GetTenPokemon(int page)
        {
            int offsetCount = page * 8;
            List<Pokemon> pokemonList = new List<Pokemon>();

            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                connection.Open();
                SqliteCommand selectComand = null;

                if (page < 40)
                {
                    selectComand = new SqliteCommand($"SELECT * FROM pokemon WHERE id < 321 ORDER BY id LIMIT 8 OFFSET {offsetCount}", connection);
                }
                else
                {
                    selectComand = new SqliteCommand($"SELECT * FROM pokemon  WHERE id > 320 ORDER BY id LIMIT 8", connection);
                }

                SqliteDataReader queryResponse = selectComand.ExecuteReader();

                while (queryResponse.Read())
                {
                    Pokemon pokemon = new Pokemon
                    {
                        ID = queryResponse.GetInt32(0),
                        Name = queryResponse.GetString(1),
                        HP = queryResponse.GetInt32(2),
                        Attack = queryResponse.GetInt32(3),
                        Defense = queryResponse.GetInt32(4),
                    };

                    pokemon.Types = TypeDB.FindPokemonTypeByID(pokemon.ID);
                    pokemon.Abilitys = AbilityDB.FindPokemonAbilityByID(pokemon.ID);
                    pokemonList.Add(pokemon);


                }
                queryResponse.Close();
                return pokemonList;
            }
        }

        public static int AmountOfPokemonDatabase()
        {
            using (SqliteConnection connection = new SqliteConnection($"Filename={PathDatabase}"))
            {
                int response = 0;
                connection.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT count(id) FROM pokemon", connection);
                SqliteDataReader queryResponse = selectCommand.ExecuteReader();
                if (queryResponse.Read())
                {
                    response = queryResponse.GetInt32(0);
                }
                return response;
            }
        }

    }
}
