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


namespace OurBooksAPI.Controllers
{
    [Route("[Controller]")]
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
        /// #3 Filter and display products API request
        /// </summary>
        /// <param name="Isbn"></param>
        /// <param name="BookName"></param>
        /// <param name="NumberPages"></param>
        /// <param name="Genre"></param>
        /// <param name="Author"></param>
        /// <param name="InStock"></param>
        /// <param name="Cost"></param>
        /// <returns></returns>
        [HttpGet("DisplayProduct")] // API all Get request
        public async Task<ActionResult<List<DisplayDTO>>> DisplayProductAsync(string? Isbn, string? BookName, int? NumberPages, string? Genre, string? Author, int InStock, decimal? Cost)
        {
            
            // send list to the API
            List<DisplayDTO> result = await this._business.DisplayProductAsync(Isbn, BookName, NumberPages, Genre, Author, InStock, Cost);

            return Ok(result); // Return status code 200
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
