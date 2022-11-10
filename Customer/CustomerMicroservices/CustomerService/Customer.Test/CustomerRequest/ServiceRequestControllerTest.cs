using AutoFixture;
using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using CustomerRequest.Controllers;
using CustomerRequest.Interface;
using CustomerRequest.Services;
using MassTransit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Test.CustomerRequest
{
    [TestClass]
    public class ServiceRequestControllerTest
    {
        private Mock<IServiceRequestService> mockserviceRequestService;
        private Fixture fixture;
        ServiceRequestController serviceRequestController;
        ServiceRequestController _serviceRequestController;
        Mock<customerserviceDBContext> mockcustomerserviceDBContext;
        private  Mock<IMapper> mockmapper;
        private  Mock<IBus> mockbus;
        public ServiceRequestControllerTest()
        {
            fixture = new Fixture();
            mockserviceRequestService = new Mock<IServiceRequestService>();
            mockcustomerserviceDBContext = new Mock<customerserviceDBContext>();
            mockmapper = new Mock<IMapper>();
            mockbus = new Mock<IBus>();
            IServiceRequestService serviceRequest = new ServiceRequestService(mockcustomerserviceDBContext.Object, mockmapper.Object, mockbus.Object);
            _serviceRequestController = new ServiceRequestController(serviceRequest);
            serviceRequestController = new ServiceRequestController(mockserviceRequestService.Object);
        }
        [TestMethod]
        public async Task GetServiceRequestCategoryList_Test()
        {
            List<ServiceRequestCategorieDto> data = new List<ServiceRequestCategorieDto>()
            {
                new ServiceRequestCategorieDto{ srcId=1,categoryname="service"},
                 new ServiceRequestCategorieDto{ srcId=2,categoryname="request"},
            };
            mockserviceRequestService.Setup(x => x.GetServiceRequestCategories()).Returns(Task.FromResult(data));

            dynamic result = await _serviceRequestController.GetServiceRequestCategoryList();
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetServiceRequestCategoryList_Isnull()
        {
            List<ServiceRequestCategorieDto> data = null;
            mockserviceRequestService.Setup(x => x.GetServiceRequestCategories()).Returns(Task.FromResult(data));

            dynamic result = await _serviceRequestController.GetServiceRequestCategoryList();
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetServiceRequestCategoryList_Exception()
        {
            mockserviceRequestService.Setup(x => x.GetServiceRequestCategories()).Throws(new Exception());

            dynamic result = await serviceRequestController.GetServiceRequestCategoryList();
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task CreateServiceRequest_Test()
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
            ServiceRequestDataModel serviceRequest = new ServiceRequestDataModel()
            {
                Categoty = "test category",
                Description = "test description",
                Email = "tetst@gmail.com",
            };
            mockserviceRequestService.Setup(x => x.CreateServiceRequest(It.IsAny<ServiceRequestDataModel>())).Returns(Task.FromResult(data));

            dynamic result = await serviceRequestController.CreateServiceRequest(serviceRequest);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task CreateServiceRequest_Exception()
        {
            ServiceRequestDataModel serviceRequest = new ServiceRequestDataModel()
            {
                Categoty = "laptop issue",
                Description = "issue description",
                Email = "simple@gmail.com",
            };
            mockserviceRequestService.Setup(x => x.CreateServiceRequest(It.IsAny<ServiceRequestDataModel>())).Throws(new Exception());

            dynamic result = await serviceRequestController.CreateServiceRequest(serviceRequest);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetpendingservicerequestData_Test()
        {
            PendingDataModel pendingData = new PendingDataModel()
            {
                Email = "data@simple.com",
                Status = 2
            };
            List<ServiceRequestAllDataModel> lists = new List<ServiceRequestAllDataModel>() {
                new ServiceRequestAllDataModel{
                    srId=2,
                    cusromername="ganesha",
                    country="india",
                    state="ap",
                    district="kadapa",
                    address="cvpalli",
                    phonenumber="987898789",
                    pancard="mnbv1234d",
                    description="loptap always restarting",
                    status="open",
                    category="loptap issue",
                    assignto="manager 3"

                },
                new ServiceRequestAllDataModel{
                 srId=2,
                    cusromername="test name",
                    country="india",
                    state="ka",
                    district="bangalore",
                    address="kr puram",
                    phonenumber="76867768878",
                    pancard="poiuy1234u",
                    description="testing des data",
                    status="close",
                    category="issue battery",
                    assignto="manager test"
                },
            };


            mockserviceRequestService.Setup(x => x.Getpendingservicerequest(It.IsAny<PendingDataModel>())).Returns(Task.FromResult(lists));

            dynamic result = await serviceRequestController.GetpendingservicerequestData(pendingData);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task GetpendingservicerequestData_Exception()
        {
            PendingDataModel pendingData = new PendingDataModel()
            {
                Email = "data@simple.com",
                Status = 2
            };
            mockserviceRequestService.Setup(x => x.Getpendingservicerequest(It.IsAny<PendingDataModel>())).Throws(new Exception());
            dynamic result = await serviceRequestController.GetpendingservicerequestData(pendingData);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task SearchservicerequestData_Test()
        {
            SearchDataModel searchData = new SearchDataModel()
            {
                Email = "test@gmail.com",
                Status = 3,
                SearchId = "4"
            };
            List<ServiceRequestAllDataModel> lists = new List<ServiceRequestAllDataModel>() {
                new ServiceRequestAllDataModel{
                    srId=2,
                    cusromername="ganesha",
                    country="india",
                    state="ap",
                    district="kadapa",
                    address="cvpalli",
                    phonenumber="987898789",
                    pancard="mnbv1234d",
                    description="loptap always restarting",
                    status="open",
                    category="loptap issue",
                    assignto="manager 3"

                },
                new ServiceRequestAllDataModel{
                 srId=2,
                    cusromername="test name",
                    country="india",
                    state="ka",
                    district="bangalore",
                    address="kr puram",
                    phonenumber="76867768878",
                    pancard="poiuy1234u",
                    description="testing des data",
                    status="close",
                    category="issue battery",
                    assignto="manager test"
                },
            };

            mockserviceRequestService.Setup(x => x.Searchservicerequest(It.IsAny<SearchDataModel>())).Returns(Task.FromResult(lists));

            dynamic result = await serviceRequestController.SearchservicerequestData(searchData);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task SearchservicerequestData_Exception()
        {
            SearchDataModel searchData = new SearchDataModel()
            {
                Email = "test@gmail.com",
                Status = 3,
                SearchId = "4"
            };
            mockserviceRequestService.Setup(x => x.Searchservicerequest(It.IsAny<SearchDataModel>())).Throws(new Exception());

            dynamic result = await serviceRequestController.SearchservicerequestData(searchData);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task ReopenRequestData_Test()
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

            mockserviceRequestService.Setup(x => x.ReopenServiceRequest(It.IsAny<int>())).Returns(Task.FromResult(data));

            dynamic result = await serviceRequestController.ReopenRequestData(4);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task ReopenRequestData_Exception()
        {
            mockserviceRequestService.Setup(x => x.ReopenServiceRequest(It.IsAny<int>())).Throws(new Exception());

            dynamic result = await serviceRequestController.ReopenRequestData(4);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task DeleteRequestData_Test()
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

            mockserviceRequestService.Setup(x => x.DeleteServiceRequest(It.IsAny<int>())).Returns(Task.FromResult(data));

            dynamic result = await serviceRequestController.DeleteRequestData(4);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task DeleteRequestData_Exception()
        {
            mockserviceRequestService.Setup(x => x.DeleteServiceRequest(It.IsAny<int>())).Throws(new Exception());

            dynamic result = await serviceRequestController.DeleteRequestData(4);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetServiceRequestData_Test()
        {
            GetServiceRequestDataModel res = new GetServiceRequestDataModel()
            {
                srId = 2,
                description = "test data",
                category = "test category"
            };
            mockserviceRequestService.Setup(x => x.GetServiceRequestData(It.IsAny<int>())).Returns(Task.FromResult(res));

            dynamic result = await serviceRequestController.GetServiceRequestData(4);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task GetServiceRequestData_Exception()
        {
            mockserviceRequestService.Setup(x => x.GetServiceRequestData(It.IsAny<int>())).Throws(new Exception());

            dynamic result = await serviceRequestController.GetServiceRequestData(3);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task UpdateServiceRequest_Test()
        {
            UpdateRequestDataModel updateRequest = new UpdateRequestDataModel()
            {
                SrId = 1,
                Categoty = "3",
                Description = "test",
                Email = "simple@simple.com",
            };
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
            mockserviceRequestService.Setup(x => x.UpdateServiceRequest(It.IsAny<UpdateRequestDataModel>())).Returns(Task.FromResult(data));

            dynamic result = await serviceRequestController.UpdateServiceRequest(updateRequest);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task UpdateServiceRequest_Exception()
        {
            UpdateRequestDataModel updateRequest = new UpdateRequestDataModel()
            {
                SrId = 1,
                Categoty = "4",
                Description = "test",
                Email = "simple@simple.com",
            };
            mockserviceRequestService.Setup(x => x.UpdateServiceRequest(It.IsAny<UpdateRequestDataModel>())).Throws(new Exception());

            dynamic result = await serviceRequestController.UpdateServiceRequest(updateRequest);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task GetallservicerequestData_Test()
        {
            PendingDataModel pendingData = new PendingDataModel()
            {
                Email = "data@simple.com",
                Status = 2
            };
            List<ServiceRequestAllDataModel> lists = new List<ServiceRequestAllDataModel>() {
                new ServiceRequestAllDataModel{
                    srId=2,
                    cusromername="ganesha",
                    country="india",
                    state="ap",
                    district="kadapa",
                    address="cvpalli",
                    phonenumber="987898789",
                    pancard="mnbv1234d",
                    description="loptap always restarting",
                    status="open",
                    category="loptap issue",
                    assignto="manager 3"

                },
                new ServiceRequestAllDataModel{
                 srId=2,
                    cusromername="test name",
                    country="india",
                    state="ka",
                    district="bangalore",
                    address="kr puram",
                    phonenumber="76867768878",
                    pancard="poiuy1234u",
                    description="testing des data",
                    status="close",
                    category="issue battery",
                    assignto="manager test"
                },
            };
            mockserviceRequestService.Setup(x => x.GetAllservicerequest(It.IsAny<PendingDataModel>())).Returns(Task.FromResult(lists));

            dynamic result = await serviceRequestController.GetallservicerequestData(pendingData);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task GetallservicerequestData_Exception()
        {
            PendingDataModel pendingData = new PendingDataModel()
            {
                Email = "data@simple.com",
                Status = 2
            };
            mockserviceRequestService.Setup(x => x.GetAllservicerequest(It.IsAny<PendingDataModel>())).Throws(new Exception());

            dynamic result = await serviceRequestController.GetallservicerequestData(pendingData);
            Assert.AreEqual(400, result.StatusCode);

        }
        [TestMethod]
        public async Task Getpendingrejectservicerequest_Test()
        {
            PendingDataModel pendingData = new PendingDataModel()
            {
                Email = "data@simple.com",
                Status = 2
            };
            List<ServiceRequestAllDataModel> lists = new List<ServiceRequestAllDataModel>() {
                new ServiceRequestAllDataModel{
                    srId=2,
                    cusromername="ganesha",
                    country="india",
                    state="ap",
                    district="kadapa",
                    address="cvpalli",
                    phonenumber="987898789",
                    pancard="mnbv1234d",
                    description="loptap always restarting",
                    status="open",
                    category="loptap issue",
                    assignto="manager 3"

                },
                new ServiceRequestAllDataModel{
                 srId=2,
                    cusromername="test name",
                    country="india",
                    state="ka",
                    district="bangalore",
                    address="kr puram",
                    phonenumber="76867768878",
                    pancard="poiuy1234u",
                    description="testing des data",
                    status="close",
                    category="issue battery",
                    assignto="manager test"
                },
            };
            mockserviceRequestService.Setup(x => x.GetPendingRejectServiceRequest(It.IsAny<PendingDataModel>())).Returns(Task.FromResult(lists));

            dynamic result = await serviceRequestController.Getpendingrejectservicerequest(pendingData);
            Assert.AreEqual(200, result.StatusCode);

        }
        [TestMethod]
        public async Task Getpendingrejectservicerequest_Exception()
        {
            PendingDataModel pendingData = new PendingDataModel()
            {
                Email = "data12@simple.com",
                Status = 3
            };
            mockserviceRequestService.Setup(x => x.GetPendingRejectServiceRequest(It.IsAny<PendingDataModel>())).Throws(new Exception());

            dynamic result = await serviceRequestController.Getpendingrejectservicerequest(pendingData);
            Assert.AreEqual(400, result.StatusCode);

        }
    }
}
