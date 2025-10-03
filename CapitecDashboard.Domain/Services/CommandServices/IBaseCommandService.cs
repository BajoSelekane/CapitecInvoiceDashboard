using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Models.Responses;


namespace CapitecDashboard.Domain.Services.CommandServices
{
    public interface IBaseCommandService<Ent> where Ent : BaseEntity
    {
        CreationResponse<Ent> Create(Ent entity);
        BaseResponse Update(Ent entity);
        BaseResponse Delete(long id);
        BaseResponse Delete(Ent entity);
    }
}
