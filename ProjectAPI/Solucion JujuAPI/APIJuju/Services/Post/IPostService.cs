using AccesoDatos.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Customer
{
    public interface IPostService
    {
        //Se trabaja metodos asincronos y utiliza la respuesta estandar {
        Task<RespuestaService<List<PostEntity>>> Listar();

        Task<RespuestaService<PostEntity>> GetById(int id);

        Task<RespuestaService<PostEntity>> Guardar(PostEntity c);

        Task<RespuestaService<PostEntity>> Actualizar(PostEntity c);

        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
