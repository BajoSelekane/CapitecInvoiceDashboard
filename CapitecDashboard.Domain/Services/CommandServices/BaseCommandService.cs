using CapitecDashboard.Domain.Entities;
using CapitecDashboard.Domain.Enums;
using CapitecDashboard.Domain.Interfaces.Repositories;
using CapitecDashboard.Domain.Models.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitecDashboard.Domain.Services.CommandServices
{
    public abstract class BaseCommandService<Ent> : BaseService, IBaseCommandService<Ent> where Ent : BaseEntity
    {
        protected ICommandRepository<Ent> commandRepository;
        public BaseCommandService(ICommandRepository<Ent> commandRepository,
            ILogger<BaseCommandService<Ent>> logger)
            : base(logger)
        {
            this.commandRepository = commandRepository;
        }

        public CreationResponse<Ent> Create(Ent entity)
        {
            var response = new CreationResponse<Ent>();

            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.UpdatedAt = DateTime.Now;

                commandRepository.Create(entity);

                AfterCreation(entity);

                response.CreatedEntity = entity;
                response.CodeStatus = ResponseStatus.Success;
            }
            catch (Exception ex)
            {

                LogError(response, ex, $"Unknown error occured during creation of [{nameof(entity)}]");
            }

            return response;
        }

       

        public abstract void AfterCreation(Ent entity);

        public BaseResponse Update(Ent entity)
        {
            var response = new BaseResponse();

            try
            {
                if (entity != null)
                {
                    entity.UpdatedAt = DateTime.Now;
                    commandRepository.Update(entity);
                    response.CodeStatus = ResponseStatus.Success;
                }
                else
                {
                    response.CodeStatus = ResponseStatus.Fail;
                    response.Message = "Invoice not deleted.";
                }
            }
            catch (Exception ex)
            {
                LogError(response, ex, "Error occured when trying to delete.");
            }
            return response;
        }

        public BaseResponse Delete(long id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse Delete(Ent entity)
        {
            var response = new BaseResponse();

            try
            {
                if (entity != null)
                {
                    entity.Status = EntityStatus.Deleted;
                    entity.UpdatedAt = DateTime.Now;
                    commandRepository.Update(entity);
                    response.CodeStatus = ResponseStatus.Success;
                }
                else
                {
                    response.CodeStatus = ResponseStatus.Fail;
                    response.Message = "Invoice not deleted.";
                }
            }
            catch (Exception ex)
            {
                LogError(response, ex, "Error occured when trying to delete.");
            }
            return response;
        }
    }
}

//public CreationResponse<Ent> Create(List<Ent> entities)
//{
//    var response = new CreationResponse<Ent>();

//    try
//    {
//        entity.CreatedAt = DateTime.Now;
//        entity.UpdatedAt = DateTime.Now;

//        commandRepository.Create(entity);

//        AfterCreation(entity);

//        response.CreatedEntity = entity;
//        response.CodeStatus = ResponseStatus.Success;
//    }
//    catch (Exception ex)
//    {
//        LogError(response, ex, $"Unknown error occured during creation of [{nameof(entity)}]");
//    }

//    return response;
//}