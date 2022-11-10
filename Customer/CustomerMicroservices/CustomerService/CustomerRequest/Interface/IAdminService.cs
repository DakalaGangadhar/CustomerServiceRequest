using Common.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRequest.Interface
{
    public interface IAdminService
    {
        Task<string> AdminLogin(CustomerLogin registration);
        Task<List<ServiceRequestAllDataModel>> GetAdminData(CustomerLogin registration);
        Task<ServiceRequestDto> ApproveServiceRequest(int srId);
        Task<ServiceRequestDto> RejectServiceRequest(int srId);
    }
}
