using AutoFixture;
using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using Customer.Interface;
using Customer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Test.Customer
{
    [TestClass]
    public class RegistrationServiceTest
    {
        private Mock<IRegistrationService> mockregistrationService;
        private Fixture fixture;
        RegistrationService registrationService;
        RegistrationService _registrationController;
        Mock<customerserviceDBContext> mockcustomerserviceDBContext;
        private Mock<IConfiguration> _mockconfig;
        private Mock<IMapper> mockmapper;
        public RegistrationServiceTest()
        {
            fixture = new Fixture();
            mockregistrationService = new Mock<IRegistrationService>();
            mockcustomerserviceDBContext = new Mock<customerserviceDBContext>();
            _mockconfig = new Mock<IConfiguration>();
            mockmapper = new Mock<IMapper>();
            registrationService = new RegistrationService(mockcustomerserviceDBContext.Object, _mockconfig.Object, mockmapper.Object);
           // _registrationController = new RegistrationService(registrationService);
           // registrationController = new RegistrationService(mockregistrationService.Object);
        }
        [TestMethod]
        public async Task Registration_Service_Test()
        {
            var getCountry = fixture.CreateMany<RegistrationDto>();
            string str = "test data";
            DateTime date = DateTime.UtcNow;
            RegistrationDataModel data = new RegistrationDataModel()
            {
                registrationId = 3,
                CustomerAddress = "Bangalore, Manyata",
                CustomerCountry = "1",
                CustomerPhoneNumber = "987654567",
                CustomerPassword = "1234",
                CustomerPanCard = "GGGGG1234G",
                CustomerName = "test",
                CustomerEmail = "test@gmail.com",
                CustomerDistrict = "6",
                CustomerDOB = Convert.ToString(date),
                CustomerState = "2"
            };

            mockregistrationService.Setup(x => x.CustomerRegistration(It.IsAny<RegistrationDataModel>(), It.IsAny<bool>())).Returns(Task.FromResult(str));

            var result = await registrationService.CustomerRegistration(data,false);
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public async Task Registration_Service_Exception()
        {
            RegistrationDataModel data = null;
            mockregistrationService.Setup(x => x.CustomerRegistration(It.IsAny<RegistrationDataModel>(), It.IsAny<bool>())).Throws(new Exception());
            dynamic result = await registrationService.CustomerRegistration(data, true);
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public async Task Login_Service_Test()
        {
            string str = "test data";
            CustomerLogin data = new CustomerLogin()
            {
                email = "test@gmail.com",
                password = "6534"
            };
            mockregistrationService.Setup(x => x.CustomerLogin(It.IsAny<CustomerLogin>(), It.IsAny<bool>())).Returns(Task.FromResult(str));

            string result = await registrationService.CustomerLogin(data,false);
            Assert.AreEqual("", result);

        }
        [TestMethod]
        public async Task Login_Service_Exception()
        {
            CustomerLogin data=null;
            mockregistrationService.Setup(x => x.CustomerLogin(It.IsAny<CustomerLogin>(), It.IsAny<bool>())).Throws(new Exception());

            string result = await registrationService.CustomerLogin(data, false);
            Assert.AreEqual("", result);

        }
        [TestMethod]
        public async Task GetCountry_Service_Test()
        {
            List<CountryDto> countryList = new List<CountryDto>()
            {
                new CountryDto(){ cId = 1, countryname="India"},
                new CountryDto(){ cId = 1, countryname="usa"},
                new CountryDto(){ cId = 1, countryname="uk"}
            };


            mockregistrationService.Setup(x => x.GetCountryList()).Returns(Task.FromResult(countryList));

            dynamic result = await registrationService.GetCountryList();
            Assert.IsNull(result);

        }
        [TestMethod]
        public async Task GetState_Service_Test()
        {

            List<StateDto> stateList = new List<StateDto>()
            {
                new StateDto(){ stateId = 1, statename="ap",cId=1},
                new StateDto(){ stateId = 2, statename="karnataka",cId=2},
                new StateDto(){ stateId = 3, statename="tamilnadu",cId=3}
            };

            mockregistrationService.Setup(x => x.GetStateList(It.IsAny<int>())).Returns(Task.FromResult(stateList));

            List<StateDto> result = await registrationService.GetStateList(1);
            Assert.IsNull(result);

        }
        [TestMethod]
        public async Task UpdateCustomerProfile_Service_Test()
        {
            RegistrationDataModel data = null;

            mockregistrationService.Setup(x => x.UpdateCustomerProfile(It.IsAny<RegistrationDataModel>())).Throws(new Exception());

            dynamic result = await registrationService.UpdateCustomerProfile(data);
            Assert.IsNull(result);

        }

    }
}
