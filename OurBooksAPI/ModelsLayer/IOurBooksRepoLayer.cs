using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public interface IOurBooksRepoLayer
    {
        Task<bool> EmailPassWordExists(string email, string password);
        Task<NewCustomer> InsertNewCustomer(Guid guid, CustomerRegisterDto nc);
        Task<NewCustomer> CustomerById(Guid guid);
        Task<List<DisplayDTO>> DisplayAllAsync();
        Task<List<DisplayDTO>> DisplayGenreAsync(string genre);
        Task<List<DisplayDTO>> DisplayAuthorAsync(string author);
        Task<List<DisplayDTO>> DisplayHighCostAsync(decimal cost);
        Task<List<DisplayDTO>> DisplayLowCostAsync(decimal cost);
        Task <Credentials> GetCredentialsAsync(string email, string password);
    }
}