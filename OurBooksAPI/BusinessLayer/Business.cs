
using System.Globalization;
using System.Net.Http.Headers;
using ModelsLayer;
using RepositoryLayer;

namespace BusinessLayer
{
    public class Business 
    {
        private Repository _repo = new Repository();
        /*
        private readonly Repository _repositoryLayer; // Private field for Business constructor
        public Business() // Constructor linking to the RepositoryLayer
        {
            this._repositoryLayer = new Repository();
        }
        */
        /// <summary>
        /// #3 Display products
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="BookName"></param>
        /// <param name="NumberPages"></param>
        /// <param name="Genre"></param>
        /// <param name="Author"></param>
        /// <param name="InStock"></param>
        /// <param name="Cost"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayProductAsync(string? ProductId, string? BookName, int? NumberPages, string? Genre, string? Author, int? InStock, decimal? Cost)
        {   // create list result from repo layer
            List<DisplayDTO> result = await this._repo.DisplayProductAsync(ProductId, BookName, NumberPages, Genre, Author, InStock, Cost);
            return result; // Return 
        }

//method to register a new account and input new customer info
        public async Task<RegisterAccount> RegisterAccountAsync(Guid userId, string? firstName, string? lastName, string? deliveryAddress, string? phone, string? email, string? isAdmin)
        {
            RegisterAccount customerInfo = await this._repo.RegisterAccountAsync(userId, firstName, lastName, deliveryAddress, phone, email, isAdmin);
            return customerInfo;
            
        }



        private Credentials? _CurrentCredentials = null;

        public async Task<bool> LoginAsync(string email, string password)
        {
            Credentials? c = await this._repo.GetCredentialsAsync(email, password);
            if (c != null && c.Email == email && c.Password == password) //If useer is in directory with this email and password
            {
                _CurrentCredentials = c;
                return true;
            }
            return false;
        }//EoLoginAsync

    }//EoC
}//EoN
