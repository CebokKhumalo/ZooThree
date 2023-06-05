﻿using System.Threading.Tasks;
using ZooThree.Models.TokenAuth;
using ZooThree.Web.Controllers;
using Shouldly;
using Xunit;

namespace ZooThree.Web.Tests.Controllers
{
    public class HomeController_Tests: ZooThreeWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}