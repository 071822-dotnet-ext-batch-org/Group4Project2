using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelsLayer;
using System.Reflection.Metadata.Ecma335;
using RepositoryLayer;

namespace OurBooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private Business _business = new Business(); // Creating a new business connection object

        /*
        private readonly Business _businessLayer; //Private field to be used in constructor for Controller().
        public Controller() //Constructor to connect to BusinessLayer.
        {
            this._businessLayer = new Business();
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
        [HttpGet("Display_Product")] //create GET request in API
        public async Task<ActionResult<List<DisplayDTO>>> DisplayProductAsync(string? ProductId, string? BookName, int? NumberPages, string? Genre, string? Author, int? InStock, decimal? Cost)
        {   // send list to the API
            List<DisplayDTO> result = await this._business.DisplayProductAsync(ProductId, BookName, NumberPages, Genre, Author, InStock, Cost);
            if (ModelState.IsValid)
            {
                return Ok(result);
            }
            else
            {
                return null;
            }
            
        }




    }//EC
} //EN
