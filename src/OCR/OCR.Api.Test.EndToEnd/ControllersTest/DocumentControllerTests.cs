﻿using FluentAssertions;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace OCR.Api.Test.EndToEnd.ControllersTest
{
    public class DocumentControllerTests
    {

        private ClientTests _clientTests;

        [SetUp]
        public void Setup()
        {
            _clientTests = new ClientTests();
        }


        [Test]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            // Act
            var response = await _clientTests.Client.GetAsync("");

            // Assert

            //response.Content.StatusCode.Should()..BeEquivalentTo(HttpStatusCode.NotFound);
        }
    }
}
