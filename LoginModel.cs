using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
namespace CLDVPart1.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:st10285153.database.windows.net,1433;Initial Catalog=ST10285153;Persist Security Info=False;User ID=azureuser;Password=@Wul12345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int SelectUser(string email, string password)
        {
            int userId = -1;
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT user_id FROM tblUsers WHERE userEmail = @Email AND userPassword = @Password";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    userId = Convert.ToInt32(result);
                }
            }
            return userId;
        }
    }
}
