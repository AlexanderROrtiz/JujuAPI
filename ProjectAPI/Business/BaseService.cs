using DataAccess;
using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business
{
    public class BaseService<TEntity> where TEntity : class, new()
    {
        protected BaseModel<TEntity> _BaseModel;

        public BaseService(BaseModel<TEntity> baseModel)
        {
            _BaseModel = baseModel;
        }

        #region Repository


        /// <summary>
        /// Consulta todas las entidades
        /// </summary>
        public virtual IQueryable<TEntity> GetAll()
        {
            return _BaseModel.GetAll;
        }

        /// <summary>
        /// Crea un entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Create(TEntity entity)
        {
            Customer objCustomer = entity as Customer;
            var Customer = _BaseModel.GetAll.ToList();

            System.Collections.IList list = Customer;

            bool bandera = false;
            for (int i = 0; i < list.Count; i++)
            {
                Customer item = (Customer)list[i];
                string customer = item.Name;
                int idcustomer = item.CustomerId;
                if (idcustomer == 0)
                {
                    item.Name = "El usuario asociado no existe";
                   
                }

                if (customer.Equals(objCustomer.Name))
                {
                    
                    bandera = true; 
                }
                
            }
            if (bandera == true)
            {
                Console.WriteLine("ya existe un usuario con el mismo nombre");
            }
            else
            {
                return _BaseModel.Create(entity);
            }
            return entity;

        }


        /// <summary>
        /// Actualiza la entidad (GUARDA)
        /// </summary>
        /// <param name="editedEntity">Entidad editada</param>
        /// <param name="originalEntity">Entidad Original sin cambios</param>
        /// <param name="changed">Indica si se modifico la entidad</param>
        /// <returns></returns>
        public virtual TEntity Update(object id, TEntity editedEntity, out bool changed)
        {
            TEntity originalEntity = _BaseModel.FindById(id);
            return _BaseModel.Update(editedEntity, originalEntity, out changed);
        }


        /// <summary>
        /// Elimina una entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual TEntity Delete(TEntity entity)
        {
            return _BaseModel.Delete(entity);
        }

        /// <summary>
        /// Guardar cambios
        /// </summary>
        public virtual void SaveChanges()
        {
            _BaseModel.SaveChanges();
        }
        #endregion


    }
}
