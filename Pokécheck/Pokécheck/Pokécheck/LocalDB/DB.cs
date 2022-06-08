using Microsoft.Data.Sqlite;
using Pokécheck.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Pokécheck.LocalBD
{
    public class DB
    {

        public async static Task InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync("pokecheck.db", CreationCollisionOption.OpenIfExists);
            string databasePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "pokecheck.db");

            using (SqliteConnection connection = new SqliteConnection($"Filename={databasePath}"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
                command.ExecuteNonQuery();

                command = new SqliteCommand("CREATE TABLE IF NOT EXISTS pokemons (" +
                    "id INTEGER NOT NULL UNIQUE PRIMARY KEY, " +
                    "name VARCHAR(50) NOT NULL UNIQUE," +
                    "hp INTEGER NOT NULL," +
                    "attack INTEGER NOT NULL," +
                    "defense INTEGER NOT NULL)", connection); 
                   
                command.ExecuteNonQuery();

                command = new SqliteCommand("CREATE TABLE IF NOT EXISTS tipos (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "pokemon_id INTEGER REFERENCES pokemon(id) ON DELETE CASCADE," +
                    "type VARCHAR(50) NOT NULL)", connection);
                command.ExecuteNonQuery();

                command = new SqliteCommand("CREATE TABLE IF NOT EXISTS habilidades (" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "pokemon_id INTEGER REFERENCES pokemon(id) ON DELETE CASCADE," +
                    "ability VARCHAR(50) NOT NULL)", connection);
                command.ExecuteNonQuery();

                TypeDB.PathDatabase = databasePath;
                PokemonDB.PathDatabase = databasePath;
                AbilityDB.PathDatabase = databasePath;

                connection.Close();
            }
        }

        public static bool InsertPokemon(Pokemon pokemon)
        {
            return PokemonDB.InsertPokemon(pokemon);
        }

        public static void InsertPokemonType(int pokemonID, string type)
        {
            TypeDB.InsertPokemonType(pokemonID, type);
        }

        public static void InsertPokemonAbility(int pokemonID, string ability)
        {
            AbilityDB.InsertPokemonAbility(pokemonID, ability);
        }

        public static Pokemon FindPokemonByID(int ID)
        {
            return PokemonDB.FindPokemonByID(ID);
        }

        public static List<Pokemon> FindPokemonByName(string pokemonName)
        {
            return PokemonDB.FindPokemonByName(pokemonName);
        }

        public static List<Pokemon> FindPokemonByType(string pokemonType)
        {
            return PokemonDB.FindPokemonByType(pokemonType);
        }

        public static List<Pokemon> GetTenPokemon(int page)
        {
            return PokemonDB.GetTenPokemon(page);
        }

        public static int AmountOfPokemonDatabase()
        {
            return PokemonDB.AmountOfPokemonDatabase();
        }


    }
}
