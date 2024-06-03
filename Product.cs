using Microsoft.Data.SqlClient;
using System;
using System.Data.SqlClient;
namespace CLDVPart1.Models
{
    public class Product
    {
        public static string con_string = "Server=tcp:st10285153.database.windows.net,1433;Initial Catalog=ST10285153;Persist Security Info=False;User ID=azureuser;Password=@Wul12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);

        public string productName { get; set; }

        public string productDescription { get; set; }

        public decimal productPrice { get; set; }

        public decimal productQuantity { get; set; }

        public bool productAvailability { get; set; }

        public string productImage { get; set; }
        
        public int productID { get; set; }  
        public int insert_Product(Product m)
        {
            string sql = "INSERT INTO tblProducts (productName, productDescription, productPrice, productQuantity, productAvailability, productImage) VALUES (@productName, @productDescription, @productPrice, @productQuantity, @productAvailability, @productImage)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@productName", m.productName);
            cmd.Parameters.AddWithValue("@productDescription", m.productDescription);
            cmd.Parameters.AddWithValue("@productPrice", m.productPrice);
            cmd.Parameters.AddWithValue("@productQuantity", m.productQuantity);
            m.productAvailability = m.productQuantity > 0;
            cmd.Parameters.AddWithValue("@productAvailability", m.productAvailability);
            cmd.Parameters.AddWithValue("@productImage", m.productImage);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }

        public static List<Product> get_Products()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM tblProducts";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.productID = Convert.ToInt32(reader["ProductID"]);
                            product.productName = Convert.ToString(reader["ProductName"]);
                            product.productDescription = Convert.ToString(reader["ProductDescription"]);
                            product.productPrice = Convert.ToDecimal(reader["ProductPrice"]);
                            // Populate other properties as needed...
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}