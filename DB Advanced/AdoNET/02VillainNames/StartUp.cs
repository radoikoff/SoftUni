namespace _02VillainNames
{
    using _01_InitialSetup;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villanInfo = "SELECT v.Name AS VillanName, COUNT(MinionId) AS MinionCount FROM Villains AS v JOIN MinionsVillains AS mv ON mv.VillainId = v.Id GROUP BY v.Name HAVING COUNT(MinionId) >= 3 ORDER BY COUNT(MinionId) DESC";

                using (SqlCommand cmd = new SqlCommand(villanInfo, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]}");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
