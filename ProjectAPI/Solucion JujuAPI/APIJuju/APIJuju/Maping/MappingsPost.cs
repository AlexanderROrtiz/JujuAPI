using AccesoDatos;
using AccesoDatos.Entity;
using DTOS;

namespace API.Maping
{
    public static partial class MappingsPost
    {

        public static PostDTO ToDTO(this PostEntity model)  // Convierte de ModelContext a DTO
        {
            return new PostDTO()
            {
                PostId = model.PostId,
                Title = model.Title,
                Body = model.Body,
                Type = model.Type,
                Category = model.Category,
                CustomerId = model.CustomerId

            };
        }
    }

    public static partial class MappingsPost
    {
        public static PostEntity ToDatabase(this PostDTO dto)  // Convierte de DTO a ModelContext
        {
            return new PostEntity()
            {
                PostId = dto.PostId,
                Title = dto.Title,
                Body = dto.Body,
                Type = dto.Type,
                Category = dto.Category,
                CustomerId = dto.CustomerId

            };
        }
    }
}