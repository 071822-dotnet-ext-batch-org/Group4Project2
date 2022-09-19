using System.Security.Cryptography;
using System.Reflection.Emit;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System;
using ModelsLayer;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Data;

namespace RepositoryLayer
{
    public class Repository
    {
        //To query whether the customer account credentials exist
        public async Task<bool> EmailPassWordExists(string email, string password)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Login WHERE Email = @email AND Password = @password", connect))
            {
                command.Parameters.AddWithValue("@email", email);// add dynamic data like this to protect against SQL Injection.
                command.Parameters.AddWithValue("@password", password);
                connect.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    connect.Close();
                    return true;
                }
                connect.Close();
                return false;
            }
        }

        //To insert the unique new customer into the database 
        public async Task<NewCustomer> InsertNewCustomer(Guid id, CustomerRegisterDto nc)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"INSERT INTO Users (UserId, FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin) VALUES (@UserId, @FirstName, @LastName, @DeliveryAddress, @Phone, @Email, @isAdmin) ", connect);
            {
                command.Parameters.AddWithValue("@UserId", nc.UserId);
                command.Parameters.AddWithValue("@FirstName", nc.FirstName);//declare scalar variable, add dynamic data like this to avoid sql injection
                command.Parameters.AddWithValue("@LastName", nc.LastName);
                command.Parameters.AddWithValue("@DeliveryAddress", nc.DeliveryAddress);
                command.Parameters.AddWithValue("@Phone", nc.Phone);
                command.Parameters.AddWithValue("@Email", nc.Email);
                command.Parameters.AddWithValue("@isAdmin", nc.isAdmin);

                connect.Open();// Opening Connection
                int ret = await command.ExecuteNonQueryAsync();
                if (ret == 1)
                {
                    connect.Close();
                    NewCustomer urbi = await this.CustomerById(id);
                    return urbi;
                }
                connect.Close();
                return null;
            }
        }

        //To query only new customers based on the unique guid id 
        private async Task<NewCustomer> CustomerById(Guid id)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT FirstName, LastName, DeliveryAddress, Phone, Email, isAdmin FROM Users WHERE UserID = @id", connect))
            {
                command.Parameters.AddWithValue("@id", id);// add dynamic data like this to protect against SQL Injection.
                connect.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                if (ret.Read())
                {
                    NewCustomer nc = new NewCustomer(ret.GetString(0), ret.GetString(1), ret.GetString(2), ret.GetString(3), ret.GetString(4), ret.GetString(5));
                    connect.Close();
                    return nc;
                }
                connect.Close();
                return null;
            }
        }


        /// <summary>
        /// #3 Display all information
        /// </summary>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayAllAsync()
        {   // Connection to Azure server
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products", connect)) // SQL query in Azure DB
            {
                connect.Open(); // Open sql connection
                SqlDataReader? ret = await command.ExecuteReaderAsync(); // Reads command
                List<DisplayDTO> rtnList = new List<DisplayDTO>(); // Creates empty DisplayDTO list

                while (ret.Read()) // Loops through ret command
                {   // Gets properties for DisplayDTO
                    DisplayDTO display = new DisplayDTO(ret.GetString(0), ret.GetString(1), ret.GetInt32(2), ret.GetString(3), ret.GetString(4), ret.GetInt32(5), ret.GetDecimal(6));
                    rtnList.Add(display); // Adds display to empty rtnList
                }
                connect.Close(); // Closes connection
                return rtnList;
            }

        }

        /// <summary>
        /// #3 Display filtered books by name
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayNameAsync(string bookName)
        {
            // Connection to Azure server
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products WHERE BookName = @name", connect)) // SQL query in Azure DB
            {   // Parameters to stop sql injection
                command.Parameters.AddWithValue("@name", bookName);

                connect.Open(); // Open sql connection
                SqlDataReader? ret = await command.ExecuteReaderAsync(); // Reads command
                List<DisplayDTO> rtnList = new List<DisplayDTO>(); // Creates empty DisplayDTO list

                while (ret.Read()) // Loops through ret command
                {   // Gets properties for DisplayDTO
                    DisplayDTO display = new DisplayDTO(ret.GetString(0), ret.GetString(1), ret.GetInt32(2), ret.GetString(3), ret.GetString(4), ret.GetInt32(5), ret.GetDecimal(6));
                    rtnList.Add(display); // Adds display to empty rtnList
                }
                connect.Close(); // Closes connection
                return rtnList;
            }
        }

        /// <summary>
        /// #3 Display Books by genre 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayGenreAsync(string genre)
        {   // Connection to Azure server
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products WHERE Genre = @genre", connect)) // SQL query in Azure DB
            {
                command.Parameters.AddWithValue("@genre", genre); // Parameters to stop SQL injection

                connect.Open();// Open sql connection
                SqlDataReader? ret = await command.ExecuteReaderAsync(); // Reads command
                List<DisplayDTO> rtnList = new List<DisplayDTO>(); // Creates empty DisplayDTO list

                while (ret.Read()) // Loops through ret command
                {   // Gets properties for DisplayDTO
                    DisplayDTO display = new DisplayDTO(ret.GetString(0), ret.GetString(1), ret.GetInt32(2), ret.GetString(3), ret.GetString(4), ret.GetInt32(5), ret.GetDecimal(6));
                    rtnList.Add(display); // Adds display to empty rtnList
                }
                connect.Close(); // Closes conection
                return rtnList;
            }
        }

        /// <summary>
        /// #3 Display filtered books by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayAuthorAsync(string author)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products WHERE Author = @author", connect)) // SQL query in Azure DB
            {
                command.Parameters.AddWithValue("@author", author); // Parameters to stop SQL injection

                connect.Open();// Open sql connection
                SqlDataReader? ret = await command.ExecuteReaderAsync(); // Reads command
                List<DisplayDTO> rtnList = new List<DisplayDTO>(); // Creates empty DisplayDTO list

                while (ret.Read()) // Loops through ret command
                {   // Gets properties for DisplayDTO
                    DisplayDTO display = new DisplayDTO(ret.GetString(0), ret.GetString(1), ret.GetInt32(2), ret.GetString(3), ret.GetString(4), ret.GetInt32(5), ret.GetDecimal(6));
                    rtnList.Add(display); // Adds display to empty rtnList
                }
                connect.Close(); // Closes conection
                return rtnList;
            }
        }

        /// <summary>
        /// #3 Display filtered books by cost > $30
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayHighCostAsync(decimal cost)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products WHERE Cost >= 30;", connect)) // SQL query in Azure DB
            {
                connect.Open();// Open sql connection
                SqlDataReader? ret = await command.ExecuteReaderAsync(); // Reads command
                List<DisplayDTO> rtnList = new List<DisplayDTO>(); // Creates empty DisplayDTO list

                while (ret.Read()) // Loops through ret command
                {   // Gets properties for DisplayDTO
                    DisplayDTO display = new DisplayDTO(ret.GetString(0), ret.GetString(1), ret.GetInt32(2), ret.GetString(3), ret.GetString(4), ret.GetInt32(5), ret.GetDecimal(6));
                    rtnList.Add(display); // Adds display to empty rtnList
                }
                connect.Close(); // Closes conection
                return rtnList;
            }
        }

        /// <summary>
        /// #3 Display filtered books cost < $30
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayLowCostAsync(decimal cost)
        {
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Products WHERE Cost < 30;", connect)) // SQL query in Azure DB
            {
                connect.Open();// Open sql connection
                SqlDataReader? ret = await command.ExecuteReaderAsync(); // Reads command
                List<DisplayDTO> rtnList = new List<DisplayDTO>(); // Creates empty DisplayDTO list

                while (ret.Read()) // Loops through ret command
                {   // Gets properties for DisplayDTO
                    DisplayDTO display = new DisplayDTO(ret.GetString(0), ret.GetString(1), ret.GetInt32(2), ret.GetString(3), ret.GetString(4), ret.GetInt32(5), ret.GetDecimal(6));
                    rtnList.Add(display); // Adds display to empty rtnList
                }
                connect.Close(); // Closes conection
                return rtnList;
            }
        }

        /// <summary>
        /// #5 Checkout payment
        /// </summary>
        /// <param name="checkout"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        // public async Task<List<CheckoutDTO>> CheckoutAsync(cartId)
        // {
        //     SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //     using (SqlCommand command = new SqlCommand($"SELECT * FROM Cart WHERE CartId = @cart", connect))
        //     {
        //         command.Parameters.AddWithValue("@cart", cartId);

        //         connect.Open();

        //         SqlDataReader? ret = await command.ExecuteReaderAsync();

        //         if (ret.Read())
        //         {
        //             List<CheckoutDTO> check = new CheckoutDTO(ret.GetGuid(0), ret.GetString(1), ret.GetDecimal(2), ret.GetBoolean(3));
        //             return check;
        //         }
        //         else
        //         {
        //             connect.Close();
        //             return null;
        //         }
        //     }
        // }

        public object c { get; set;}

        private static readonly SqlConnection conn = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        public async Task <Credentials> GetCredentialsAsync(string email, string password)
        {
            SqlConnection conn = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"SELECT * FROM Login WHERE Email = @email AND Password = @password", conn);
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


         public async Task<List<ProfileDTO>> DisplayCurrentProfileAsync(string email)
         {
            SqlConnection conn = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using SqlCommand command = new SqlCommand($"SELECT FirstName, LastName, DeliveryAddress, Phone, Email FROM MasterTable WHERE Email=@Email;", conn);
            command.Parameters.AddWithValue("@Email", email);
            conn.Open();
            SqlDataReader? ret = await command.ExecuteReaderAsync();
            List<ProfileDTO> rtnList = new List<ProfileDTO>();
            while (ret.Read())
            {
                ProfileDTO profile = new ProfileDTO(ret.GetString(0), ret.GetString(1), ret.GetString(2), ret.GetString(3), ret.GetString(4));
                rtnList.Add(profile);
            }
            conn.Close();
            return rtnList;
         }//EoDisplayProfileAsync


  

        //To query the orders table to return order information using the Guid orderTracker
        public async Task<List<ViewOrder>> ViewOrderAsync()
        {
            SqlConnection connect = new SqlConnection("Server=tcp:proj2.database.windows.net,1433;Initial Catalog=Project2_DB;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand($"SELECT * FROM Orders", connect))
            {
                connect.Open();
                SqlDataReader? ret = await command.ExecuteReaderAsync();
                List<ViewOrder> rList = new List<ViewOrder>();
                while (ret.Read())
                {
                    ViewOrder r = new ViewOrder(ret.GetGuid(0), ret.GetString(1), ret.GetDecimal(2), ret.GetString(3), ret.GetString(4), ret.GetString(5), ret.GetGuid(6));
                    rList.Add(r);
                }
                connect.Close();
                return rList;
            }
        }


     
    }//EoC
}//EoN
