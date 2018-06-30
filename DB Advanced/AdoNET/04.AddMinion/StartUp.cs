namespace _04.AddMinion
{
    using _01_InitialSetup;
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            string[] minionsInfo = Console.ReadLine().Split();
            string[] villiantInfo = Console.ReadLine().Split();

            string minionName = minionsInfo[1];
            int age = int.Parse(minionsInfo[2]);
            string townName = minionsInfo[3];

            string villiantName = villiantInfo[1];




            using (SqlConnection connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                int townId = GetTownId(townName, connection);
                int villaintId = GetVillaintId(villiantName, connection);
                int minionId = InsertMinion(minionName, age, townId, connection);
                AssignMinionToVillaint(villaintId, minionId, connection);
                Console.WriteLine($"Successfully added {minionName} to be minion of {villiantName}.");

                connection.Close();
            }
        }

        private static void AssignMinionToVillaint(int villaintId, int minionId, SqlConnection connection)
        {
            string insertMinionToVillaintSql = "INSERT INTO MinionsVillains (VillainId, MinionId) VALUES (@villaintId, @minionId)";

            using (SqlCommand cmd = new SqlCommand(insertMinionToVillaintSql, connection))
            {
                cmd.Parameters.AddWithValue("@villaintId", villaintId);
                cmd.Parameters.AddWithValue("@minionId", minionId);
                cmd.ExecuteNonQuery();
            }
        }

        private static int InsertMinion(string minionName, int age, int townId, SqlConnection connection)
        {
            string insertMinionSql = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand cmd = new SqlCommand(insertMinionSql, connection))
            {
                cmd.Parameters.AddWithValue("@name", minionName);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@TownId", townId);
                cmd.ExecuteNonQuery();
            }

            string getMinionIdSql = "SELECT TOP(1) Id FROM Minions WHERE Name = @name AND Age = @age AND TownId = @townId";

            using (SqlCommand cmd = new SqlCommand(getMinionIdSql, connection))
            {
                cmd.Parameters.AddWithValue("@name", minionName);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@TownId", townId);
                return (int)cmd.ExecuteScalar();
            }
        }

        private static int GetVillaintId(string villiantName, SqlConnection connection)
        {
            string villaintIdSql = "SELECT Id FROM Villains WHERE Name = @ViliantName";

            using (SqlCommand cmd = new SqlCommand(villaintIdSql, connection))
            {
                cmd.Parameters.AddWithValue("@ViliantName", villiantName);
                if (cmd.ExecuteScalar() == null)
                {
                    InsertIntoVillains(villiantName, connection);
                }

                return (int)cmd.ExecuteScalar();
            }
        }

        private static void InsertIntoVillains(string villiantName, SqlConnection connection)
        {
            string insertTownSql = "INSERT INTO Villains (Name) VALUES (@Name)";
            using (SqlCommand cmd = new SqlCommand(insertTownSql, connection))
            {
                cmd.Parameters.AddWithValue("@Name", villiantName);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Villain {villiantName} was added to the database.");
            }
        }

        private static int GetTownId(string townName, SqlConnection connection)
        {
            string townIdSql = "SELECT Id FROM Towns WHERE Name = @TownName";

            using (SqlCommand cmd = new SqlCommand(townIdSql, connection))
            {
                cmd.Parameters.AddWithValue("@TownName", townName);
                if (cmd.ExecuteScalar() == null)
                {
                    InsertIntoTowns(townName, connection);
                }

                return (int)cmd.ExecuteScalar();
            }
        }

        private static void InsertIntoTowns(string townName, SqlConnection connection)
        {
            string insertTownSql = "INSERT INTO Towns (Name) VALUES (@townName)";
            using (SqlCommand cmd = new SqlCommand(insertTownSql, connection))
            {
                cmd.Parameters.AddWithValue("@TownName", townName);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Town {townName} was added to the database.");
            }
        }
    }
}
