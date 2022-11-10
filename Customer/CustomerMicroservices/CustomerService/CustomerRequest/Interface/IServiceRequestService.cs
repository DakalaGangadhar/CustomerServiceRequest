using Common.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRequest.Interface
{
    public interface IServiceRequestService
    {
        Task<List<ServiceRequestCategorieDto>> GetServiceRequestCategories();
        Task<ServiceRequestDto> CreateServiceRequest(ServiceRequestDataModel serviceRequestDataModel);
        Task<List<ServiceRequestAllDataModel>> Getpendingservicerequest(PendingDataModel serviceRequestDataModel);
        Task<List<ServiceRequestAllDataModel>> Searchservicerequest(SearchDataModel searchData);
        Task<ServiceRequestDto> ReopenServiceRequest(int srId);
        Task<ServiceRequestDto> DeleteServiceRequest(int srId);
        Task<GetServiceRequestDataModel> GetServiceRequestData(int srId);
        Task<ServiceRequestDto> UpdateServiceRequest(UpdateRequestDataModel serviceRequestDataModel);
        Task<List<ServiceRequestAllDataModel>> GetAllservicerequest(PendingDataModel serviceRequestDataModel);
        Task<List<ServiceRequestAllDataModel>> GetPendingRejectServiceRequest(PendingDataModel serviceRequestDataModel);
    }
}
