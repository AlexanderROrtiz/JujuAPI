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
    public class PostController : ControllerBase
    {
        private readonly IPostService _servicio;

        public PostController(IPostService servicio)
        {
            _servicio = servicio;
        }

        #region CRUD
        // Listar: api/Post/5
        [HttpGet]
        public async Task<ActionResult<List<PostDTO>>> Listar()
        {
            try
            {
                var retorno = await _servicio.Listar();

                if (retorno.Objeto != null)
                    return retorno.Objeto.Select(MappingsPost.ToDTO).ToList();
                else
                    return StatusCode(retorno.Status, retorno.Error);
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostEntity>> GetById(int id)
        {
            var retorno = await _servicio.GetById(id);

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO().ToDatabase();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [Route("GuardarListado")]
        [HttpPost]
        public async Task<ActionResult<PostDTO>> GuardarListado( JsonContent c) 
        {
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<PostDTO>> Guardar(PostDTO c)
        {
            var retorno = await _servicio.Guardar(c.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpPut]
        public async Task<ActionResult<PostDTO>> Actualizar(PostDTO c)
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
