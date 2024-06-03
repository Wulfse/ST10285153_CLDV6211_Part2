using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public DataTable GetProducts()
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }

    public void InsertUser(string username, string passwordHash, string email)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, PasswordHash, Email) VALUES (@Username, @PasswordHash, @Email)", conn);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.ExecuteNonQuery();
        }
    }

    // Add more methods as needed...
}