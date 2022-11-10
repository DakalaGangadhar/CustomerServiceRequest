using Common.Models.DataModels;
using CustomerRequest.Interface;
using CustomerRequest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestController : ControllerBase
    {
        IServiceRequestService serviceRequestService;
        public ServiceRequestController(IServiceRequestService _serviceRequestService)
        {
            serviceRequestService = _serviceRequestService;
        }
        [HttpGet]
        [Route("customer-servicerequestcategory")]
        public async Task<IActionResult> GetServiceRequestCategoryList()
        {
            try
            {
                List<ServiceRequestCategorieDto> data = await serviceRequestService.GetServiceRequestCategories();
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        [Route("customer-createservicerequest")]
        public async Task<IActionResult> CreateServiceRequest(ServiceRequestDataModel serviceRequestData)
        {
            try
            {
                ServiceRequestDto data = await serviceRequestService.CreateServiceRequest(serviceRequestData);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        [Route("customer-getpendingservicerequest")]
        public async Task<IActionResult> GetpendingservicerequestData(PendingDataModel serviceRequestData)
        {
            try
            {
                List<ServiceRequestAllDataModel> data = await serviceRequestService.Getpendingservicerequest(serviceRequestData);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        [Route("customer-closesearch")]
        public async Task<IActionResult> SearchservicerequestData(SearchDataModel searchDataModel)
        {
            try
            {
                List<ServiceRequestAllDataModel> data = await serviceRequestService.Searchservicerequest(searchDataModel);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPut]
        [Route("customer-reopen")]
        public async Task<IActionResult> ReopenRequestData([FromQuery] int srId)
        {
            try
            {
                ServiceRequestDto data = await serviceRequestService.ReopenServiceRequest(srId);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpDelete]
        [Route("customer-servicerequestdelete")]
        public async Task<IActionResult> DeleteRequestData([FromQuery] int srId)
        {
            try
            {
                ServiceRequestDto data = await serviceRequestService.DeleteServiceRequest(srId);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet]
        [Route("customer-getservicerequestdata")]
        public async Task<IActionResult> GetServiceRequestData([FromQuery] int srId)
        {
            try
            {
                GetServiceRequestDataModel data = await serviceRequestService.GetServiceRequestData(srId);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPut]
        [Route("customer-updateservicerequest")]
        public async Task<IActionResult> UpdateServiceRequest(UpdateRequestDataModel serviceRequestData)
        {
            try
            {
                ServiceRequestDto data = await serviceRequestService.UpdateServiceRequest(serviceRequestData);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        [Route("customer-getallservicerequest")]
        public async Task<IActionResult> GetallservicerequestData(PendingDataModel serviceRequestData)
        {
            try
            {
                List<ServiceRequestAllDataModel> data = await serviceRequestService.GetAllservicerequest(serviceRequestData);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        [Route("customer-getpendingrejectservicerequest")]
        public async Task<IActionResult> Getpendingrejectservicerequest(PendingDataModel serviceRequestData)
        {
            try
            {
                List<ServiceRequestAllDataModel> data = await serviceRequestService.GetPendingRejectServiceRequest(serviceRequestData);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
