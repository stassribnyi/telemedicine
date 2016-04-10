using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemedicine.Domain.Core.Models;
using Telemedicine.Domain.Interfaces.Common;

namespace Telemedicine.Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
    }
}
