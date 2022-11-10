
using Common.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.Consumers
{
    public class CustomerConsumer : IConsumer<ServiceRequest>
    {
        customerserviceDBContext db;
        public CustomerConsumer(customerserviceDBContext _db)
        {
            db = _db;
        }
        public Task Consume(ConsumeContext<ServiceRequest> context)
        {
            var data = context.Message;
            var servicedata = db.ServiceRequests.Where(x => x.srId == data.srId).FirstOrDefault();
            servicedata.assignId = servicedata.assignId;
            servicedata.registrationId = servicedata.registrationId;
            servicedata.srcId = servicedata.srcId;
            servicedata.srId = servicedata.srId;
            servicedata.statusId = servicedata.statusId;
            servicedata.createrequestdate = DateTime.UtcNow;
            db.ServiceRequests.Update(servicedata);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
