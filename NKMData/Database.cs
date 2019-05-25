using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace NKMData
{
    public static class Database
    {
        private static readonly IDbConnection Connection = new SQLiteConnection($"Data source=database.db");
        

        private static List<SqliteRow> Select(string query)
        {
            var rows = new List<SqliteRow>();

            Connection.Open();
            IDbCommand dbcmd = Connection.CreateCommand();
            dbcmd.CommandText = query;
            IDataReader reader = dbcmd.ExecuteReader();
            while (reader.Read())
            {
                var row = new SqliteRow();
                int fieldCount = reader.FieldCount;
                for (int i = 0; i < fieldCount; i++)
                {
                    string columnName = reader.GetName(i);
                    string value = reader.GetValue(i).ToString();
                    row.Add(columnName, value);
                }

                rows.Add(row);
            }

            reader.Close();
            dbcmd.Dispose();
            Connection.Close();
            return rows;
        }
        public static List<string> GetCharacterNames() => Select("SELECT Name FROM Character").SelectMany(row => row.Data.Values).ToList();
        public static IEnumerable<string> GetAbilityClassNames(string characterName) => Select($"SELECT Ability.ClassName AS AbilityName FROM Character INNER JOIN Character_Ability ON Character.ID = Character_Ability.CharacterID INNER JOIN Ability ON Ability.ID = Character_Ability.AbilityID WHERE Character.Name = '{characterName}';").SelectMany(row => row.Data.Values).ToList();
        public static SqliteRow GetCharacterData (string characterName) => Select($"SELECT AttackPoints, HealthPoints, BasicAttackRange, Speed, PhysicalDefense, MagicalDefense, FightType, Description, Quote, Author.Name FROM Character INNER JOIN Author ON Character.AuthorID = Author.ID WHERE Character.Name = '{characterName}';")[0];
    }

    public class SqliteRow
    {
        public readonly Dictionary<string, string> Data = new Dictionary<string, string>();

        public void Add(string columnName, string value) => Data.Add(columnName, value);
        public string GetValue(string columnName) => Data.FirstOrDefault(data => data.Key == columnName).Value;
    }
}