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
    public class AdminController : ControllerBase
    {
        IAdminService adminService;
        public AdminController(IAdminService _adminService)
        {
            adminService = _adminService;
        }
        [HttpPost]       
        [Route("admin-login")]
        public async Task<IActionResult> AdminLogin([FromBody] CustomerLogin registration)
        {
            try
            {
                IActionResult response = Unauthorized();
                string userdata = await adminService.AdminLogin(registration);
                if (!string.IsNullOrEmpty(userdata))
                {
                   return response = Ok(new { token = userdata });
                }
                else
                {
                    return response = Ok(new { val = "wrong" });
                }
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        [Route("admin-data")]
        public async Task<IActionResult> GetAdminData([FromBody] CustomerLogin registration)
        {
            try
            {
                List<ServiceRequestAllDataModel> userdata = await adminService.GetAdminData(registration);
                return Ok(userdata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPut]
        [Route("admin-approve")]
        public async Task<IActionResult> Approve([FromQuery] int srId)
        {
            try
            {
                ServiceRequestDto userdata = await adminService.ApproveServiceRequest(srId);
                return Ok(userdata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPut]
        [Route("admin-reject")]
        public async Task<IActionResult> Reject([FromQuery] int srId)
        {
            try
            {
                ServiceRequestDto userdata = await adminService.RejectServiceRequest(srId);
                return Ok(userdata);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
