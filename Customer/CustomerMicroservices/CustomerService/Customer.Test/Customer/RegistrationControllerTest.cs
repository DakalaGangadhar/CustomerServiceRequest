using AutoFixture;
using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using Customer.Controllers;
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
    public class RegistrationControllerTest
    {
        private Mock<IRegistrationService> mockregistrationService;
        private Fixture fixture;
        RegistrationController registrationController;
        RegistrationController _registrationController;
        Mock<customerserviceDBContext> mockcustomerserviceDBContext;
        private Mock<IConfiguration> _mockconfig;
        private  Mock<IMapper> mockmapper;
        public RegistrationControllerTest()
        {
            fixture = new Fixture();
            mockregistrationService = new Mock<IRegistrationService>();
            mockcustomerserviceDBContext = new Mock<customerserviceDBContext>();
            _mockconfig = new Mock<IConfiguration>();
            mockmapper = new Mock<IMapper>();
            IRegistrationService registrationService = new RegistrationService(mockcustomerserviceDBContext.Object, _mockconfig.Object, mockmapper.Object);
            _registrationController = new RegistrationController(registrationService);
            registrationController = new RegistrationController(mockregistrationService.Object);
        }
        [TestMethod]
        public async Task Registration_Test()
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

            dynamic result = await _registrationController.Registration(data);
            Assert.AreEqual(200,result.StatusCode);

        }
        [TestMethod]
        public async Task Registration_Exception()
        {
            RegistrationDataModel data = null;
            mockregistrationService.Setup(x => x.CustomerRegistration(It.IsAny<RegistrationDataModel>(), It.IsAny<bool>())).Throws(new Exception());
            dynamic result = await registrationController.Registration(data);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task Login_Test()
        {
            var getCountry = fixture.CreateMany<RegistrationDto>();
            string str = "test data";
            CustomerLogin data = new CustomerLogin()
            {
                email = "test@gmail.com",
                password = "6534"
            };
            mockregistrationService.Setup(x => x.CustomerLogin(It.IsAny<CustomerLogin>(), It.IsAny<bool>())).Returns(Task.FromResult(str));

            dynamic result = await _registrationController.Login(data);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task Login_ThrowException()
        {
            CustomerLogin data = null;
            mockregistrationService.Setup(x => x.CustomerLogin(It.IsAny<CustomerLogin>(), It.IsAny<bool>())).Throws(new Exception());
            dynamic result = await registrationController.Login(data);
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public async Task GetCountry_Test()
        {
            var getCountry = fixture.CreateMany<CountryDto>();
           
            List<CountryDto> countryList = new List<CountryDto>()
            {
                new CountryDto(){ cId = 1, countryname="India"},
                new CountryDto(){ cId = 1, countryname="usa"},
                new CountryDto(){ cId = 1, countryname="uk"}
            };


            mockregistrationService.Setup(x => x.GetCountryList()).Returns(Task.FromResult(countryList));
           
            dynamic result = await _registrationController.GetCountry();
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetCountry_DataTest()
        {
            var getCountry = fixture.CreateMany<CountryDto>();

            List<CountryDto> countryList = new List<CountryDto>()
            {
                new CountryDto(){ cId = 1, countryname="India"},
                new CountryDto(){ cId = 1, countryname="usa"},
                new CountryDto(){ cId = 1, countryname="uk"}
            };


            mockregistrationService.Setup(x => x.GetCountryList()).Returns(Task.FromResult(countryList));

            dynamic result = await registrationController.GetCountry();
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task GetCountry_ThrowException()
        {
            mockregistrationService.Setup(x => x.GetCountryList()).Throws(new Exception());
            dynamic result = await registrationController.GetCountry();
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public async Task GetState_Test()
        {

            List<StateDto> stateList = new List<StateDto>()
            {
                new StateDto(){ stateId = 1, statename="ap",cId=1},
                new StateDto(){ stateId = 2, statename="karnataka",cId=2},
                new StateDto(){ stateId = 3, statename="tamilnadu",cId=3}
            };

            mockregistrationService.Setup(x => x.GetStateList(It.IsAny<int>())).Returns(Task.FromResult(stateList));

            dynamic result = await _registrationController.GetStates(1);
            Assert.AreEqual(400,result.StatusCode);

        }
        [TestMethod]
        public async Task GetState_DataTest()
        {

            List<StateDto> stateList = new List<StateDto>()
            {
                new StateDto(){ stateId = 1, statename="ap",cId=1},
                new StateDto(){ stateId = 2, statename="karnataka",cId=2},
                new StateDto(){ stateId = 3, statename="tamilnadu",cId=3}
            };

            mockregistrationService.Setup(x => x.GetStateList(It.IsAny<int>())).Returns(Task.FromResult(stateList));

            dynamic result = await registrationController.GetStates(1);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task GetState_Exception()
        {
            mockregistrationService.Setup(x => x.GetStateList(It.IsAny<int>())).Throws(new Exception());
            dynamic result = await registrationController.GetStates(2);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetDistricts_DataTest()
        {
            var data = fixture.CreateMany<DistrictDto>();

            List<DistrictDto> lists = new List<DistrictDto>()
            {
                new DistrictDto(){ districtId = 1, districtname="kadapa",stateId=1},
                new DistrictDto(){ districtId = 2, districtname="Bangalore",stateId=2},
                new DistrictDto(){ districtId = 3, districtname="chennai",stateId=3}
            };    

            mockregistrationService.Setup(x => x.GetDistrictList(It.IsAny<int>())).Returns(Task.FromResult(lists));

            var result = await registrationController.GetDistricts(1);
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public async Task GetDistricts_Test()
        {

            List<DistrictDto> lists = new List<DistrictDto>()
            {
                new DistrictDto(){ districtId = 1, districtname="kadapa",stateId=1},
                new DistrictDto(){ districtId = 2, districtname="Bangalore",stateId=2},
                new DistrictDto(){ districtId = 3, districtname="chennai",stateId=3}
            };

            mockregistrationService.Setup(x => x.GetDistrictList(It.IsAny<int>())).Returns(Task.FromResult(lists));

            dynamic result = await _registrationController.GetDistricts(1);
            Assert.AreEqual(400,result.StatusCode);

        }
        [TestMethod]
        public async Task GetDistrict_Exception()
        {
            mockregistrationService.Setup(x => x.GetDistrictList(It.IsAny<int>())).Throws(new Exception());
            dynamic result = await registrationController.GetDistricts(3);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetCustomerData_DataTest()
        {
            var data = fixture.CreateMany<RegistrationDto>();

            RegistrationDto list = new RegistrationDto()
            {
                registrationId = 1,
                email = "test@simple.com",
                password = "4321",
                customername = "test",
                address = "test address",
                pancard = "qwert5432r",
                contactnumber = "09876567",
                dob = DateTime.UtcNow,
                cId = 1,
                stateId = 2,
                districtId = 3,
                registrationDate = DateTime.UtcNow
            };
            PendingDataModel model = new PendingDataModel()
            {
                Email = "test@test.com",
                Status = 2
            };

            mockregistrationService.Setup(x => x.GetCustomerData(It.IsAny<PendingDataModel>())).Returns(Task.FromResult(list));

            dynamic result = await registrationController.GetCustomerData(model);
            Assert.AreEqual(200,result.StatusCode);

        }
        [TestMethod]
        public async Task GetCustomerData_Test()
        {

            RegistrationDto list = new RegistrationDto()
            {
                registrationId = 1,
                email = "test@simple.com",
                password = "4321",
                customername = "test",
                address = "test address",
                pancard = "qwert5432r",
                contactnumber = "09876567",
                dob = DateTime.UtcNow,
                cId = 1,
                stateId = 2,
                districtId = 3,
                registrationDate = DateTime.UtcNow
            };
            PendingDataModel model = new PendingDataModel()
            {
                Email = "test@test.com",
                Status = 2
            };

            mockregistrationService.Setup(x => x.GetCustomerData(It.IsAny<PendingDataModel>())).Returns(Task.FromResult(list));

            dynamic result = await _registrationController.GetCustomerData(model);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetCustomerData_Exception()
        {
            var data = fixture.CreateMany<RegistrationDto>();

            RegistrationDto list = null;
            PendingDataModel model = null;

            mockregistrationService.Setup(x => x.GetCustomerData(It.IsAny<PendingDataModel>())).Throws(new Exception());

            dynamic result = await registrationController.GetCustomerData(model);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task UpdateCustomerProfile_Test()
        {
            var getCountry = fixture.CreateMany<RegistrationDto>();
            RegistrationDto list = new RegistrationDto()
            {
                registrationId = 1,
                email = "test@simple.com",
                password = "4321",
                customername = "test",
                address = "test address",
                pancard = "qwert5432r",
                contactnumber = "09876567",
                dob = DateTime.UtcNow,
                cId = 1,
                stateId = 2,
                districtId = 3,
                registrationDate = DateTime.UtcNow
            };
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

            mockregistrationService.Setup(x => x.UpdateCustomerProfile(It.IsAny<RegistrationDataModel>())).Returns(Task.FromResult(list));

            dynamic result = await _registrationController.UpdateCustomerProfile(data);
            Assert.AreEqual(400, result.StatusCode);

        }       
        [TestMethod]
        public async Task UpdateCustomerProfile_DataTest()
        {
            var getCountry = fixture.CreateMany<RegistrationDto>();
            RegistrationDto list = new RegistrationDto()
            {
                registrationId = 1,
                email = "test@simple.com",
                password = "4321",
                customername = "test",
                address = "test address",
                pancard = "qwert5432r",
                contactnumber = "09876567",
                dob = DateTime.UtcNow,
                cId = 1,
                stateId = 2,
                districtId = 3,
                registrationDate = DateTime.UtcNow
            };
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

            mockregistrationService.Setup(x => x.UpdateCustomerProfile(It.IsAny<RegistrationDataModel>())).Returns(Task.FromResult(list));

            dynamic result = await registrationController.UpdateCustomerProfile(data);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task UpdateCustomerProfile_Exception()
        {          
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

            mockregistrationService.Setup(x => x.UpdateCustomerProfile(It.IsAny<RegistrationDataModel>())).Throws(new Exception());

            dynamic result = await registrationController.UpdateCustomerProfile(data);
            Assert.AreEqual(400, result.StatusCode);

        }

    }
}
