using System.Globalization;
using System.Net.Http.Headers;
using ModelsLayer;
using RepositoryLayer;

namespace BusinessLayer
{
    public class Business
    {
        private Repository _repo = new Repository();

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