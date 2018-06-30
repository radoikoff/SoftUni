namespace _03.MinionNames
{
    using _01_InitialSetup;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            int villanId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villanName = GetVillanName(villanId, connection);

                if (villanName == null)
                {
                    Console.WriteLine($"No villain with ID {villanId} exists in the database.");
                }
                else
                {
                    Console.WriteLine($"Villain: {villanName}");
                    foreach (var minion in MinionsInfo(villanId, connection))
                    {
                        Console.WriteLine(minion);
                    }
                }

                connection.Close();
            }
        }

        private static List<string> MinionsInfo(int villanId, SqlConnection connection)
        {
            List<string> minions = new List<string>();
            string minionsSql = "SELECT m.Name, m.Age FROM Minions AS m JOIN MinionsVillains AS mv ON mv.MinionId = m.Id WHERE VillainId = @Id";

            using (SqlCommand cmd = new SqlCommand(minionsSql, connection))
            {
                cmd.Parameters.AddWithValue("@Id", villanId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        minions.Add("(no minions)");
                    }
                    else
                    {
                        int number = 1;
                        while (reader.Read())
                        {
                            minions.Add($"{number++}. {reader["Name"]} {reader["Age"]}");
                        }
                    }
                }
            }

            return minions;
        }

        private static string GetVillanName(int villanId, SqlConnection connection)
        {
            string villanName = "SELECT Name FROM Villains WHERE Id = @Id";

            using (SqlCommand cmd = new SqlCommand(villanName, connection))
            {
                cmd.Parameters.AddWithValue("@Id", villanId);
                return (string)cmd.ExecuteScalar();
            }
        }
    }
}
