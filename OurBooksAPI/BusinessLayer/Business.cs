using ModelsLayer;
using RepositoryLayer;


namespace BusinessLayer
{
    public class Business
    {
        private readonly Repository _repo; 
        public Business() 
        {
            this._repo = new Repository();
        }
        //private Repository _repo = new Repository();

        //method to register a new account and input new customer info
        public async Task<RegisterAccount> RegisterAccountAsync(Guid userId, string? firstName, string? lastName, string? deliveryAddress, int phone, string? email, string? isAdmin)
        {
            RegisterAccount customerInfo = await this._repo.RegisterAccountAsync(userId, firstName, lastName, deliveryAddress, phone, email, isAdmin);
            return customerInfo;
            
        }
       

    }
}
