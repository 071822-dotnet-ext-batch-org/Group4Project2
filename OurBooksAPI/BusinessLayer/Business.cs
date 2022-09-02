
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


        public async Task<NewCustomer> RegisterAccountAsync(CustomerRegisterDto nc)
        {
            // check if the user is already in the Db.
            bool exists = await this._repo.EmailPassWordExists(nc.Email, nc.password);
            if (exists)
            {
                return null;
            }
            else
            {
                //insert the user into the Db with a new Guid.
                Guid guid = Guid.NewGuid();
                NewCustomer nc1 = await this._repo.InsertNewCustomer(guid, nc);
                return nc1;
            }
        }


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

        /*--OLD
        //method to register a new account and input new customer info
        public async Task<RegisterAccount> RegisterAccountAsync(Guid userId, string? firstName, string? lastName, string? deliveryAddress, string? phone, string? email, string? isAdmin)
        {
            RegisterAccount customerInfo = await this._repo.RegisterAccountAsync(userId, firstName, lastName, deliveryAddress, phone, email, isAdmin);
            return customerInfo;
        }
        */
            

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
