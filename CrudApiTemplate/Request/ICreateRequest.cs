using CrudApiTemplate.Repository;
using Mapster;

namespace CrudApiTemplate.Request;

public interface ICreateRequest<TModel> where TModel: class
{
    public  TModel CreateNew(IUnitOfWork work)
    {
        return this.Adapt<TModel>();
    }
    public async Task<TModel> CreateNewAsync(IUnitOfWork work)
    {
        return await Task.FromResult(this.Adapt<TModel>());
    }
}