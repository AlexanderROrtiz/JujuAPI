using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using DTOS;
using System.Linq;
using Services.Customer;
using API.Maping;
using AccesoDatos.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIJuju.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _servicio;

        public CustomerController(ICustomerService servicio)
        {
            _servicio = servicio;
        }

        #region CRUD
        // Listar: api/Customer/5
        [HttpGet]
        public async Task<ActionResult<List<CustomerDTO>>> Listar()
        {
            try
            {
                var retorno = await _servicio.Listar();

                if (retorno.Objeto != null)
                    return retorno.Objeto.Select(MappingsCustomer.ToDTO).ToList();
                else
                    return StatusCode(retorno.Status, retorno.Error);
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerEntity>> GetById(int id)
        {
            var retorno = await _servicio.GetById(id);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO().ToDatabase();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        
        [HttpPost]
        public async Task<ActionResult<CustomerDTO>> Guardar(CustomerDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        
        [HttpPut]
        public async Task<ActionResult<CustomerDTO>> Actualizar(CustomerDTO c)
        {
            var retorno = await _servicio.Actualizar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            var retorno = await _servicio.Eliminar(id);

            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
        #endregion
    }
}
