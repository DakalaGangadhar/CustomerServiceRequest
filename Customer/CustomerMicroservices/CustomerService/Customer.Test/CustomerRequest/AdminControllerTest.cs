using AutoFixture;
using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using CustomerRequest.Controllers;
using CustomerRequest.Interface;
using CustomerRequest.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Test.CustomerRequest
{
    [TestClass]
    public class AdminControllerTest
    {
        private Mock<IAdminService> mockadminService;
        private Fixture fixture;
        AdminController adminController;
        AdminController _adminController;
        Mock<customerserviceDBContext> mockcustomerserviceDBContext;
        private  Mock<IMapper> mockmapper;
        private Mock<IConfiguration> _mockconfig;
        public AdminControllerTest()
        {
            mockadminService = new Mock<IAdminService>();
            fixture = new Fixture();
            mockcustomerserviceDBContext = new Mock<customerserviceDBContext>();
            mockmapper = new Mock<IMapper>();
            _mockconfig = new Mock<IConfiguration>();
            IAdminService adminService = new AdminService(mockcustomerserviceDBContext.Object, mockmapper.Object, _mockconfig.Object);
            _adminController = new AdminController(adminService);
            adminController = new AdminController(mockadminService.Object);
           
        }
        [TestMethod]
        public async Task AdminLogin_Test()
        {
            var getCountry = fixture.CreateMany<RegistrationDto>();
            string str = "test data";
            CustomerLogin data = new CustomerLogin()
            {
                email = "test@gmail.com",
                password = "6534"
            };

            mockadminService.Setup(x => x.AdminLogin(It.IsAny<CustomerLogin>())).Returns(Task.FromResult(str));

            dynamic result = await _adminController.AdminLogin(data);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task AdminLogin_DataTest()
        {
            string str = null;
            CustomerLogin data = new CustomerLogin()
            {
                email = "test@gmail.com",
                password = "6534"
            };

            mockadminService.Setup(x => x.AdminLogin(It.IsAny<CustomerLogin>())).Returns(Task.FromResult(str));

            dynamic result = await adminController.AdminLogin(data);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task AdminLogin_Exception()
        {
            CustomerLogin data = new CustomerLogin()
            {
                email = "test@gmail.com",
                password = "6534"
            };

            mockadminService.Setup(x => x.AdminLogin(It.IsAny<CustomerLogin>())).Throws(new Exception());

            dynamic result = await adminController.AdminLogin(data);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetAdminData_Test()
        {
            CustomerLogin data = new CustomerLogin()
            {
                email = "test@gmail.com",
                password = "6534"
            };
            List<ServiceRequestAllDataModel> lists = new List<ServiceRequestAllDataModel>() {
                new ServiceRequestAllDataModel{
                    srId=2,
                    cusromername="test",
                    country="uk",
                    state="london",
                    district="lon",
                    address="uk",
                    phonenumber="987654567",
                    pancard="poiuy7890u",
                    description="testing data",
                    status="pending",
                    category="issue",
                    assignto="manager"


                },
                new ServiceRequestAllDataModel{
                 srId=2,
                    cusromername="test name",
                    country="usa",
                    state="usa",
                    district="col",
                    address="usa",
                    phonenumber="123456789",
                    pancard="98ujhiu",
                    description="testing des data",
                    status="reject",
                    category="issue battery",
                    assignto="manager test"
                },
            };

            mockadminService.Setup(x => x.GetAdminData(It.IsAny<CustomerLogin>())).Returns(Task.FromResult(lists));

            dynamic result = await _adminController.GetAdminData(data);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task GetAdminData_DataTest()
        {
            CustomerLogin data = new CustomerLogin()
            {
                email = "test@gmail.com",
                password = "6534"
            };
            List<ServiceRequestAllDataModel> lists = new List<ServiceRequestAllDataModel>() {
                new ServiceRequestAllDataModel{
                    srId=2,
                    cusromername="test",
                    country="uk",
                    state="london",
                    district="lon",
                    address="uk",
                    phonenumber="987654567",
                    pancard="poiuy7890u",
                    description="testing data",
                    status="pending",
                    category="issue",
                    assignto="manager"


                },
                new ServiceRequestAllDataModel{
                 srId=2,
                    cusromername="test name",
                    country="usa",
                    state="usa",
                    district="col",
                    address="usa",
                    phonenumber="123456789",
                    pancard="98ujhiu",
                    description="testing des data",
                    status="reject",
                    category="issue battery",
                    assignto="manager test"
                },
            };

            mockadminService.Setup(x => x.GetAdminData(It.IsAny<CustomerLogin>())).Returns(Task.FromResult(lists));

            dynamic result = await adminController.GetAdminData(data);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task GetAdminData_Exception()
        {
            CustomerLogin data = new CustomerLogin()
            {
                email = "test@gmail.com",
                password = "6534"
            };
            var list = new object();
            mockadminService.Setup(x => x.GetAdminData(It.IsAny<CustomerLogin>())).Throws(new Exception());

            dynamic result = await adminController.GetAdminData(data);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task Approve_Test()
        {
            ServiceRequestDto data = new ServiceRequestDto()
            {
                srId = 1,
                description = "test description",
                registrationId = 2,
                srcId = 3,
                assignId = 5,
                statusId = 6,
                createrequestdate = DateTime.UtcNow
            };
            var list = new object();
            mockadminService.Setup(x => x.ApproveServiceRequest(It.IsAny<int>())).Returns(Task.FromResult(data));

            dynamic result = await adminController.Approve(1);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task Approve_DataTest()
        {
            ServiceRequestDto data = new ServiceRequestDto()
            {
                srId = 1,
                description = "test description",
                registrationId = 2,
                srcId = 3,
                assignId = 5,
                statusId = 6,
                createrequestdate = DateTime.UtcNow
            };
            var list = new object();
            mockadminService.Setup(x => x.ApproveServiceRequest(It.IsAny<int>())).Returns(Task.FromResult(data));

            dynamic result = await _adminController.Approve(1);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task Approve_Exception()
        {
            mockadminService.Setup(x => x.ApproveServiceRequest(It.IsAny<int>())).Throws(new Exception());

            dynamic result = await adminController.Approve(4);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task Reject_Test()
        {
            ServiceRequestDto data = new ServiceRequestDto()
            {
                srId = 1,
                description = "test description",
                registrationId = 2,
                srcId = 3,
                assignId = 5,
                statusId = 6,
                createrequestdate = DateTime.UtcNow
            };
            mockadminService.Setup(x => x.RejectServiceRequest(It.IsAny<int>())).Returns(Task.FromResult(data));

            dynamic result = await adminController.Reject(5);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task Reject_Exception()
        {
            mockadminService.Setup(x => x.RejectServiceRequest(It.IsAny<int>())).Throws(new Exception());

            dynamic result = await adminController.Reject(5);
            Assert.AreEqual(400, result.StatusCode);

        }
    }
}
