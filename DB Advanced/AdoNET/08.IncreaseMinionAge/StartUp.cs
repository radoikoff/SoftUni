namespace _08.IncreaseMinionAge
{
    using _01_InitialSetup;
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
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
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }

        private static void IncreaseMinionAge(int id, SqlConnection connection)
        {
            string minionsSql = "UPDATE Minions SET Age+=1 WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(minionsSql, connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
