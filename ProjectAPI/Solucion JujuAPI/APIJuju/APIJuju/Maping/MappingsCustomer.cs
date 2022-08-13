using AccesoDatos;
using AccesoDatos.Entity;
using DTOS;

namespace API.Maping
{
    public static partial class MappingsCustomer
    {

        public static CustomerDTO ToDTO(this CustomerEntity model)  // Convierte de ModelContext a DTO
        {
            return new CustomerDTO()
            {
                CustomerId = model.CustomerId,
                Name = model.Name

            };
        }
    }

    public static partial class MappingsCustomer
    {
        public static CustomerEntity ToDatabase(this CustomerDTO dto)  // Convierte de DTO a ModelContext
        {
            return new CustomerEntity()
            {
                CustomerId = dto.CustomerId,
                Name = dto.Name

            };
        }
    }
}