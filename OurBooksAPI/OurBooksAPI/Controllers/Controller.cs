using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;

namespace OurBooksAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private readonly Business _business; 
        public Controller() 
        {
            this._business = new Business();
        }

        //private Business _business = new Business();

        //Register a new account with username and password 
        [HttpPost("RegisterAccount")]//add new customer accounts to the database
        public async Task<ActionResult<RegisterAccount>> RegisterAccountAsync(Guid userId, string? firstName, string? lastName, string? deliveryAddress, string? phone, string? email, string? isAdmin)
        {
            RegisterAccount customerInfo = await this._business.RegisterAccountAsync(userId, firstName, lastName, deliveryAddress, phone, email, isAdmin);
            return Ok();
        }

    }
}








        
 
