using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Common;

namespace Telemedicine.Domain.Interfaces.Repositories
{
    public interface IECGRepository : IRepository<ECG>
    {
        ECG CreateNew();
    }
}