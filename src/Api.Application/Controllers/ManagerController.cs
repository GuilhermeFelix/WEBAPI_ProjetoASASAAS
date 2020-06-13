using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IManagerService _service;
        public ManagerController(IManagerService service)
        {
            _service = service;
        }
        /// <summary>
        /// Get ALL SAAS no Banco
        /// </summary>
        /// <returns>EXIBIR IMAGENS SAAS NA INSTANCIA MASTER</returns>
        /// <response code="200">Retorna todos os SAAS no Banco</response>
        /// <response code="400">ERRO NA REQUISIÇÃO!</response>
        /// <response code="500">ERRO DE CONEXÃO COM BD!</response>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 bad request - solicitação inválida
            }

            try
            {
                return Ok(await _service.GetAll());

            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Get specific SAAS
        /// </summary>
        /// <returns>EXIBIR IMAGEM SAAS NA INSTANCIA MASTER</returns>
        /// <response code="200">Retorna o SAAS no Banco</response>
        /// <response code="400">ERRO NA REQUISIÇÃO!</response>
        /// <response code="500">ERRO DE CONEXÃO COM BD!</response>
        [HttpGet]
        [Route("{id}", Name = "GetManagerWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
        /// <summary>
        /// Post specific SAAS
        /// </summary>
        /// <returns>ALTERAR IMAGEM SAAS NA INSTANCIA MASTER</returns>
        /// <response code="200">Alterado com Sucesso</response>
        /// <response code="400">ERRO NA REQUISIÇÃO!</response>
        /// <response code="500">ERRO DE CONEXÃO COM BD!</response>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ManagerEntity manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {

                var result = await _service.Post(manager);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetManagerWithId", new { id = result.Id })), result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        /// <summary>
        /// PUT a new SAAS
        /// </summary>
        /// <returns>NOVA IMAGEM SAAS NA INSTANCIA MASTER</returns>
        /// <response code="200">Inserido o SAAS no Banco</response>
        /// <response code="400">ERRO NA REQUISIÇÃO!</response>
        /// <response code="500">ERRO DE CONEXÃO COM BD!</response>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ManagerEntity manager)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Put(manager);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Delete a specific SAAS
        /// </summary>
        /// <returns>DELETAR IMAGEM SAAS NA INSTANCIA MASTER</returns>
        /// <response code="200">Deleta o SAAS no Banco</response>
        /// <response code="400">ERRO NA REQUISIÇÃO!</response>
        /// <response code="500">ERRO DE CONEXÃO COM BD!</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }
    }

}

