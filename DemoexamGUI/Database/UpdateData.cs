using Npgsql;

namespace DemoexamGUI.Database
{
    public class UpdateData
    {
        public static void UpdatePartner(int id, string type, string name, string directorF, string directorI, string directorO,
            string email, string phone, string postcode, string address, string inn, int rating)
        {
            using (var connection = Instance.GetConnection())
            {
                connection.Open();

                using (var command = new NpgsqlCommand("UPDATE partner " +
                    "SET type = @type, name = @name, director_f = @director_f, director_i = @director_i, director_o = @director_o, email = @email, phone = @phone, postcode = @postcode, address = @address, inn = @inn, rating = @rating " +
                    "WHERE id = @id", 
                    connection))
                {
                    command.Parameters.AddWithValue("id", id);
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
