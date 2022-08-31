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
    
        /// <summary>
        /// #3 Display the products and their information
        /// </summary>
        /// <param name= "Isbn"></param>
        /// <param name= "BookName"></param>
        /// <param name= "NumberPages"></param>
        /// <param name= "Genre"></param>
        /// <param name= "Author"></param>
        /// <param name= "InStock"></param>
        /// <param name= "Cost"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayProductAsync(string? Isbn, string? BookName, int? NumberPages, string? Genre, string? Author, int? InStock, decimal? Cost)
        {   // Set Azure connection an the SQL query
            SqlConnection connect = new SqlConnection("Server=tcp:group4project.database.windows.net,1433;Initial Catalog=group4projectserver;Persist Security Info=False;User ID=Project2User;Password=Group4usesmac;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            using (SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE ISBN = @pId AND BookName = @bN AND NumberPages = @nP AND Genre = @g AND Author = @a AND inStock = @iS AND Cost = @c;", connect))
            {   // replacement parameters to stop SQL injection
                command.Parameters.AddWithValue("@pId", Isbn);
                command.Parameters.AddWithValue("@bN", BookName);
                command.Parameters.AddWithValue("@nP", NumberPages);
                command.Parameters.AddWithValue("@g", Genre);
                command.Parameters.AddWithValue("@a", Author);
                command.Parameters.AddWithValue("@iS", InStock);
                command.Parameters.AddWithValue("@c", Cost);

                connect.Open(); // open connection

                SqlDataReader? ret = await command.ExecuteReaderAsync(); // Reads command
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
