using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Manager
{
    public interface IManagerService
    {
        Task<ManagerEntity> Get(Guid id);
        Task<IEnumerable<ManagerEntity>> GetAll();
        Task<ManagerEntity> Post(ManagerEntity manager);
        Task<ManagerEntity> Put(ManagerEntity manager);
        Task<bool> Delete(Guid id);
    }
}
