using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using CLDVPart1.Models;
namespace CLDVPart1.Models
{
    public class ProductDisplayModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        public bool Availability { get; set; }

        public string Image { get; set; }



        public ProductDisplayModel(int id, string name, string description, decimal price, decimal quantity, bool availability, string image)
        {
            ID = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Availability = availability;
            Image = image;
        }

        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Server=tcp:st10285153.database.windows.net,1433;Initial Catalog=ST10285153;Persist Security Info=False;User ID=azureuser;Password=@Wul12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT product_id, productName, productDescription, productPrice, productQuantity, productAvailability, productImage FROM tblProducts";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Pass the required arguments to the ProductDisplayModel constructor
                    ProductDisplayModel product = new ProductDisplayModel(
                        Convert.ToInt32(reader["product_id"]),
                        Convert.ToString(reader["productName"]),
                        Convert.ToString(reader["productDescription"]),
                        Convert.ToDecimal(reader["productPrice"]),
                        Convert.ToDecimal(reader["productQuantity"]),
                        Convert.ToBoolean(reader["productAvailability"]),
                        Convert.ToString(reader["productImage"]));
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}