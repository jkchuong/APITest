using System;
using NUnit.Framework;
using APIClient;
using APIClient.PostcodeIOService;

namespace APITest.Tests
{
    public class WhenTheSInglePostCodeServiceIsCalled_WithValidPostcode
    {
        SinglePostCodeService _spcs = new SinglePostCodeService();

        public WhenTheSInglePostCodeServiceIsCalled_WithValidPostcode()
        {
            _spcs.MakeRequest("WS7 1LN");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_spcs.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void ObjectStatusIs200()
        {
            Assert.That(_spcs.ResponseObject.status, Is.EqualTo(200));
        }

        [Test]
        public void CheckRegionIsWestMidlands()
        {
            string response = _spcs.ResponseContent["result"]["nuts"].ToString();
            Assert.That(response, Is.EqualTo("Staffordshire CC"));
        }
    }
}
