using APITestProduct.Data;
using APITestProduct.Models;
using APITestProduct.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProduct.Services
{
    public class UserServicesTest
    {
        private UserServices userServices;


        public UserServicesTest()
        {
            userServices = new UserServices(new Mock<IDataContext>().Object);
        }

        [Fact]
        public void Post_SendingInvalidUser()
        {
            // Arrange  
            User obj = null;
            string expectativa = "User is invalid";

            // Act
            var exception = Assert.ThrowsAsync<Exception>(() => userServices.Add(obj));

            // Assert
            Assert.Equal(expectativa, exception.Result.Message);
        }

        [Fact]
        public void Update_SendingInvalidUser()
        {
            // Arrange  
            User obj = null;
            string expectativa = "User is invalid";

            // Act
            var exception = Assert.ThrowsAsync<Exception>(() => userServices.Update(obj));

            // Assert
            Assert.Equal(expectativa, exception.Result.Message);
        }
        [Fact]
        public void Update_SendingInvalidId()
        {
            // Arrange  
            User obj = new User() { Id = 0 };
            string expectativa = "UserID is not valid";

            // Act
            var exception = Assert.ThrowsAsync<Exception>(() => userServices.Update(obj));

            // Assert
            Assert.Equal(expectativa, exception.Result.Message);
        }

        [Fact]
        public void Get_SendingInvalidId()
        {
            // Arrange  
            int objID = 0;
            string expectativa = "UserID is not valid";

            // Act
            var exception = Assert.ThrowsAsync<Exception>(() => userServices.Get(objID));

            // Assert
            Assert.Equal(expectativa, exception.Result.Message);
        }

        [Fact]
        public void Delete_SendingInvalidId()
        {
            // Arrange  
            int objID = 0;
            string expectativa = "UserID is not valid";

            // Act
            var exception = Assert.ThrowsAsync<Exception>(() => userServices.Delete(objID));

            // Assert
            Assert.Equal(expectativa, exception.Result.Message);
        }


    }
}
