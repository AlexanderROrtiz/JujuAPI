using AccesoDatos;
using AccesoDatos.Entity;
using DTOS;

namespace API.Maping
{
    public static partial class MappingsLogs
    {

        public static LogsDTO ToDTO(this LogsEntity model)  // Convierte de ModelContext a DTO
        {
            return new LogsDTO()
            {
                Id = model.Id,
                Message = model.Message,
                MessageTemplate = model.MessageTemplate,
                Level = model.Level,
                TimeStamp = model.TimeStamp,
                Exception = model.Exception,
                Properties = model.Properties

            };
        }
    }

    public static partial class MappingsLogs
    {
        public static LogsEntity ToDatabase(this LogsDTO dto)  // Convierte de DTO a ModelContext
        {
            return new LogsEntity()
            {
                Id = dto.Id,
                Message = dto.Message,
                MessageTemplate = dto.MessageTemplate,
                Level = dto.Level,
                TimeStamp = dto.TimeStamp,
                Exception = dto.Exception,
                Properties = dto.Properties

            };
        }
    }
}