using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Manager;
using Api.Service.Services.Server;
using Api.Service.Services.Odoo.Configuration.New.CRM;
using Api.Service.Services.Odoo.Configuration.New.Faturamento;
using Api.Service.Services.Odoo.Configuration.New.Site;
using Api.Service.Services.Odoo.Configuration.New.Vendas;
using Api.Service.Services.Odoo.Docker.Compose.New.CRM;
using Api.Service.Services.Odoo.Docker.Compose.New.Faturamento;
using Api.Service.Services.Odoo.Docker.Compose.New.Site;
using Api.Service.Services.Odoo.Docker.Compose.New.Vendas;
using Api.Service.Services.Odoo.Docker.Launch.CRM;
using Api.Service.Services.Odoo.Docker.Launch.Faturamento;
using Api.Service.Services.Odoo.Docker.Launch.Site;
using Api.Service.Services.Odoo.Docker.Launch.Vendas;
using System.Net;

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
                NewconfigurationCRM newconfigurationCRM = new NewconfigurationCRM(manager.Email.ToString(), manager.Crm_TAG);
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration

                Network networkopenport = new Network(manager.Crm_PORT, IPAddress.Parse(manager.Crm_IPV4));

                NewcomposeCRM newcomposeCRM = new NewcomposeCRM(manager.Email.ToString(),
                                            manager.Crm_PORT.ToString(),
                                            "apeninos/asasaas_odoo:version11.0",
                                            manager.Crm_TAG);
                //New Launch
                NewlaunchCRM newlaunchCRM = new NewlaunchCRM(manager.Email.ToString(), manager.Crm_TAG);
            }
            #endregion

            #region FATURAMENTO IMPLEMENTATION

            if (manager.Faturamento_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO FATURAMENTO MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationFaturamento newconfigurationFaturamento = new NewconfigurationFaturamento(manager.Email.ToString(), manager.Faturamento_TAG);
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeFaturamento newcomposeFaturamento = new NewcomposeFaturamento(manager.Email.ToString(),
                                                            manager.Faturamento_PORT.ToString(),
                                                            "apeninos/asasaas_odoo:version11.0",
                                                            manager.Faturamento_TAG);

                //New Launch
                NewlaunchFaturamento newlaunchFaturamento = new NewlaunchFaturamento(manager.Email.ToString(), manager.Faturamento_TAG);
            }
            #endregion

            #region SITE IMPLEMENTATION

            if (manager.Site_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO SITE MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationSite newconfigurationSite = new NewconfigurationSite(manager.Email.ToString(), manager.Site_TAG);
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeSite newcomposeSite = new NewcomposeSite(manager.Email.ToString(),
                                              manager.Site_PORT.ToString(),
                                              "apeninos/asasaas_odoo:version11.0",
                                              manager.Site_TAG);
                //New Launch
                NewlaunchSite newlaunchSite = new NewlaunchSite(manager.Email.ToString(), manager.Site_TAG);
            }
            #endregion

            #region VENDAS IMPLEMENTATION
            if (manager.Vendas_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO VENDAS MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationVendas newconfigurationVendas = new NewconfigurationVendas(manager.Email.ToString(), manager.Vendas_TAG);
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeVendas newcomposeVendas = new NewcomposeVendas(manager.Email.ToString(),
                                                    manager.Vendas_PORT.ToString(),
                                                    "apeninos/asasaas_odoo:version11.0",
                                                    manager.Vendas_TAG);
                //New Launch
                NewlaunchVendas newlaunchVendas = new NewlaunchVendas(manager.Email.ToString(), manager.Vendas_TAG);
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
                NewconfigurationCRM newconfigurationCRM = new NewconfigurationCRM(manager.Email.ToString(), manager.Crm_TAG);

                //Check and get the valid port
                Network networkopenport = new Network(manager.Crm_PORT, IPAddress.Parse(manager.Crm_IPV4));
                manager.Crm_PORT = networkopenport.scan_openports();

                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeCRM newcomposeCRM = new NewcomposeCRM(manager.Email.ToString(),
                                            manager.Crm_PORT.ToString(),
                                            "apeninos/asasaas_odoo:version11.0",
                                            manager.Crm_TAG);
                //New Launch
                NewlaunchCRM newlaunchCRM = new NewlaunchCRM(manager.Email.ToString(), manager.Crm_TAG);
            }
            #endregion

            #region FATURAMENTO IMPLEMENTATION

            if (manager.Faturamento_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO FATURAMENTO MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationFaturamento newconfigurationFaturamento = new NewconfigurationFaturamento(manager.Email.ToString(), manager.Faturamento_TAG);

                //Check and get the valid port
                Network networkopenport = new Network(manager.Faturamento_PORT, IPAddress.Parse(manager.Faturamento_IPV4));
                manager.Faturamento_PORT = networkopenport.scan_openports();

                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeFaturamento newcomposeFaturamento = new NewcomposeFaturamento(manager.Email.ToString(),
                                                            manager.Faturamento_PORT.ToString(),
                                                            "apeninos/asasaas_odoo:version11.0",
                                                            manager.Faturamento_TAG);
                //New Launch
                NewlaunchFaturamento newlaunchFaturamento = new NewlaunchFaturamento(manager.Email.ToString(), manager.Faturamento_TAG);
            }
            #endregion

            #region SITE IMPLEMENTATION

            if (manager.Site_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO SITE MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationSite newconfigurationSite = new NewconfigurationSite(manager.Email.ToString(), manager.Site_TAG);

                //Check and get the valid port
                Network networkopenport = new Network(manager.Site_PORT, IPAddress.Parse(manager.Site_IPV4));
                manager.Site_PORT = networkopenport.scan_openports();

                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeSite newcomposeSite = new NewcomposeSite(manager.Email.ToString(),
                                                manager.Site_PORT.ToString(),
                                                "apeninos/asasaas_odoo:version11.0",
                                                manager.Site_TAG);
                //New Launch
                NewlaunchSite newlaunchSite = new NewlaunchSite(manager.Email.ToString(), manager.Site_TAG);
            }
            #endregion

            #region VENDAS IMPLEMENTATION
            if (manager.Vendas_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO VENDAS MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationVendas newconfigurationVendas = new NewconfigurationVendas(manager.Email.ToString(), manager.Vendas_TAG);

                //Check and get the valid port
                Network networkopenport = new Network(manager.Vendas_PORT, IPAddress.Parse(manager.Vendas_IPV4));
                manager.Vendas_PORT = networkopenport.scan_openports();

                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeVendas newcomposeVendas = new NewcomposeVendas(manager.Email.ToString(),
                                                    manager.Vendas_PORT.ToString(),
                                                    "apeninos/asasaas_odoo:version11.0",
                                                    manager.Vendas_TAG);
                //New Launch
                NewlaunchVendas newlaunchVendas = new NewlaunchVendas(manager.Email.ToString(), manager.Vendas_TAG);
            }
            #endregion

            return repository2up;

        }
    }
}
