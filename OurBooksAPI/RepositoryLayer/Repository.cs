using ModelsLayer;
using Microsoft.Data.SqlClient;



namespace RepositoryLayer
{
    public class Repository
    {
        public async Task<RegisterAccount> RegisterAccountAsync(Guid userId, string? firstName, string? lastName, string? deliveryAddress, string? phone, string? email, string? isAdmin)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"INSERT INTO Users (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES ( @UserId, @FirstName, @LastName, @DeliveryAddress, @Phone, @Email, @isAdmin) ", connect);
            {
                command.Parameters.AddWithValue("@UserId", userId);//declare scalar variable, add dynamic data like this to avoid sql injection
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@DeliveryAddress", deliveryAddress);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@isAdmin", isAdmin);

                connect.Open();// Opening Connection
                SqlDataReader? ret = await command.ExecuteReaderAsync();// Executing the SQL query 
                if (ret.Read())
                {
                    RegisterAccount c_info = new RegisterAccount(ret.GetGuid(0), ret.GetString(1), ret.GetString(2), ret.GetString(3), ret.GetString(4), ret.GetString(5), ret.GetString(6));
                    connect.Close();
                    return c_info;

                }
                connect.Close();
                return null;
            }
        }

        
    }
}