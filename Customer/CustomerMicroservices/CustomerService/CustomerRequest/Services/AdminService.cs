using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using CustomerRequest.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRequest.Services
{
    public class AdminService : IAdminService
    {
        customerserviceDBContext db;
        private readonly IMapper mapper;
        private IConfiguration _config;
        public AdminService(customerserviceDBContext _db, IMapper _mapper, IConfiguration config)
        {
            db = _db;
            mapper = _mapper;
            _config = config;
        }
        public async Task<string> AdminLogin(CustomerLogin registration)
        {
            string str = string.Empty;
            var tokenString = str;
            try
            {
                var userdata = AuthenticateUser(registration);
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

        public async Task<List<ServiceRequestAllDataModel>> GetAdminData(CustomerLogin registration)
        {
            List<ServiceRequestAllDataModel> res = new List<ServiceRequestAllDataModel>();
            try
            {
                var data = db.ServiceRequestAssigns?.Where(x => x.email == registration.email).FirstOrDefault();
                var servicerequestdata = (from r in db.Registrations
                                          join sr in db.ServiceRequests on r.registrationId equals sr.registrationId
                                          join srs in db.ServiceRequestStatus on sr.statusId equals srs.statusId
                                          join c in db.ServiceRequestCategories on sr.srcId equals c.srcId
                                          join a in db.ServiceRequestAssigns on sr.assignId equals a.assignId
                                          join country in db.Countrys on r.cId equals country.cId
                                          join state in db.States on r.stateId equals state.stateId
                                          join d in db.Districts on r.districtId equals d.districtId
                                          where (a.assignId == data.assignId && sr.statusId==1)
                                          orderby sr.srId descending
                                          select new
                                          {
                                              srId = sr.srId,
                                              cusromername = r.customername,
                                              country = country.countryname,
                                              state = state.statename,
                                              district = d.districtname,
                                              address = r.address,
                                              phonenumber = r.contactnumber,
                                              pancard = r.pancard,
                                              description = sr.description,
                                              status = srs.statusname,
                                              category = c.categoryname,
                                              assignto = a.assignname
                                          }).ToList();


                var jsonData = JsonConvert.SerializeObject(servicerequestdata);
                res = JsonConvert.DeserializeObject<List<ServiceRequestAllDataModel>>(jsonData);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }



        }

        public async Task<ServiceRequestDto> ApproveServiceRequest(int srId)
        {
            dynamic data = null;
            try
            {
                data = db.ServiceRequests?.Where(x => x.srId == srId).FirstOrDefault();
                if (data!=null)
                {
                    data.statusId = 3;
                    data.createrequestdate = DateTime.UtcNow;
                    db.ServiceRequests.Update(data);
                    db.SaveChanges();
                }               
                return mapper.Map<ServiceRequestDto>(data);

            }
            catch (Exception ex)
            {
                return mapper.Map<ServiceRequestDto>(data);
            }


        }
        public async Task<ServiceRequestDto> RejectServiceRequest(int srId)
        {
            dynamic data = null;
            try
            {
                data = db.ServiceRequests.Where(x => x.srId == srId).FirstOrDefault();
                data.statusId = 5;
                data.createrequestdate = DateTime.UtcNow;
                db.ServiceRequests.Update(data);
                db.SaveChanges();
                return mapper.Map<ServiceRequestDto>(data);

            }
            catch (Exception ex)
            {
                return mapper.Map<ServiceRequestDto>(data);
            }


        }
        private ServiceRequestAssign AuthenticateUser(CustomerLogin registration)
        {
            var data = db.ServiceRequestAssigns?.Where(x => x.email == registration.email && x.password == registration.password).FirstOrDefault();
            if (data!=null)
            {
                return db.ServiceRequestAssigns.Where(x => x.email == registration.email && x.password == registration.password).FirstOrDefault();
            }
            else
            {
                return null;
            }


        }
        private string GenerateToken(ServiceRequestAssign registration)
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
    }
}
