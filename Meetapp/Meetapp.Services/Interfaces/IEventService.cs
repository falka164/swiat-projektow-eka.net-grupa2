using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Meetapp.Core.Responses;

namespace Meetapp.Services.Interfaces
{
    public interface IEventService
    {
        Task<Response> CreateEvent(DateTime startDate, DateTime endDate, DateTime saleExpDate, int cost, string title, string location, string category, bool reqConfirm);  

        Task<Response> GetEvent(int id);

        Task<Response> UpdateEvent(int id, DateTime startDate, DateTime endDate, DateTime saleExpDate, int cost, string title, string location, string category, bool reqConfirm);

        Task<Response> DeleteEvent(int id);
    }
}
