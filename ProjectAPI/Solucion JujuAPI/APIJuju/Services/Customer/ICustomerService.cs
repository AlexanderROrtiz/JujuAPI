using AccesoDatos.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Customer
{
    public interface ICustomerService
    {
        //Se trabaja metodos asincronos y utiliza la respuesta estandar {
        Task<RespuestaService<List<CustomerEntity>>> Listar();

        Task<RespuestaService<CustomerEntity>> GetById(int id);

        Task<RespuestaService<CustomerEntity>> Guardar(CustomerEntity c);

        Task<RespuestaService<CustomerEntity>> Actualizar(CustomerEntity c);

        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
