using Npgsql;

namespace DemoexamGUI.Database
{
    public class AddData
    {
        public static void AddPartner(string type, string name, string directorF, string directorI, string directorO,
            string email, string phone, string postcode, string address, string inn, int rating)
        {
            using (var connection = Instance.GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("INSERT INTO partner (type, name, director_f, director_i, director_o, email, phone, postcode, address, inn, rating) " +
                    "VALUES (@type, @name, @director_f, @director_i, @director_o, @email, @phone, @postcode, @address, @inn, @rating)", 
                    connection))
                {
                    command.Parameters.AddWithValue("type", type);
                    command.Parameters.AddWithValue("name", name);
                    command.Parameters.AddWithValue("director_f", directorF);
                    command.Parameters.AddWithValue("director_i", directorI);
                    command.Parameters.AddWithValue("director_o", directorO);
                    command.Parameters.AddWithValue("email", email);
                    command.Parameters.AddWithValue("phone", phone);
                    command.Parameters.AddWithValue("postcode", postcode);
                    command.Parameters.AddWithValue("address", address);
                    command.Parameters.AddWithValue("inn", inn);
                    command.Parameters.AddWithValue("rating", rating);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
