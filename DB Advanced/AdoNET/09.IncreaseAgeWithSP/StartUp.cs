namespace _09.IncreaseAgeWithSP
{
    using _01_InitialSetup;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                foreach (var id in minionIds)
                {
                    IncreaseMinionAge(id, connection);
                }

                PrintAllMinions(connection);

                connection.Close();
            }
        }

        private static void PrintAllMinions(SqlConnection connection)
        {
            string sqlQuery = "SELECT Name, Age FROM Minions";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
                    }
                }
            }
        }

        private static void IncreaseMinionAge(int id, SqlConnection connection)
        {
            string updateUspName = "usp_GetOlder";
            using (SqlCommand cmd = new SqlCommand(updateUspName, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

