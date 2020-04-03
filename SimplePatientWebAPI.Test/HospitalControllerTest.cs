using Microsoft.AspNetCore.Mvc;
using SimplePatientWebAPI.Controllers;
using SimplePatientWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace SimplePatientWebAPI.Test
{
    public class HospitalControllerTest
    {
        readonly HospitalController hospitalController;

        public HospitalControllerTest()
        {
            hospitalController = new HospitalController();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsPatients()
        {
            // Act
            IEnumerable<Hospital>  hospitals = hospitalController.Get();

            // Assert
            Assert.IsAssignableFrom<IEnumerable<Hospital>>(hospitals);
        }

        [Fact]
        public void GetById_UnknownId_ReturnsNull()
        {
            // Arrange
            var id = -1;

            //act
            var result = hospitalController.Get(id);

            //assert
            Assert.Null(result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsHospital()
        {
            // Arrange
            var id = 1;

            // Act
            Hospital hospital = hospitalController.Get(id);

            // Assert
            Assert.IsType<Hospital>(hospital);
        }

        [Fact]
        public void Post_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            Hospital hospital = null;

            // Act
            var response = hospitalController.Post(hospital);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }


        [Fact]
        public void Post_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Hospital hospital = new Hospital()
            {
                HospitalName = "Om"
            };

            // Act
            IHttpActionResult actionResult = hospitalController.Post(hospital);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);

            // Assert
            Assert.NotEmpty(conNegResult.Content);
        }

        [Fact]
        public void Post_ValidObjectPassed_HospitalCreationFail()
        {
            // Arrange
            Hospital hospital = new Hospital();

            // Act
            IHttpActionResult actionResult = hospitalController.Post(hospital);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);

            // Assert
            Assert.Equal("data:False", conNegResult.Content);
        }

        [Fact]
        public void Post_ValidObjectPassed_HospitalCreatedSuccessfully()
        {
            // Arrange
            Hospital hospital = new Hospital()
            {
                HospitalName = "Om"
            };

            // Act
            IHttpActionResult actionResult = hospitalController.Post(hospital);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);

            // Assert
            Assert.Equal("data:True", conNegResult.Content);
        }

        [Fact]
        public void Put_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Act
            var response = hospitalController.Put(0, null);

            //Assert
            Assert.IsType<BadRequestErrorMessageResult>(response);
            //Assert.Equal("request can not be null", response.ToString());
        }


        [Fact]
        public void Put_ValidObjectPassed_ReturnsUpdatedResponse()
        {
            int hospitalId = 1;
            // Arrange
            Hospital hospital = new Hospital()
            {
                HospitalName = "Om Sai",
            };

            // Act
            IHttpActionResult actionResult = hospitalController.Put(hospitalId, hospital); ;
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
            // Assert
            Assert.NotEmpty(conNegResult.Content);
        }

        [Fact]
        public void Put_ValidObjectPassed_HospistalUpdateSuccess()
        {
            int hospitalId = 5;
            // Arrange
            Hospital hospital = new Hospital()
            {
                HospitalName = "Om"
            };

            // Act
            IHttpActionResult actionResult = hospitalController.Put(hospitalId, hospital); ;
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
            // Assert
            Assert.Equal("data:True", conNegResult.Content);
        }

        [Fact]
        public void Put_ValidObjectPassed_HospitalUpdateFail()
        {
            int hospitalId = 0;
            // Arrange
            Hospital hospital = new Hospital();

            // Act
            IHttpActionResult actionResult = hospitalController.Put(hospitalId, hospital); ;
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
            // Assert
            Assert.Equal("data:False", conNegResult.Content);
        }
    }


}
