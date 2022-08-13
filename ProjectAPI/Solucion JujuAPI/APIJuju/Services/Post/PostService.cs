using AccesoDatos;
using AccesoDatos.Entity;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Business.Customer
{
    //implementación de la interfaz
    public class PostService : IPostService
    {
        private DataContext _context;

        public PostService(DataContext context)
        {
            _context = context;
        }

        #region CRUD
        public async Task<RespuestaService<PostEntity>> Actualizar(PostEntity l)
        {
            var res = new RespuestaService<PostEntity>();
            var Post = await _context.Post.FirstOrDefaultAsync(x => x.PostId == l.PostId);

            if (Post == null)
                res.AgregarBadRequest("Id recibido no registrado");
            else
            {
                Post.PostId = l.PostId;
                Post.Title = l.Title;
                Post.Body = l.Body;
                Post.Type = l.Type;
                Post.Category = l.Category;
                Post.CustomerId = l.CustomerId;

                try
                {
                    _context.Post.Update(Post);
                    await _context.SaveChangesAsync();

                    res.Objeto = Post;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<PostEntity>> GetById(int id)
        {
            var res = new RespuestaService<PostEntity>();
            var Post = await _context.Post.FirstOrDefaultAsync(x => x.PostId == id);

            if (Post == null)
                res.AgregarBadRequest("Id recibido no registrado");
            else
                res.Objeto = Post;

            return res;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var res = new RespuestaService<bool>();
            var Post = await _context.Post.FirstOrDefaultAsync(x => x.PostId == id);

            if (Post == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _context.Post.Remove(Post);
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
        /// <summary>
        /// Metodo que valida si un usuario asociado si existe
        /// El texto del Body es mayor a 20 caracteres se debe cortar el texto a 97 caracteres se valida en AccesoDatos.Entity.
        /// EL Type es igual a 1 entonces Category = "Farándula", 2 entonces Category = "Política"
        /// 3 entonces Category = "Futbol" Sino dejar la que el usuario ingrese.
        /// </summary>

        public async Task<RespuestaService<PostEntity>> Guardar(PostEntity c)
        {
            var res = new RespuestaService<PostEntity>();
            
            try
            {
                var lista = await _context.Customer.ToListAsync();
                var existe = lista.FindAll(x=> x.CustomerId == c.CustomerId);
               

                foreach (var item in lista)
                {
                    if (existe.Count == 0)
                    {
                        throw new Exception($"El Usuario no existe");
                        
                    }
                    else
                    {
                        switch (c.Type)
                        {
                            case 1:
                                c.Category = "Farandula";                            
                                break;
                            case 2:
                                c.Category = "Politica";
                                break;
                        }
                        await _context.Post.AddAsync(c);
                        await _context.SaveChangesAsync();
                        c.PostId = await _context.Post.MaxAsync(u => u.PostId);
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
        
        public async Task<RespuestaService<PostEntity>> GuardarListado(List<PostEntity> c)
        {
            var res = new RespuestaService<PostEntity>();

            return res;
        }




        public async Task<RespuestaService<List<PostEntity>>> Listar()
        {
            var res = new RespuestaService<List<PostEntity>>();
            var lista = await _context.Post.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }
        #endregion

    }
}

