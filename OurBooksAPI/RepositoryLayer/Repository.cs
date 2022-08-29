using System.Security.Cryptography;
using System.Reflection.Emit;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System;
using ModelsLayer;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

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

    
        /// <summary>
        /// #3 Display the products and their information
        /// </summary>
        /// <param name= "productId"></param>
        /// <param name= "bookName"></param>
        /// <param name= "numberPages"></param>
        /// <param name= "genre"></param>
        /// <param name= "author"></param>
        /// <param name= "inStock"></param>
        /// <param name= "cost"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayProductAsync(string? productId, string? bookName, int? numberPages, string? genre, string? author, int? inStock, decimal? cost)
        {   // Set Azure connection an the SQL query
            SqlConnection connect = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ProductId = @pId OR BookName = @bN OR NumberPages = @nP OR Genre = @g, OR Author = @a OR inStock = @iS, Cost = @c;"))
            {   // replacement parameters to stop SQL injection
                command.Parameters.AddWithValue("@pId", productId);
                command.Parameters.AddWithValue("@bN", bookName);
                command.Parameters.AddWithValue("@nP", numberPages);
                command.Parameters.AddWithValue("@g", genre);
                command.Parameters.AddWithValue("@a", author);
                command.Parameters.AddWithValue("@iS", inStock);
                command.Parameters.AddWithValue("@c", cost);

                connect.Open(); // open connection
                SqlDataReader ret = await command.ExecuteReaderAsync(); // Reads command
                List<DisplayDTO> rtnList = new List<DisplayDTO>(); // Empty list

                while (ret.Read()) // What is displayed 
                {   
                    DisplayDTO display = new DisplayDTO(ret.GetString(0), ret.GetString(1), ret.GetInt32(2), ret.GetString(3), ret.GetString(4), ret.GetInt32(5), ret.GetDecimal(6));
                    rtnList.Add(display); // Added to empty list
                }
                connect.Close(); //Close connection
                return rtnList; //return list

            }
        }


        public object c { get; set;}

        private static readonly SqlConnection conn = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        public async Task <Credentials> GetCredentialsAsync(string email, string password)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"SELECT * FROM  Login WHERE Email = @email AND Password = @password", conn);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            if (ret.Read())
            {
                Credentials c = new Credentials(
                ret.GetString(0),
                ret.GetString(1)
                );
                return c;
            }
            else
            {
                conn.Close();
                return null;
            }
        }//EoGetCredentialsAsync

    }//EoC
}//EoN

