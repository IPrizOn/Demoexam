using Npgsql;

namespace DemoexamGUI.Database
{
    internal class Instance
    {
        private static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=13799731;Database=partners_exam";

        public static NpgsqlConnection GetConnection()
        {
            var connection = new NpgsqlConnection(connectionString);

            return connection;
        }
    }
}
