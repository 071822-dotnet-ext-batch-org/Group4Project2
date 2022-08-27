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


    } //EC
} //EN