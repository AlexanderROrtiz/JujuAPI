using AccesoDatos;
using AccesoDatos.Entity;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Customer
{
    //implementación de la interfaz
    public class CustomerService : ICustomerService
    {
        private DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }
        #region CRUD
        public async Task<RespuestaService<CustomerEntity>> Actualizar(CustomerEntity l)
        {
            var res = new RespuestaService<CustomerEntity>();
            var Customer = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerId == l.CustomerId);

            if (Customer == null)
                res.AgregarBadRequest("Id recibido no registrado");
            else
            {
                Customer.CustomerId = l.CustomerId;
                Customer.Name = l.Name;

                try
                {
                    _context.Customer.Update(Customer);
                    await _context.SaveChangesAsync();

                    res.Objeto = Customer;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<CustomerEntity>> GetById(int id)
        {
            var res = new RespuestaService<CustomerEntity>();
            var Customer = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);

            if (Customer == null)
                res.AgregarBadRequest("Id recibido no registrado");
            else
                res.Objeto = Customer;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var res = new RespuestaService<bool>();
            var Customer = await _context.Customer.FirstOrDefaultAsync(x => x.CustomerId == id);

            if (Customer == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Customer.Remove(Customer);
                    await _context.SaveChangesAsync();
                    res.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<CustomerEntity>> Guardar(CustomerEntity c)
        {
            var res = new RespuestaService<CustomerEntity>();
            
            try
            {
                var lista = await _context.Customer.ToListAsync();
                foreach (var item in lista)
                {
                    if (item.Name == c.Name)
                    {
                       throw new Exception($"El nombre {item.Name} ya existe");
                        
                    }
                    else
                    {
                        await _context.Customer.AddAsync(c);
                        await _context.SaveChangesAsync();
                        c.CustomerId = await _context.Customer.MaxAsync(u => u.CustomerId);
                    }

                }
                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<List<CustomerEntity>>> Listar()
        {
            var res = new RespuestaService<List<CustomerEntity>>();
            var lista = await _context.Customer.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
        #endregion
    }
}

