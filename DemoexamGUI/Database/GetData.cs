using DemoexamGUI.Domain;
using Npgsql;

namespace DemoexamGUI.Database
{
    public class GetData
    {
        public static List<Partner> GetPartnersList()
        {
            var partnersList = new List<Partner>();

            using(var connection = Instance.GetConnection())
            {
                connection.Open();

                using (var cmd = new NpgsqlCommand("SELECT * " +
                    "FROM partner", 
                    connection))
                 
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

        public static List<Product> GetProductsList()
        {
            var productsList = new List<Product>();

            using (var connection = Instance.GetConnection())
            {
                connection.Open();

                using (var cmd = new NpgsqlCommand("SELECT * " +
                    "FROM product",
                    connection))

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productsList.Add(new Product()
                        {
                            Id = reader.GetInt32(0),
                            TypeId = reader.GetInt32(1),
                            Material = reader.GetString(2),
                            Scheme = reader.GetString(3),
                            ProductClass = reader.GetString(4),
                            ThicknessMm = reader.GetInt32(5),
                            Chamfered = reader.GetBoolean(6),
                            Article = reader.GetString(7),
                            MinCost = reader.GetInt32(8)
                        });
                    }
                }
            }

            return productsList;
        }

        public static List<ProductType> GetProductTypesList()
        {
            var productTypesList = new List<ProductType>();

            using (var connection = Instance.GetConnection())
            {
                connection.Open();

                using (var cmd = new NpgsqlCommand("SELECT * " +
                    "FROM product_type",
                    connection))

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productTypesList.Add(new ProductType()
                        {
                            Id = reader.GetInt32(0),
                            Type = reader.GetString(1),
                            TypeCoefficient = reader.GetInt32(2)
                        });
                    }
                }
            }

            return productTypesList;
        }

        public static List<PartnerProduct> GetPartnerProductsList()
        {
            var partnerProductsList = new List<PartnerProduct>();

            using (var connection = Instance.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * " +
                    "FROM partner_product", 
                    connection))
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
