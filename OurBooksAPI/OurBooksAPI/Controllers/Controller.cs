using System.Net;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http;
using BusinessLayer;
using ModelsLayer;
using Microsoft.AspNetCore.Routing.Internal;
using System.ComponentModel;

namespace OurBooksAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {

        private Business _business = new Business(); // Creating a new business connection object


        /// <summary>
        /// #3 Displays all books and their information
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        [HttpGet("DisplayAll")] // API Get request
        public async Task<ActionResult<List<DisplayDTO>>> DisplayAllAsync(string bookName)
        {
            List<DisplayDTO> result = await this._business.DisplayAllAsync(bookName); //Creates a list from the business layer to send to API

            return Ok(result); // Returns status code 200
        }

        /// <summary>
        /// #3 Display filtered books by name
        /// </summary>
        /// <param name="bookName"></param>
        /// <returns></returns>
        [HttpGet("DisplayName")] // API Get request
        public async Task<ActionResult<List<DisplayDTO>>> DisplayNameAsync(string bookName)
        {
            List<DisplayDTO> result = await this._business.DisplayNameAsync(bookName); //Creates a list from the business layer to send to API

            return Ok(result); // Returns status code 200
        }

        /// <summary>
        /// #3 Display filtered books by genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        [HttpGet("DisplayGenre")] // API Get request
        public async Task<ActionResult<List<DisplayDTO>>> DisplayGenreAsync(string genre)
        {
            List<DisplayDTO> result = await this._business.DisplayGenreAsync(genre); //Creates a list from the business layer to send to API

            return Ok(result); // Returns status code 200
        }

        /// <summary>
        /// #3 Display filtered books by author
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        [HttpGet("DisplayAuthor")] // API Get request
        public async Task<ActionResult<List<DisplayDTO>>> DisplayAuthorAsync(string Author)
        {
            List<DisplayDTO> result = await this._business.DisplayAuthorAsync(Author); //Creates a list from the business layer to send to API

            return Ok(result); // Returns status code 200
        }

        /// <summary>
        /// #3 Display filtered books by cost < 30 and cost > 30 
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        [HttpGet("DisplayCost")] // API Get request
        public async Task<ActionResult<List<DisplayDTO>>> DisplayCostAsync(decimal cost)
        {
            List<DisplayDTO> result = await this._business.DisplayCostAsync(cost); //Creates a list from the business layer to send to API

            return Ok(result); // Returns status code 200
        }

        /// <summary>
        /// #5 Checkout payment
        /// </summary>
        /// <param name="checkout"></param>
        /// <returns></returns>
        [HttpPost("Order")] // Http post request to API
        public async Task<ActionResult<List<CheckoutDTO>>> CheckoutAsync(CheckoutDTO checkout)
        {
            List<CheckoutDTO> check = await this._business.CheckoutAsync(checkout.CartId, checkout.BookName, checkout.Money, checkout.IsUser);
            return Ok(check);
        }



        /*private Business _business = new Business();
       //private readonly Business _business;*/

        [HttpPost("Login")]//Check the credentials
        public async Task <ActionResult> LoginAsync(Credentials Login)//Memeber data transfer object to carry login credentials data between processes.
        {
         if (ModelState.IsValid)//Model Validation: was it possible to bind incoming values to MemberDTO?
            {
                return Accepted(await this._business.LoginAsync(Login.Email, Login.Password)); //Should return status code 200
            }
        else
            {
            return NotFound("No login credentials found");
            }
        }//EoLoginAsync

    }//EoC
}//EoN
