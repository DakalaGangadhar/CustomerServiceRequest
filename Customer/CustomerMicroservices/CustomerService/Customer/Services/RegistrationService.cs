using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using Customer.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Services
{
    public class RegistrationService: IRegistrationService
    {
        customerserviceDBContext db;
        private IConfiguration _config;
        private readonly IMapper mapper;
        public RegistrationService(customerserviceDBContext _db, IConfiguration config, IMapper _mapper)
        {
            db = _db;
            _config = config;
            mapper = _mapper;
        }
        public async Task<string> CustomerRegistration(RegistrationDataModel registration, bool IsRegister)
        {
            string str = string.Empty;
            var tokenString = str;
            dynamic userdata = null;
            try
            {
                var customer = db.Registrations?.Where(x => x.email == registration.CustomerEmail).FirstOrDefault();
                if (customer != null)
                {
                    tokenString = "already";
                }
                else
                {                    
                    if (registration!=null)
                    {                       
                        Registration registrationData = new Registration();
                        registrationData.customername = registration.CustomerName;
                        registrationData.contactnumber = registration.CustomerPhoneNumber;
                        registrationData.address = registration.CustomerAddress;
                        registrationData.cId = Convert.ToInt32(registration.CustomerCountry);
                        registrationData.districtId = Convert.ToInt32(registration.CustomerDistrict);
                        registrationData.stateId = Convert.ToInt32(registration.CustomerState);
                        registrationData.pancard = registration.CustomerPanCard;
                        registrationData.password = registration.CustomerPassword;
                        registrationData.email = registration.CustomerEmail.ToLower(new CultureInfo("en-US", false));
                        registrationData.dob = Convert.ToDateTime(registration.CustomerDOB);
                        registrationData.registrationDate = DateTime.UtcNow;
                        userdata = AuthenticateUser(registrationData, IsRegister);
                    }                    
                    if (userdata != null)
                    {
                        tokenString = GenerateToken(userdata);
                        return tokenString;
                    }
                }

                return tokenString;
            }
            catch (Exception ex)
            {
                return tokenString;
            }


        }
        public async Task<string> CustomerLogin(CustomerLogin registration, bool IsRegister)
        {
            string str = string.Empty;
            var tokenString = str;
            try
            {
                Registration loginData = new Registration();
                loginData.email = registration.email;
                loginData.password = registration.password;
                var userdata = AuthenticateUser(loginData, IsRegister);
                if (userdata != null)
                {
                    tokenString = GenerateToken(userdata);
                    return tokenString;
                }
                return tokenString;
            }
            catch (Exception ex)
            {
                return tokenString;
            }


        }
        public async Task<List<CountryDto>> GetCountryList()
        {
            List<Country> countries = new List<Country>();
            try
            {                
                countries = db.Countrys?.ToList();
                return mapper.Map<List<CountryDto>>(countries);
            }
            catch (Exception ex)
            {
                return mapper.Map<List<CountryDto>>(countries);
            }


        }

        public async Task<List<StateDto>> GetStateList(int countryid)
        {
            List<State> states = new List<State>();
            try
            {
                states = db.States?.Where(x => x.cId == countryid).ToList();
                return mapper.Map<List<StateDto>>(states);
            }
            catch (Exception ex)
            {
                return mapper.Map<List<StateDto>>(states);
            }


        }

        public async Task<List<DistrictDto>> GetDistrictList(int stateid)
        {
            dynamic data = null; 
            try
            {
                 data = db.Districts?.Where(x => x.stateId == stateid).ToList();
                return mapper.Map<List<DistrictDto>>(data);
            }
            catch (Exception ex)
            {
                return mapper.Map<List<DistrictDto>>(data);
            }
        }

        private Registration AuthenticateUser(Registration registration, bool IsRegister)
        {
            if (IsRegister)
            {
                db.Registrations?.Add(registration);
                db.SaveChanges();
                return registration;
            }
            else
            {
                var data= db.Registrations?.Where(x => x.email == registration.email && x.password == registration.password).FirstOrDefault();
                if (data!=null)
                {
                    return db.Registrations?.Where(x => x.email == registration.email && x.password == registration.password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }

        }
        private string GenerateToken(Registration registration)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["jwt:Issuer"],
                _config["jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<RegistrationDto> GetCustomerData(PendingDataModel serviceRequestDataModel)
        {
            dynamic data = null;
            try
            {
                 data = db.Registrations?.Where(x => x.email == serviceRequestDataModel.Email).FirstOrDefault(); 
                return mapper.Map<RegistrationDto>(data);
            }
            catch (Exception ex)
            {
                return mapper.Map<List<RegistrationDto>>(data);
            }


        }
        public async Task<RegistrationDto> UpdateCustomerProfile(RegistrationDataModel registrationData)
        {
            dynamic registration = null;
            try
            {
                registration = db.Registrations?.Where(x => x.registrationId == registrationData.registrationId).FirstOrDefault();
                if (registration!=null)
                {
                    registration.address = registrationData?.CustomerAddress;
                    registration.cId = Convert.ToInt32(registrationData?.CustomerCountry);
                    registration.contactnumber = registrationData?.CustomerPhoneNumber;
                    registration.customername = registrationData?.CustomerName;
                    registration.districtId = Convert.ToInt32(registrationData?.CustomerDistrict);
                    registration.dob = Convert.ToDateTime(registrationData?.CustomerDOB);
                    registration.email = registrationData?.CustomerEmail;
                    registration.pancard = registrationData?.CustomerPanCard;
                    registration.password = registrationData?.CustomerPassword;
                    registration.registrationDate = DateTime.UtcNow;
                    registration.stateId = Convert.ToInt32(registrationData?.CustomerState);

                    db.Registrations?.Update(registration);
                    db.SaveChanges();
                }                 
                return mapper.Map<RegistrationDto>(registration);
            }
            catch (Exception ex)
            {
                return mapper.Map<List<RegistrationDto>>(registration);
            }


        }
    }
}
