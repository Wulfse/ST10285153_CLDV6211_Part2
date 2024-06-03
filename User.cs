using Microsoft.Data.SqlClient;
using System;

namespace CLDVPart1.Models
{
    public class User
    {
        public static string con_string = "Server=tcp:st10285153.database.windows.net,1433;Initial Catalog=ST10285153;Persist Security Info=False;User ID=azureuser;Password=@Wul12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static SqlConnection con = new SqlConnection(con_string);

        public int UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int insert_User(User m)
        {
            string sql = "INSERT INTO tblUsers (userName, userSurname, userEmail, userPassword) VALUES (@Name, @Surname, @Email, @Password)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Name", m.Name);
            cmd.Parameters.AddWithValue("@Surname", m.Surname);
            cmd.Parameters.AddWithValue("@Email", m.Email);
            cmd.Parameters.AddWithValue("@Password", m.Password);
            con.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsAffected;
        }
    }
}