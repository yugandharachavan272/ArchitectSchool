
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplePatientWebAPI.Controllers;
using SimplePatientWebAPI.Data.Context;
using SimplePatientWebAPI.Domain;
using SimplePatientWebAPI.Repositories;
using SimplePatientWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Xunit;

namespace SimplePatientWebAPI.Test
{
    
    public class PatientControllerTest
    {
        readonly PatientController patientController;

        public PatientControllerTest()
        {
            patientController = new PatientController();
        }

        [Fact]
        public void Get_WhenCalled_ReturnsPatients()
        {
            // Act
            List<PatientViewModel> patients = patientController.Get();

            // Assert
            Assert.IsType<List<PatientViewModel>>(patients);
        }

        

        [Fact]
        public void GetById_UnknownId_ThrowsArgumentException()
        {
            // Arrange
            var patientId = 0;

            //act
            void act() => patientController.Get(patientId);
            //assert
            var exception = Assert.Throws<NullReferenceException>(act);
            //The thrown exception can be used for even more detailed assertions.
            Assert.Equal("Object reference not set to an instance of an object.", exception.Message);
        }

        [Fact]
        public void GetById_ExistingIdePassed_ReturnsPatientViewModel()
        {
            // Arrange
            var patientId = 7;

            // Act
            PatientViewModel patient = patientController.Get(patientId);

            // Assert
            Assert.IsType<PatientViewModel>(patient);
        }

        [Fact]
        public void Post_InvalidObjectPassed_ReturnsBadRequest()
        {
            Patient patient = null;

            // Act
            var response = patientController.Post(patient);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }


        [Fact]
        public void Post_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Patient patient = new Patient()
            {
                Name = "Test Patient",
                phone = "123",
                Address = "test",
                hospitalID = 1,
                DateOfBirth = DateTime.Now,
            };

            // Act
            IHttpActionResult actionResult = patientController.Post(patient);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);

            // Assert
            Assert.NotEmpty(conNegResult.Content);
        }


        [Fact]
        public void Post_ValidObjectPassed_PatientCreatedSuccessfully()
        {
            // Arrange
            Patient patient = new Patient()
            {
                Name = "Test Patient",
                phone = "123",
                Address = "test",
                hospitalID = 1,
                DateOfBirth = DateTime.Now,
            };

            // Act
            IHttpActionResult actionResult = patientController.Post(patient);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);

            // Assert
            Assert.Equal("data:True", conNegResult.Content);
        }

        [Fact]
        public void Post_ValidObjectPassed_PatientCreationFailed()
        {
            // Arrange
            Patient patient = new Patient()
            {
                phone = "123",
                Address = "test",
                hospitalID = 1,
                DateOfBirth = DateTime.Now,
            };

            // Act
            IHttpActionResult actionResult = patientController.Post(patient);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);

            // Assert
            Assert.Equal("data:False", conNegResult.Content);
        }


        [Fact]
        public void Put_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Act
            var response = patientController.Put(0, null);

            // Assert
            Assert.IsType<BadRequestErrorMessageResult>(response);
        }


        [Fact]
        public void Put_ValidObjectPassed_ReturnsUpdatedResponse()
        {
            // Arrange
            Patient patient = new Patient()
            {
                ID=7,
                hospitalID = 1,
                Name = "Test Patient yug",
                phone = "123",
                Address = "test",
                DateOfBirth = DateTime.Now
            };

            // Act
            IHttpActionResult actionResult = patientController.Put(patient.ID, patient);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
            // Assert
            Assert.NotEmpty(conNegResult.Content);
        }

        [Fact]
        public void Put_ValidObjectPassed_ReturnsUpdatedResponseSuccess()
        {
            // Arrange
            Patient patient = new Patient()
            {
                ID = 8,
                hospitalID = 1,
                Name = "Test Patient siya",
                phone = "123",
                Address = "test",
                DateOfBirth = DateTime.Now
            };

            // Act
            IHttpActionResult actionResult = patientController.Put(patient.ID, patient);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
            // Assert
            Assert.Equal("data:True", conNegResult.Content);
        }

        [Fact]
        public void Put_ValidObjectPassed_ReturnsUpdatedResponseFail()
        {
            // Arrange
            Patient patient = new Patient()
            {
                phone = "123",
                Address = "test"
            };

            // Act
            IHttpActionResult actionResult = patientController.Put(patient.ID, patient);
            OkNegotiatedContentResult<string> conNegResult = Assert.IsType<OkNegotiatedContentResult<string>>(actionResult);
            // Assert
            Assert.Equal("data:False", conNegResult.Content);
        }


    }

}
