namespace _06.RemoveVillain
{
    using _01_InitialSetup;
    using System.Data.SqlClient;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                string villainName = GetVillainName(villainId, connection, transaction);

                if (villainName != null)
                {
                    try
                    {
                        int affectedMinions = ReleaseMinions(villainId, connection, transaction);
                        DeleteVillain(villainId, connection, transaction);
                        Console.WriteLine($"{villainName} was deleted.");
                        Console.WriteLine($"{affectedMinions} minions were released.");
                    }
                    catch (SqlException ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine(ex.Message);
                    }

                }
                else
                {
                    Console.WriteLine("No such villain was found.");
                }

                connection.Close();
            }
        }

        private static void DeleteVillain(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            string sqlQuery = "DELETE FROM Villains WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@Id", villainId);
                cmd.ExecuteNonQuery();
            }
        }

        private static int ReleaseMinions(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            string sqlQuery = "DELETE FROM MinionsVillains WHERE VillainId = @Id";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@Id", villainId);
                return cmd.ExecuteNonQuery();
            }
        }

        private static string GetVillainName(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            string sqlQuery = "SELECT Name FROM Villains WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(sqlQuery, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@Id", villainId);
                return (string)cmd.ExecuteScalar();
            }
        }
    }
}
