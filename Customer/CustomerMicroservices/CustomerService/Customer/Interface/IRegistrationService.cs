using Common.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Interface
{
    public interface IRegistrationService
    {
        Task<string> CustomerLogin(CustomerLogin registration, bool IsRegister);
        Task<string> CustomerRegistration(RegistrationDataModel registration, bool IsRegister);
        Task<List<CountryDto>> GetCountryList();
        Task<List<StateDto>> GetStateList(int countryid);
        Task<List<DistrictDto>> GetDistrictList(int stateid);
        Task<RegistrationDto> GetCustomerData(PendingDataModel serviceRequestDataModel);
        Task<RegistrationDto> UpdateCustomerProfile(RegistrationDataModel registrationData);
    }
}
