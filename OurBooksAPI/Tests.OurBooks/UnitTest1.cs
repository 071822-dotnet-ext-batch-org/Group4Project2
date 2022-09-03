using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnit;
using ModelsLayer;
using BusinessLayer;

namespace Tests.OurBooks
{
    public class UnitTest1
    {
        [Fact]
        public void LoginSuccessfully()
        {
            //Arrange
            String email = "JSmith@myEmail.com";
            String password = "12345";
            //Create new instance of the business layer
            Mock_RepoLayer m = new Mock_RepoLayer();
            BusinessLayer bl = new BusinessLayer(m);

            //Act
            //Credentials c = new Credentials
            //{
            //    Email = email,
            //    Password = password
            //};

            Credentials c = await bl.LoginAsync(email);



            //Assert
            Assert.Equal(c.Email, Login);
        }
    }
}