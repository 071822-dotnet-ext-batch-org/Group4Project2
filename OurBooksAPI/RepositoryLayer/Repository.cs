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

namespace RepositoryLayer
{
    public class Repository
    {   
        /// <summary>
        /// #3 Display all information
        /// </summary>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayAllAsync()
        {   // Connection to Azure server
            SqlConnection connect = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
        /// #3 Display Books by genre 
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayGenreAsync(string genre)
        {   // Connection to Azure server
            SqlConnection connect = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            SqlConnection connect = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            SqlConnection connect = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            SqlConnection connect = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
