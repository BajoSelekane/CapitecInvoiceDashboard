using CapitecDashboard.Domain.Models.Request;


namespace CapitecDashboard.Domain.Entities
{
    public class ApplicationProperty : BaseEntity
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? DataType { get; set; }
        public static ApplicationProperty Create(ApplicationPropertyRequest request)
        {
            return new ApplicationProperty
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                CreatedBy = request.UserId,
                UpdatedBy = request.UserId,
                Id = request.Id,
                Key = request.Key,
                Value = request.Value,
                DataType = request.DataType,

            };
        }
    }
}
