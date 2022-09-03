using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsLayer;
using RepositoryLayer;

namespace Tests.OurBooks
{
    public class Mock_RepoLayer : IOurBooksRepoLayer
    {
        /// <summary>
        /// creates a fake Credentials and returns it
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Credentials> GetCredentialsAsync(string email, string password)
        {
            // throw new NotImplementedException();
            await Task.Delay(100);
            Credentials c = new Credentials(email, password);
            return c;
        }

        public async Task<Credentials> GetCredentialsAsync(string email, string password)
        {
            await Task.Delay(100);
            throw new NotImplementedException();
        }
    }//EoC
}//EoN