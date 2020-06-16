using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Manager;
using Api.Service.Services.Odoo.Configuration.New.CRM;
using Api.Service.Services.Odoo.Docker.Compose.New.CRM;
using Api.Service.Services.Odoo.Docker.Launch.CRM;
using System.Net;
using Api.Service.Services.Odoo.Docker.Delete.CRM;

namespace Api.Service.Services
{
    public class ManagerService : IManagerService
    {
        private IRepository<ManagerEntity> _repository2;


        public ManagerService(IRepository<ManagerEntity> repository)
        {
            _repository2 = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            var instancia = await _repository2.SelectAsync(id);

            //Delete Odoo in system
            FiletodeleteCRM filetodeleteCRM = new FiletodeleteCRM(instancia.Email, instancia.TAG);

            return await _repository2.DeleteAsync(id);
        }

        public async Task<ManagerEntity> Get(Guid id)
        {
            return await _repository2.SelectAsync(id);
        }

        public async Task<IEnumerable<ManagerEntity>> GetAll()
        {
            return await _repository2.SelectAsync();
        }

        public async Task<ManagerEntity> Post(ManagerEntity manager)
        {
            var repository2up = await _repository2.InsertAsync(manager);
            #region CRM IMPLEMENTATION
            if (manager.Crm_START == true)
            {

                //-----------------------------------------------------------
                //New LAUNCH TO CRM MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationCRM newconfigurationCRM = new NewconfigurationCRM(manager.Email.ToString(), manager.TAG);
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration


                NewcomposeCRM newcomposeCRM = new NewcomposeCRM(manager.Email.ToString(),
                                            manager.PORT.ToString(),
                                            "apeninos/asasaas_odoo:version11.0",
                                            manager.TAG);
                //New Launch
                NewlaunchCRM newlaunchCRM = new NewlaunchCRM(manager.Email.ToString(), manager.TAG);
            }
            #endregion

            return repository2up;
        }

        public async Task<ManagerEntity> Put(ManagerEntity manager)
        {
            #region CRM IMPLEMENTATION

            var repository2up = await _repository2.UpdateAsync(manager);

            if (manager.Crm_START == true)
            {

                //-----------------------------------------------------------
                //New LAUNCH TO CRM MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationCRM newconfigurationCRM = new NewconfigurationCRM(manager.Email.ToString(), manager.TAG);

                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeCRM newcomposeCRM = new NewcomposeCRM(manager.Email.ToString(),
                                            manager.PORT.ToString(),
                                            "apeninos/asasaas_odoo:version11.0",
                                            manager.TAG);
                //New Launch
                NewlaunchCRM newlaunchCRM = new NewlaunchCRM(manager.Email.ToString(), manager.TAG);
            }
            #endregion

            return repository2up;

        }
    }
}
