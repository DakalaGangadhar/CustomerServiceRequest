using AutoMapper;
using Common.Models;
using Common.Models.DataModels;
using CustomerRequest.Interface;
using MassTransit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRequest.Services
{
    public class ServiceRequestService: IServiceRequestService
    {
        customerserviceDBContext db;
        private readonly IMapper mapper;
        private readonly IBus bus;
        public ServiceRequestService(customerserviceDBContext _db, IMapper _mapper, IBus _bus)
        {
            db = _db;
            mapper = _mapper;
            bus = _bus;
        }
        public async Task<List<ServiceRequestCategorieDto>> GetServiceRequestCategories()
        {
            dynamic data = null;
            try
            {
                data = db.ServiceRequestCategories?.ToList();
                return mapper.Map<List<ServiceRequestCategorieDto>>(data);
            }
            catch (Exception ex)
            {
                return mapper.Map<List<ServiceRequestCategorieDto>>(data);
            }


        }
        public async Task<ServiceRequestDto> CreateServiceRequest(ServiceRequestDataModel serviceRequestDataModel)
        {
            ServiceRequest serviceRequest = new ServiceRequest();
            try
            {
                Uri uri = new Uri("rabbitmq:localhost/CustomerDataQueue");
                var endpoint = await bus.GetSendEndpoint(uri);
                int id = Convert.ToInt32(serviceRequestDataModel?.Categoty);

                var registration = db.Registrations.Where(x => x.email == serviceRequestDataModel.Email).FirstOrDefault();

                var catagoryData = (from a in db.ServiceRequestAssigns
                                   join c in db.ServiceRequestCategories
                                   on a.srcId equals c.srcId
                                   where (c.srcId == id)
                                   select new
                                   {
                                       srcId = c.srcId,
                                       assignId = a.assignId
                                   }).ToList();

                serviceRequest.statusId = 1;
                serviceRequest.registrationId = registration.registrationId;
                serviceRequest.srcId = catagoryData[0].srcId;
                serviceRequest.assignId = catagoryData[0].assignId; 
                serviceRequest.description = serviceRequestDataModel.Description;
                serviceRequest.createrequestdate = DateTime.UtcNow;

                db.ServiceRequests.Add(serviceRequest);
                db.SaveChanges();
                await endpoint.Send(serviceRequest);
                return mapper.Map<ServiceRequestDto>(serviceRequest);
            }
            catch (Exception ex)
            {
                return mapper.Map<ServiceRequestDto>(serviceRequest); 
            }


        }
        public async Task<List<ServiceRequestAllDataModel>> Getpendingservicerequest(PendingDataModel serviceRequestDataModel)
        {
            List<ServiceRequestAllDataModel> res = new List<ServiceRequestAllDataModel>();
            try
            {
                var data = db.Registrations.Where(x => x.email == serviceRequestDataModel.Email).FirstOrDefault();
                dynamic servicerequestdata = (from r in db.Registrations 
                                    join sr in db.ServiceRequests on r.registrationId equals sr.registrationId
                                    join srs in db.ServiceRequestStatus on sr.statusId equals srs.statusId
                                    join c in db.ServiceRequestCategories on sr.srcId equals c.srcId
                                    join a in db.ServiceRequestAssigns on sr.assignId equals a.assignId
                                    join country in db.Countrys on r.cId equals country.cId
                                    join state in db.States on r.stateId equals state.stateId
                                    join d in db.Districts on r.districtId equals d.districtId
                                    where (sr.registrationId == data.registrationId  && srs.statusId== serviceRequestDataModel.Status)
                                     orderby sr.createrequestdate descending
                                    select new
                                    {
                                        srId = sr.srId,
                                        cusromername = r.customername,
                                        country = country.countryname,
                                        state = state.statename,
                                        district = d.districtname,
                                        address=r.address,
                                        phonenumber = r.contactnumber,
                                        pancard = r.pancard,
                                        description=sr.description,
                                        status = srs.statusname,
                                        category = c.categoryname,
                                        assignto = a.assignname,
                                        date = sr.createrequestdate.ToString("dd/MM/yyyy")
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
        public async Task<List<ServiceRequestAllDataModel>> Searchservicerequest(SearchDataModel searchData)
        {
            List<ServiceRequestAllDataModel> res = new List<ServiceRequestAllDataModel>();
            try
            {
                if (!string.IsNullOrEmpty(searchData.SearchId))
                {
                    int searchId = Convert.ToInt32(searchData.SearchId);
                    var data = db.Registrations.Where(x => x.email == searchData.Email).FirstOrDefault();
                    var servicerequestdata = (from r in db.Registrations
                                              join sr in db.ServiceRequests on r.registrationId equals sr.registrationId
                                              join srs in db.ServiceRequestStatus on sr.statusId equals srs.statusId
                                              join c in db.ServiceRequestCategories on sr.srcId equals c.srcId
                                              join a in db.ServiceRequestAssigns on sr.assignId equals a.assignId
                                              join country in db.Countrys on r.cId equals country.cId
                                              join state in db.States on r.stateId equals state.stateId
                                              join d in db.Districts on r.districtId equals d.districtId
                                              where (sr.registrationId == data.registrationId && srs.statusId == searchData.Status && sr.srId == searchId)
                                              orderby sr.createrequestdate descending
                                              select new
                                              {
                                                  srId=sr.srId,
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
                                                  assignto = a.assignname,
                                                  date = sr.createrequestdate.ToString("dd/MM/yyyy")
                                              }).ToList();
                    var jsonData = JsonConvert.SerializeObject(servicerequestdata);
                    res = JsonConvert.DeserializeObject<List<ServiceRequestAllDataModel>>(jsonData);
                    return res;
                }
                else
                {
                    return null;
                }
               


               
            }
            catch (Exception ex)
            {
                return res;
            }


        }
        public async Task<ServiceRequestDto> ReopenServiceRequest(int srId)
        {
            dynamic data = null;
            try
            {
                data = db.ServiceRequests.Where(x => x.srId == srId).FirstOrDefault();
                data.statusId = 1;
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
        public async Task<ServiceRequestDto> DeleteServiceRequest(int srId)
        {
            dynamic data = null;
            try
            {
                data = db.ServiceRequests.Where(x => x.srId == srId).FirstOrDefault();
                db.ServiceRequests.Remove(data);
                db.SaveChanges();
                return mapper.Map<ServiceRequestDto>(data);

            }
            catch (Exception ex)
            {
                return mapper.Map<ServiceRequestDto>(data);
            }
        }
        public async Task<GetServiceRequestDataModel> GetServiceRequestData(int srId)
        {
            GetServiceRequestDataModel res=new GetServiceRequestDataModel();
            try
            {
                dynamic data = (from sr in db.ServiceRequests
                                          join c in db.ServiceRequestCategories on sr.srcId equals c.srcId
                                          where (sr.srId == srId)
                                          select new
                                          {
                                              srcId=Convert.ToString(sr.srcId),
                                              srId = sr.srId,
                                              description = sr.description,
                                              category = c.categoryname,
                                          }).FirstOrDefault();
               
                var jsonData = JsonConvert.SerializeObject(data);
                res = JsonConvert.DeserializeObject<GetServiceRequestDataModel>(jsonData);
                return res;
            }
            catch (Exception ex)
            {
                return res;
            }


        }
        public async Task<ServiceRequestDto> UpdateServiceRequest(UpdateRequestDataModel serviceRequestDataModel)
        {
            ServiceRequest serviceRequest = new ServiceRequest();
            dynamic update = null;
            try
            {
                int id = Convert.ToInt32(serviceRequestDataModel.Categoty);
                var registration = db.Registrations.Where(x => x.email == serviceRequestDataModel.Email).FirstOrDefault();
                update = db.ServiceRequests.Where(x => x.srId == serviceRequestDataModel.SrId).FirstOrDefault();
                var data = (from c in db.ServiceRequestCategories
                            join a in db.ServiceRequestAssigns on c.srcId equals a.srcId
                            where (c.srcId == id)
                            select new
                            {
                                assignId =a.assignId,
                                srcId =c.srcId,
                                category = c.categoryname,
                            }).FirstOrDefault();

                update.statusId = 1;
                update.registrationId = registration.registrationId;
                update.srcId = data.srcId;
                update.assignId = data.assignId;
                update.description = serviceRequestDataModel.Description;
                update.createrequestdate = DateTime.UtcNow;

                db.ServiceRequests.Update(update);
                db.SaveChanges();
                return mapper.Map<ServiceRequestDto>(update);
            }
            catch (Exception ex)
            {
                return mapper.Map<ServiceRequestDto>(update);
            }


        }
        public async Task<List<ServiceRequestAllDataModel>> GetAllservicerequest(PendingDataModel serviceRequestDataModel)
        {
            List<ServiceRequestAllDataModel> res = new List<ServiceRequestAllDataModel>();
            try
            {
                var data = db.Registrations.Where(x => x.email == serviceRequestDataModel.Email).FirstOrDefault();
                var servicerequestdata = (from r in db.Registrations
                                          join sr in db.ServiceRequests on r.registrationId equals sr.registrationId
                                          join srs in db.ServiceRequestStatus on sr.statusId equals srs.statusId
                                          join c in db.ServiceRequestCategories on sr.srcId equals c.srcId
                                          join a in db.ServiceRequestAssigns on sr.assignId equals a.assignId
                                          join country in db.Countrys on r.cId equals country.cId
                                          join state in db.States on r.stateId equals state.stateId
                                          join d in db.Districts on r.districtId equals d.districtId
                                          where (sr.registrationId == data.registrationId)
                                          orderby sr.createrequestdate descending
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
                                              assignto = a.assignname,
                                              date = sr.createrequestdate.ToString("dd/MM/yyyy")
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
        public async Task<List<ServiceRequestAllDataModel>> GetPendingRejectServiceRequest(PendingDataModel serviceRequestDataModel)
        {
            List<ServiceRequestAllDataModel> res = new List<ServiceRequestAllDataModel>();
            try
            {
                var data = db.Registrations.Where(x => x.email == serviceRequestDataModel.Email).FirstOrDefault();
                var servicerequestdata = (from r in db.Registrations
                                          join sr in db.ServiceRequests on r.registrationId equals sr.registrationId
                                          join srs in db.ServiceRequestStatus on sr.statusId equals srs.statusId
                                          join c in db.ServiceRequestCategories on sr.srcId equals c.srcId
                                          join a in db.ServiceRequestAssigns on sr.assignId equals a.assignId
                                          join country in db.Countrys on r.cId equals country.cId
                                          join state in db.States on r.stateId equals state.stateId
                                          join d in db.Districts on r.districtId equals d.districtId
                                          where (sr.registrationId == data.registrationId && (srs.statusId == serviceRequestDataModel.Status || srs.statusId == 5))
                                          orderby sr.createrequestdate descending
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
                                              assignto = a.assignname,
                                              date=sr.createrequestdate.ToString("dd/MM/yyyy")
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
    }
}
