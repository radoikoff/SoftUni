namespace _05.ChangeTownNamesCasing
{
    using _01_InitialSetup;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            string countryName = Console.ReadLine().Trim();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int countryId = GetCountryId(countryName, connection);

                if (countryId == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    int affectedTownsCount = UpdateTownsNames(countryId, connection);
                    List<string> townNames = GetUpdatedTownNames(countryId, connection);
                    Console.WriteLine($"{affectedTownsCount} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", townNames)}]");
                }

                connection.Close();
            }
        }

        private static List<string> GetUpdatedTownNames(int countryId, SqlConnection connection)
        {
            List<string> townNames = new List<string>();
            string townsSql = "SELECT Name FROM Towns WHERE CountryCode = @countryId";
            using (SqlCommand cmd = new SqlCommand(townsSql, connection))
            {
                cmd.Parameters.AddWithValue("@countryId", countryId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        townNames.Add((string)reader[0]);
                    }
                }
            }
            return townNames;
        }

        private static int UpdateTownsNames(int countryId, SqlConnection connection)
        {
            string updateSql = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = @countryId";
            using (SqlCommand cmd = new SqlCommand(updateSql, connection))
            {
                cmd.Parameters.AddWithValue("@countryId", countryId);
                return cmd.ExecuteNonQuery();
            }
        }

        private static int GetCountryId(string countryName, SqlConnection connection)
        {
            string countryIdSql = "SELECT TOP(1) c.Id FROM Towns AS t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @name";
            using (SqlCommand cmd = new SqlCommand(countryIdSql, connection))
            {
                cmd.Parameters.AddWithValue("@name", countryName);

                if (cmd.ExecuteScalar() == null)
                {
                    return 0;
                }

                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
