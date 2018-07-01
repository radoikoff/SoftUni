namespace _07.PrintAllMinionNames
{
    using _01_InitialSetup;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string[] rawMinions = GetMinionsNames(connection);

                int leftIndex = 0;
                int rightIndex = rawMinions.Length - 1;
                int processedItems = 0;
                while (true)
                {
                    Console.WriteLine(rawMinions[leftIndex]);
                    leftIndex++;
                    processedItems++;
                    if (processedItems >= rawMinions.Length)
                    {
                        break;
                    }
                    Console.WriteLine(rawMinions[rightIndex]);
                    rightIndex--;
                    processedItems++;
                    if (processedItems >= rawMinions.Length)
                    {
                        break;
                    }
                }

                connection.Close();
            }
        }

        private static string[] GetMinionsNames(SqlConnection connection)
        {
            List<string> minions = new List<string>();

            string minionsSql = "SELECT Name FROM Minions";
            using (SqlCommand cmd = new SqlCommand(minionsSql, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minions.Add((string)reader[0]);
                    }
                }
            }

            return minions.ToArray();
        }
    }
}
