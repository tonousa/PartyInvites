﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PartyInvites.Models.Repository;
using PartyInvites.Models;
using PartyInvites.Presenters;
using PartyInvites.Presenters.Results;
using System.Collections.Generic;

namespace PartyInvites.Tests
{
    [TestClass]
    public class RSVPPresenterTests
    {
        class MockRepository: IRepository
        {
            private List<GuestResponse> mockData = new List<GuestResponse>
            {
                new GuestResponse {Name="Person1", WillAttend=true },
                new GuestResponse {Name="Person2", WillAttend=false }
            };

            public void AddResponse(GuestResponse response)
            {
                mockData.Add(response);
            }

            public IEnumerable<GuestResponse> GetAllResponses()
            {
                return mockData;
            }
        }

        [TestMethod]
        public void Adds_Object_To_Repository()
        {
            // Arrange
            IRepository repo = new MockRepository();
            IPresenter<GuestResponse> target = new RSVPPresenter { repository = repo };
            GuestResponse dataObject =
                new GuestResponse { Name = "TEST", WillAttend = true };

            // Act
            IResult result = target.GetResult(dataObject);

            // Assert
            Assert.AreEqual(repo.GetAllResponses().Count(), 3);
            Assert.AreEqual(repo.GetAllResponses().Last().Name, "TEST");
            Assert.AreEqual(repo.GetAllResponses().Last().WillAttend, true);
        }
    }
}
