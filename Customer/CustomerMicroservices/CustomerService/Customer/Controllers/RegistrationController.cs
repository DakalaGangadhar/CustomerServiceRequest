using Common.Models;
using Common.Models.DataModels;
using Customer.Interface;
using Customer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        IRegistrationService registrationService;
        public RegistrationController(IRegistrationService _registrationService)
        {
            registrationService = _registrationService;
        }

        [HttpPost]
        // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [Route("customer-registration")]
        public async Task<IActionResult> Registration([FromBody] RegistrationDataModel registration)
        {
            try
            {
                IActionResult response = Unauthorized();
                string userdata = await registrationService.CustomerRegistration(registration, true);
                if (registration != null)
                {
                    response = Ok(new { token = userdata });
                }
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost]
        // [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [Route("customer-login")]
        public async Task<IActionResult> Login([FromBody]CustomerLogin registration)
        {
            try
            {
                IActionResult response = Unauthorized();
                string userdata = await registrationService.CustomerLogin(registration, false);
                if (!string.IsNullOrEmpty(userdata))
                {
                    response = Ok(new { token = userdata });
                }
                else
                {
                    return response = Ok(new { val = "wrong" });
                }
                return response;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet]
        [Route("customer-country")]
        public async Task<IActionResult> GetCountry()
        {
            try
            {
                List<CountryDto> data = await registrationService.GetCountryList();
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
        [Route("customer-state")]
        public async Task<IActionResult> GetStates([FromQuery] int countryid)
        {
            try
            {
                List<StateDto> data = await registrationService.GetStateList(countryid);
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
        [Route("customer-district")]
        public async Task<IActionResult> GetDistricts([FromQuery] int stateid)
        {
            try
            {
                List<DistrictDto> data = await registrationService.GetDistrictList(stateid);
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
        [Route("customer-getcustomerdata")]
        public async Task<IActionResult> GetCustomerData(PendingDataModel serviceRequestData)
        {
            try
            {
                RegistrationDto data = await registrationService.GetCustomerData(serviceRequestData);
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
        [Route("customer-update")]
        public async Task<IActionResult> UpdateCustomerProfile(RegistrationDataModel registrationData)
        {
            try
            {
                RegistrationDto data = await registrationService.UpdateCustomerProfile(registrationData);
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
