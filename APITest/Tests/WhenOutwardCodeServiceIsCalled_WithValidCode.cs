using System;
using System.Collections.Generic;
using NUnit.Framework;
using APIClient;
using APIClient.PostcodeIOService;

namespace APITest.Tests
{
    public class WhenOutwardCodeServiceIsCalled_WithValidCode
    {
        LookUpOutwardCodeService _luocs = new LookUpOutwardCodeService();

        public WhenOutwardCodeServiceIsCalled_WithValidCode()
        {
            _luocs.MakeRequest("GU2");
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_luocs.ResponseContent["status"].ToString(), Is.EqualTo("200"));
        }

        [Test]
        public void CheckAdminDistrictOnlyHasGuildford()
        {
            string response = _luocs.ResponseContent["result"]["admin_district"][0].ToString();
            //int responseLength = _luocs.ResponseContent["result"]["admin_district"];
            Assert.That(response, Is.EqualTo("Guildford"));
            
        }
    }
}
