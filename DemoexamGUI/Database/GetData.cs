using DemoexamGUI.Domain;
using Npgsql;

namespace DemoexamGUI.Database
{
    public class GetData
    {
        public static List<Partner> GetPartners()
        {
            var partnersList = new List<Partner>();

            using(var connection = Instance.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM partner", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        partnersList.Add(new Partner()
                        {
                            Id = reader.GetInt32(0),
                            Type = reader.GetString(1),
                            Name = reader.GetString(2),
                            DirectorF = reader.GetString(3),
                            DirectorI = reader.GetString(4),
                            DirectorO = reader.GetString(5),
                            Email = reader.GetString(6),
                            Phone = reader.GetString(7),
                            Postcode = reader.GetString(8),
                            Address = reader.GetString(9),
                            INN = reader.GetString(10),
                            Rating = reader.GetInt32(11)
                        });
                    }
                }
            }      

            return partnersList;
        }

        public static List<PartnerProduct> GetPartnerProduct()
        {
            var partnerProductsList = new List<PartnerProduct>();

            using (var connection = Instance.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM partner_product", connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        partnerProductsList.Add(new PartnerProduct()
                        {
                            Id = reader.GetInt32(0),
                            ProductId = reader.GetInt32(1),
                            PartnerId = reader.GetInt32(2),
                            Count = reader.GetInt32(3),
                            SaleAt = reader.GetDateTime(4)
                        });
                    }
                }
            }

            return partnerProductsList;
        }
    }
}
