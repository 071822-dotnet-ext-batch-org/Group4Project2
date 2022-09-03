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
        /// #3 Display all books
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayAllAsync(string bookName)
        {
            List<DisplayDTO> display = await this._repo.DisplayAllAsync(); // Creates display list from repo query
            return display; 
        }

        /// <summary>
        /// #3 Display filtered books by name
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayNameAsync(string bookName)
        {
            List<DisplayDTO> display = await this._repo.DisplayNameAsync(bookName); // Creates display list from repo query
            return display;
        }

        /// <summary>
        /// #3 display filtered books by genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayGenreAsync(string genre)
        {
            List<DisplayDTO> display = await this._repo.DisplayGenreAsync(genre); // Creates display list from repo query
            return display;
        }

        /// <summary>
        /// #3 Display filtered books by author
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayAuthorAsync(string author)
        {
            List<DisplayDTO> display = await this._repo.DisplayAuthorAsync(author); // Creates display list from repo query
            return display;
        }


        /// <summary>
        /// #3 Display filteded books by cost
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        public async Task<List<DisplayDTO>> DisplayCostAsync(decimal cost)
        {
            if (cost < 30)
            {
                List<DisplayDTO> display = await this._repo.DisplayLowCostAsync(cost); // Creates display list from repo query
                return display;
            }
            else
            {
                List<DisplayDTO> display = await this._repo.DisplayHighCostAsync(cost); // Creates display list from repo query
                return display;
            }
        }

        /// <summary>
        /// #5 Checkout payment
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<CheckoutDTO>> CheckoutAsync(cartId)
        {
            List<CheckoutDTO> check = await this._repo.CheckoutAsync(cartId); // Creates display list from repo query
            return check;
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



        public async Task<List<ProfileDTO>> DisplayProfileAsync(string email, string password)
        {
            List<ProfileDTO> profile = await this._repo.DisplayCurrentProfileAsync(email, password);//Returns profile from repo
            return profile;
        }//EoDisplayProfileAsync


        public async Task<List<ViewOrder>> ViewOrderAsync(Guid OrderTracker)
        {
            List<ViewOrder> order = await this._repo.ViewOrderAsync(OrderTracker); // Generates an order list from repo query
            return order;
        }


    }//EoC
}//EoN
